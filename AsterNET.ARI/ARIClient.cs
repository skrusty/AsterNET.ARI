using System;
using System.Diagnostics;
using System.Threading;
using AsterNET.ARI.Actions;
using AsterNET.ARI.Dispatchers;
using AsterNET.ARI.Middleware;
using AsterNET.ARI.Middleware.Default;
using AsterNET.ARI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AsterNET.ARI
{
    public enum EventDispatchingStrategy
    {
        DedicatedThread,
        // Note that dispatching events on the thread pool implies that events might be processed out of order.
        ThreadPool
    }

    /// <summary>
    /// </summary>
    public class AriClient : IAriClient, IDisposable
    {
        public const EventDispatchingStrategy DefaultEventDispatchingStrategy = EventDispatchingStrategy.DedicatedThread;

        public delegate void ConnectionStateChangedHandler(object sender);

        #region Events

        public event ChannelCallerIdEventHandler OnChannelCallerIdEvent;
        public event ChannelDtmfReceivedEventHandler OnChannelDtmfReceivedEvent;
        public event BridgeCreatedEventHandler OnBridgeCreatedEvent;
        public event ChannelCreatedEventHandler OnChannelCreatedEvent;
        public event ApplicationReplacedEventHandler OnApplicationReplacedEvent;
        public event ChannelStateChangeEventHandler OnChannelStateChangeEvent;
        public event PlaybackFinishedEventHandler OnPlaybackFinishedEvent;
        public event RecordingStartedEventHandler OnRecordingStartedEvent;
        public event ChannelLeftBridgeEventHandler OnChannelLeftBridgeEvent;
        public event ChannelDestroyedEventHandler OnChannelDestroyedEvent;
        public event DeviceStateChangedEventHandler OnDeviceStateChangedEvent;
        public event ChannelTalkingFinishedEventHandler OnChannelTalkingFinishedEvent;
        public event PlaybackStartedEventHandler OnPlaybackStartedEvent;
        public event ChannelTalkingStartedEventHandler OnChannelTalkingStartedEvent;
        public event RecordingFailedEventHandler OnRecordingFailedEvent;
        public event BridgeMergedEventHandler OnBridgeMergedEvent;
        public event RecordingFinishedEventHandler OnRecordingFinishedEvent;
        public event BridgeAttendedTransferEventHandler OnBridgeAttendedTransferEvent;
        public event ChannelEnteredBridgeEventHandler OnChannelEnteredBridgeEvent;
        public event BridgeDestroyedEventHandler OnBridgeDestroyedEvent;
        public event BridgeBlindTransferEventHandler OnBridgeBlindTransferEvent;
        public event ChannelUsereventEventHandler OnChannelUsereventEvent;
        public event ChannelDialplanEventHandler OnChannelDialplanEvent;
        public event ChannelHangupRequestEventHandler OnChannelHangupRequestEvent;
        public event ChannelVarsetEventHandler OnChannelVarsetEvent;
        public event EndpointStateChangeEventHandler OnEndpointStateChangeEvent;
        public event DialEventHandler OnDialEvent;
        public event StasisEndEventHandler OnStasisEndEvent;
        public event StasisStartEventHandler OnStasisStartEvent;
        public event TextMessageReceivedEventHandler OnTextMessageReceivedEvent;
        public event ChannelConnectedLineEventHandler OnChannelConnectedLineEvent;
        public event UnhandledEventHandler OnUnhandledEvent;
        public event ConnectionStateChangedHandler OnConnectionStateChanged;

        #endregion       

        #region Private Fields

        private readonly IActionConsumer _actionConsumer;
        private readonly IEventProducer _eventProducer;

        private readonly object _syncRoot = new object();
        private bool _autoReconnect;
        private TimeSpan _autoReconnectDelay;
        private EventDispatchingStrategy _dispatchingStrategy = DefaultEventDispatchingStrategy; 
        private IAriDispatcher _dispatcher;

        #endregion

        #region Public Properties

        public IAsteriskActions Asterisk { get; set; }
        public IApplicationsActions Applications { get; set; }
        public IBridgesActions Bridges { get; set; }
        public IChannelsActions Channels { get; set; }
        public IDeviceStatesActions DeviceStates { get; set; }
        public IEndpointsActions Endpoints { get; set; }
        public IEventsActions Events { get; set; }
        public IPlaybacksActions Playbacks { get; set; }
        public IRecordingsActions Recordings { get; set; }
        public ISoundsActions Sounds { get; set; }

        public ConnectionState ConnectionState
        {
            get { return _eventProducer.State; }
        }

        public EventDispatchingStrategy EventDispatchingStrategy { get; set; }
        
        #endregion

        #region Constructor

        /// <summary>
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="application"></param>
        public AriClient(StasisEndpoint endPoint, string application)
            // Use Default Middleware
            : this(new RestActionConsumer(endPoint), new WebSocketEventProducer(endPoint, application), application)
        {
        }

        public AriClient(IActionConsumer actionConsumer, IEventProducer eventProducer, string application)
        {
            _actionConsumer = actionConsumer;
            _eventProducer = eventProducer;

            // Setup Action Properties
            Asterisk = new AsteriskActions(_actionConsumer);
            Applications = new ApplicationsActions(_actionConsumer);
            Bridges = new BridgesActions(_actionConsumer);
            Channels = new ChannelsActions(_actionConsumer);
            DeviceStates = new DeviceStatesActions(_actionConsumer);
            Endpoints = new EndpointsActions(_actionConsumer);
            Events = new EventsActions(_actionConsumer);
            Playbacks = new PlaybacksActions(_actionConsumer);
            Recordings = new RecordingsActions(_actionConsumer);
            Sounds = new SoundsActions(_actionConsumer);

            // Setup Event Handlers
            _eventProducer.OnMessageReceived += _eventProducer_OnMessageReceived;
            _eventProducer.OnConnectionStateChanged += _eventProducer_OnConnectionStateChanged;
        }

        public void Dispose()
        {
            _eventProducer.OnConnectionStateChanged -= _eventProducer_OnConnectionStateChanged;
            _eventProducer.OnMessageReceived -= _eventProducer_OnMessageReceived;
            
            Disconnect();
        }

        #endregion

        #region Private and Protected Methods

        private void _eventProducer_OnConnectionStateChanged(object sender, EventArgs e)
        {
            if (_eventProducer.State != ConnectionState.Open)
                Reconnect();

            if (OnConnectionStateChanged != null)
                OnConnectionStateChanged(sender);
        }

        private void _eventProducer_OnMessageReceived(object sender, MessageEventArgs e)
        {
#if DEBUG
            Debug.WriteLine(e.Message);
#endif
            // load the message
            var jsonMsg = (JObject) JToken.Parse(e.Message);
            var eventName = jsonMsg.SelectToken("type").Value<string>();
            var type = Type.GetType("AsterNET.ARI.Models." + eventName + "Event");
            var evnt =
                (type != null)
                    ? (Event) JsonConvert.DeserializeObject(e.Message, type)
                    : (Event) JsonConvert.DeserializeObject(e.Message, typeof (Event));

            lock (_syncRoot)
            {
                if (_dispatcher != null)
                {
                    _dispatcher.QueueAction(() =>
                    {
                        FireEvent(evnt.Type, evnt, this);
                    });
                }
            }
        }

        private void Reconnect()
        {
            TimeSpan reconnectDelay;

            lock (_syncRoot)
            {
                var shouldReconnect = _autoReconnect 
                    && _eventProducer.State != ConnectionState.Open
                    && _eventProducer.State != ConnectionState.Connecting;

                if (!shouldReconnect)
                    return;

                reconnectDelay = _autoReconnectDelay;
            }

            if (reconnectDelay != TimeSpan.Zero)
                Thread.Sleep(reconnectDelay);
            _eventProducer.Connect();
        }

        protected void FireEvent(string eventName, object eventArgs, IAriClient sender)
        {
            switch (eventName)
            {
                case "ChannelCallerId":
                    if (OnChannelCallerIdEvent != null)
                        OnChannelCallerIdEvent(sender, (ChannelCallerIdEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
                    break;


                case "ChannelDtmfReceived":
                    if (OnChannelDtmfReceivedEvent != null)
                        OnChannelDtmfReceivedEvent(sender, (ChannelDtmfReceivedEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "BridgeCreated":
                    if (OnBridgeCreatedEvent != null)
                        OnBridgeCreatedEvent(sender, (BridgeCreatedEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ChannelCreated":
                    if (OnChannelCreatedEvent != null)
                        OnChannelCreatedEvent(sender, (ChannelCreatedEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ApplicationReplaced":
                    if (OnApplicationReplacedEvent != null)
                        OnApplicationReplacedEvent(sender, (ApplicationReplacedEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ChannelStateChange":
                    if (OnChannelStateChangeEvent != null)
                        OnChannelStateChangeEvent(sender, (ChannelStateChangeEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "PlaybackFinished":
                    if (OnPlaybackFinishedEvent != null)
                        OnPlaybackFinishedEvent(sender, (PlaybackFinishedEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "RecordingStarted":
                    if (OnRecordingStartedEvent != null)
                        OnRecordingStartedEvent(sender, (RecordingStartedEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ChannelLeftBridge":
                    if (OnChannelLeftBridgeEvent != null)
                        OnChannelLeftBridgeEvent(sender, (ChannelLeftBridgeEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ChannelDestroyed":
                    if (OnChannelDestroyedEvent != null)
                        OnChannelDestroyedEvent(sender, (ChannelDestroyedEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "DeviceStateChanged":
                    if (OnDeviceStateChangedEvent != null)
                        OnDeviceStateChangedEvent(sender, (DeviceStateChangedEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ChannelTalkingFinished":
                    if (OnChannelTalkingFinishedEvent != null)
                        OnChannelTalkingFinishedEvent(sender, (ChannelTalkingFinishedEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "PlaybackStarted":
                    if (OnPlaybackStartedEvent != null)
                        OnPlaybackStartedEvent(sender, (PlaybackStartedEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ChannelTalkingStarted":
                    if (OnChannelTalkingStartedEvent != null)
                        OnChannelTalkingStartedEvent(sender, (ChannelTalkingStartedEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "RecordingFailed":
                    if (OnRecordingFailedEvent != null)
                        OnRecordingFailedEvent(sender, (RecordingFailedEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "BridgeMerged":
                    if (OnBridgeMergedEvent != null)
                        OnBridgeMergedEvent(sender, (BridgeMergedEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "RecordingFinished":
                    if (OnRecordingFinishedEvent != null)
                        OnRecordingFinishedEvent(sender, (RecordingFinishedEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "BridgeAttendedTransfer":
                    if (OnBridgeAttendedTransferEvent != null)
                        OnBridgeAttendedTransferEvent(sender, (BridgeAttendedTransferEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ChannelEnteredBridge":
                    if (OnChannelEnteredBridgeEvent != null)
                        OnChannelEnteredBridgeEvent(sender, (ChannelEnteredBridgeEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "BridgeDestroyed":
                    if (OnBridgeDestroyedEvent != null)
                        OnBridgeDestroyedEvent(sender, (BridgeDestroyedEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "BridgeBlindTransfer":
                    if (OnBridgeBlindTransferEvent != null)
                        OnBridgeBlindTransferEvent(sender, (BridgeBlindTransferEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ChannelUserevent":
                    if (OnChannelUsereventEvent != null)
                        OnChannelUsereventEvent(sender, (ChannelUsereventEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ChannelDialplan":
                    if (OnChannelDialplanEvent != null)
                        OnChannelDialplanEvent(sender, (ChannelDialplanEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ChannelHangupRequest":
                    if (OnChannelHangupRequestEvent != null)
                        OnChannelHangupRequestEvent(sender, (ChannelHangupRequestEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ChannelVarset":
                    if (OnChannelVarsetEvent != null)
                        OnChannelVarsetEvent(sender, (ChannelVarsetEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "EndpointStateChange":
                    if (OnEndpointStateChangeEvent != null)
                        OnEndpointStateChangeEvent(sender, (EndpointStateChangeEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "Dial":
                    if (OnDialEvent != null)
                        OnDialEvent(sender, (DialEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "StasisEnd":
                    if (OnStasisEndEvent != null)
                        OnStasisEndEvent(sender, (StasisEndEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "StasisStart":
                    if (OnStasisStartEvent != null)
                        OnStasisStartEvent(sender, (StasisStartEvent) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;
                case "TextMessageReceived":
                    if (OnTextMessageReceivedEvent != null)
                        OnTextMessageReceivedEvent(sender, (TextMessageReceivedEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ChannelConnectedLine":
                    if (OnChannelConnectedLineEvent != null)
                        OnChannelConnectedLineEvent(sender, (ChannelConnectedLineEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                default:
                    if (OnUnhandledEvent != null)
                        OnUnhandledEvent(this, (Event) eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;
            }
        }

        IAriDispatcher CreateDispatcher()
        {
            switch (_dispatchingStrategy)
            {
                case EventDispatchingStrategy.DedicatedThread: return new DedicatedThreadDispatcher();
                case EventDispatchingStrategy.ThreadPool: return new ThreadPoolDispatcher();
            }

            throw new AriException(_dispatchingStrategy.ToString());
        }

        #endregion

        #region Public Methods

        public bool Connected
        {
            get { return _eventProducer.State == ConnectionState.Open; }
        }

        public void Connect(bool autoReconnect = true, int autoReconnectDelay = 5)
        {
            lock (_syncRoot)
            {
                _autoReconnect = autoReconnect;
                _autoReconnectDelay = TimeSpan.FromSeconds(autoReconnectDelay);
                if (_dispatcher == null)
                    _dispatcher = CreateDispatcher();
            }

            _eventProducer.Connect();
        }

        public void Disconnect()
        {
            lock (_syncRoot)
            {
                _autoReconnect = false;
                if (_dispatcher != null)
                {
                    _dispatcher.Dispose();
                    _dispatcher = null;
                }
            }

            _eventProducer.Disconnect();
        }

        #endregion
    }
}