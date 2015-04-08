using System;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using AsterNET.ARI.Actions;
using AsterNET.ARI.Middleware;
using AsterNET.ARI.Middleware.Default;
using AsterNET.ARI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AsterNET.ARI
{
    /// <summary>
    /// </summary>
    public class AriClient : IAriClient
    {
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
        public event UnhandledEventHandler OnUnhandledEvent;
        public event ConnectionStateChangedHandler OnConnectionStateChanged;

        #endregion       

        #region Private Fields

        private readonly IActionConsumer _actionConsumer;
        private readonly IEventProducer _eventProducer;

        private bool _autoReconnect;
        private TimeSpan _autoReconnectDelay;
        private ConnectionState _lastKnownState;

        private event AriEventHandler InternalEvent;

        private delegate void AriEventHandler(IAriClient sender, Event e);

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

        #endregion

        #region Constructor

        /// <summary>
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="application"></param>
        public AriClient(StasisEndpoint endPoint, string application)
        {
            // Use Default Middleware
            _eventProducer = new WebSocketEventProducer(endPoint, application);
            _actionConsumer = new RestActionConsumer(endPoint);

            Init();
        }

        public AriClient(IActionConsumer actionConsumer, IEventProducer eventProducer, string application)
        {
            _actionConsumer = actionConsumer;
            _eventProducer = eventProducer;

            Init();
        }

        #endregion

        #region Internal Methods

        internal void Init()
        {
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
            InternalEvent += ARIClient_internalEvent;
            _eventProducer.OnMessageReceived += _eventProducer_OnMessageReceived;
            _eventProducer.OnConnectionStateChanged += _eventProducer_OnConnectionStateChanged;
        }

        private void _eventProducer_OnConnectionStateChanged(object sender, EventArgs e)
        {
            if (_eventProducer.State != ConnectionState.Open)
                Reconnect();
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
            if (type != null)
                InternalEvent.BeginInvoke(this, (Event) JsonConvert.DeserializeObject(e.Message, type), eventComplete,
                    null);
            else
                InternalEvent.BeginInvoke(this, (Event) JsonConvert.DeserializeObject(e.Message, typeof (Event)),
                    eventComplete, null);
        }

        private void ARIClient_internalEvent(IAriClient sender, Event e)
        {
            FireEvent(e.Type, e, sender);
        }

        private void eventComplete(IAsyncResult result)
        {
            var ar = (AsyncResult) result;
            var invokedMethod = (AriEventHandler) ar.AsyncDelegate;

            try
            {
                invokedMethod.EndInvoke(result);
            }
            catch
            {
                // Handle any exceptions that were thrown by the invoked method
                Console.WriteLine("An event listener went kaboom!");
            }
        }

        private void Reconnect()
        {
            if (_autoReconnect && _eventProducer.State != ConnectionState.Open)
            {
                if (_autoReconnectDelay != TimeSpan.Zero)
                    Thread.Sleep(_autoReconnectDelay);
                Connect();
            }
        }

        protected void FireEvent(string eventName, object eventArgs, IAriClient sender)
        {
            switch (eventName)
            {
                case "ChannelCallerId":
                    if (OnChannelCallerIdEvent != null)
                        OnChannelCallerIdEvent(sender, (ChannelCallerIdEvent) eventArgs);
                    break;


                case "ChannelDtmfReceived":
                    if (OnChannelDtmfReceivedEvent != null)
                        OnChannelDtmfReceivedEvent(sender, (ChannelDtmfReceivedEvent) eventArgs);
                    break;


                case "BridgeCreated":
                    if (OnBridgeCreatedEvent != null)
                        OnBridgeCreatedEvent(sender, (BridgeCreatedEvent) eventArgs);
                    break;


                case "ChannelCreated":
                    if (OnChannelCreatedEvent != null)
                        OnChannelCreatedEvent(sender, (ChannelCreatedEvent) eventArgs);
                    break;


                case "ApplicationReplaced":
                    if (OnApplicationReplacedEvent != null)
                        OnApplicationReplacedEvent(sender, (ApplicationReplacedEvent) eventArgs);
                    break;


                case "ChannelStateChange":
                    if (OnChannelStateChangeEvent != null)
                        OnChannelStateChangeEvent(sender, (ChannelStateChangeEvent) eventArgs);
                    break;


                case "PlaybackFinished":
                    if (OnPlaybackFinishedEvent != null)
                        OnPlaybackFinishedEvent(sender, (PlaybackFinishedEvent) eventArgs);
                    break;


                case "RecordingStarted":
                    if (OnRecordingStartedEvent != null)
                        OnRecordingStartedEvent(sender, (RecordingStartedEvent) eventArgs);
                    break;


                case "ChannelLeftBridge":
                    if (OnChannelLeftBridgeEvent != null)
                        OnChannelLeftBridgeEvent(sender, (ChannelLeftBridgeEvent) eventArgs);
                    break;


                case "ChannelDestroyed":
                    if (OnChannelDestroyedEvent != null)
                        OnChannelDestroyedEvent(sender, (ChannelDestroyedEvent) eventArgs);
                    break;


                case "DeviceStateChanged":
                    if (OnDeviceStateChangedEvent != null)
                        OnDeviceStateChangedEvent(sender, (DeviceStateChangedEvent) eventArgs);
                    break;


                case "ChannelTalkingFinished":
                    if (OnChannelTalkingFinishedEvent != null)
                        OnChannelTalkingFinishedEvent(sender, (ChannelTalkingFinishedEvent) eventArgs);
                    break;


                case "PlaybackStarted":
                    if (OnPlaybackStartedEvent != null)
                        OnPlaybackStartedEvent(sender, (PlaybackStartedEvent) eventArgs);
                    break;


                case "ChannelTalkingStarted":
                    if (OnChannelTalkingStartedEvent != null)
                        OnChannelTalkingStartedEvent(sender, (ChannelTalkingStartedEvent) eventArgs);
                    break;


                case "RecordingFailed":
                    if (OnRecordingFailedEvent != null)
                        OnRecordingFailedEvent(sender, (RecordingFailedEvent) eventArgs);
                    break;


                case "BridgeMerged":
                    if (OnBridgeMergedEvent != null)
                        OnBridgeMergedEvent(sender, (BridgeMergedEvent) eventArgs);
                    break;


                case "RecordingFinished":
                    if (OnRecordingFinishedEvent != null)
                        OnRecordingFinishedEvent(sender, (RecordingFinishedEvent) eventArgs);
                    break;


                case "BridgeAttendedTransfer":
                    if (OnBridgeAttendedTransferEvent != null)
                        OnBridgeAttendedTransferEvent(sender, (BridgeAttendedTransferEvent) eventArgs);
                    break;


                case "ChannelEnteredBridge":
                    if (OnChannelEnteredBridgeEvent != null)
                        OnChannelEnteredBridgeEvent(sender, (ChannelEnteredBridgeEvent) eventArgs);
                    break;


                case "BridgeDestroyed":
                    if (OnBridgeDestroyedEvent != null)
                        OnBridgeDestroyedEvent(sender, (BridgeDestroyedEvent) eventArgs);
                    break;


                case "BridgeBlindTransfer":
                    if (OnBridgeBlindTransferEvent != null)
                        OnBridgeBlindTransferEvent(sender, (BridgeBlindTransferEvent) eventArgs);
                    break;


                case "ChannelUserevent":
                    if (OnChannelUsereventEvent != null)
                        OnChannelUsereventEvent(sender, (ChannelUsereventEvent) eventArgs);
                    break;


                case "ChannelDialplan":
                    if (OnChannelDialplanEvent != null)
                        OnChannelDialplanEvent(sender, (ChannelDialplanEvent) eventArgs);
                    break;


                case "ChannelHangupRequest":
                    if (OnChannelHangupRequestEvent != null)
                        OnChannelHangupRequestEvent(sender, (ChannelHangupRequestEvent) eventArgs);
                    break;


                case "ChannelVarset":
                    if (OnChannelVarsetEvent != null)
                        OnChannelVarsetEvent(sender, (ChannelVarsetEvent) eventArgs);
                    break;


                case "EndpointStateChange":
                    if (OnEndpointStateChangeEvent != null)
                        OnEndpointStateChangeEvent(sender, (EndpointStateChangeEvent) eventArgs);
                    break;


                case "Dial":
                    if (OnDialEvent != null)
                        OnDialEvent(sender, (DialEvent) eventArgs);
                    break;


                case "StasisEnd":
                    if (OnStasisEndEvent != null)
                        OnStasisEndEvent(sender, (StasisEndEvent) eventArgs);
                    break;


                case "StasisStart":
                    if (OnStasisStartEvent != null)
                        OnStasisStartEvent(sender, (StasisStartEvent) eventArgs);
                    break;
                default:
                    if (OnUnhandledEvent != null)
                        OnUnhandledEvent(this, (Event) eventArgs);
                    break;
            }
        }

        protected virtual void RaiseOnConnectionStateChanged()
        {
            if (_eventProducer.State == _lastKnownState) return;

            _lastKnownState = _eventProducer.State;
            var handler = OnConnectionStateChanged;
            if (handler != null) handler(this);
        }

        #endregion

        #region Public Methods

        public bool Connected
        {
            get { return _eventProducer.State == ConnectionState.Open; }
        }

        public void Connect(bool autoReconnect = true, int autoReconnectDelay = 5)
        {
            _eventProducer.Connect();
        }

        public void Disconnect()
        {
            _autoReconnect = false;
            _eventProducer.Disconnect();
        }

        #endregion
    }
}