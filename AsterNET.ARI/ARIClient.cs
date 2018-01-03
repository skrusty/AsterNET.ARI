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
        // Note that dispatching events on the thread pool implies that events might be processed out of order.
        ThreadPool,
        DedicatedThread,
        AsyncTask
    }

    /// <summary>
    /// </summary>
    public class AriClient : BaseAriClient, IDisposable, IAriClient
    {
        public const EventDispatchingStrategy DefaultEventDispatchingStrategy = EventDispatchingStrategy.ThreadPool;

        public delegate void ConnectionStateChangedHandler(object sender);

        #region Events

        public event ConnectionStateChangedHandler OnConnectionStateChanged;

        #endregion

        #region Private Fields

        private readonly IActionConsumer _actionConsumer;
        private readonly IEventProducer _eventProducer;

        private readonly object _syncRoot = new object();
        private readonly bool _subscribeAllEvents;
        private bool _autoReconnect;
        private TimeSpan _autoReconnectDelay;
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
        public IMailboxesActions Mailboxes { get; set; }
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
        /// <param name="subscribeAllEvents">Subscribe to all Asterisk events. If provided, the applications listed will be subscribed to all events, effectively disabling the application specific subscriptions.</param>
        public AriClient(StasisEndpoint endPoint, string application, bool subscribeAllEvents = false)
            // Use Default Middleware
            : this(new RestActionConsumer(endPoint), new WebSocketEventProducer(endPoint, application), application, subscribeAllEvents)
        {
        }

        public AriClient(IActionConsumer actionConsumer, IEventProducer eventProducer, string application, bool subscribeAllEvents = false)
        {
            _actionConsumer = actionConsumer;
            _eventProducer = eventProducer;
            EventDispatchingStrategy = DefaultEventDispatchingStrategy;

            // Setup Action Properties
            Asterisk = new AsteriskActions(_actionConsumer);
            Applications = new ApplicationsActions(_actionConsumer);
            Bridges = new BridgesActions(_actionConsumer);
            Channels = new ChannelsActions(_actionConsumer);
            DeviceStates = new DeviceStatesActions(_actionConsumer);
            Endpoints = new EndpointsActions(_actionConsumer);
            Events = new EventsActions(_actionConsumer);
            Mailboxes = new MailboxesActions(_actionConsumer);
            Playbacks = new PlaybacksActions(_actionConsumer);
            Recordings = new RecordingsActions(_actionConsumer);
            Sounds = new SoundsActions(_actionConsumer);
            // Setup Event Handlers
            _eventProducer.OnMessageReceived += _eventProducer_OnMessageReceived;
            _eventProducer.OnConnectionStateChanged += _eventProducer_OnConnectionStateChanged;

            _subscribeAllEvents = subscribeAllEvents;
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
            var jsonMsg = (JObject)JToken.Parse(e.Message);
            var eventName = jsonMsg.SelectToken("type").Value<string>();
            var type = Type.GetType("AsterNET.ARI.Models." + eventName + "Event");
            var evnt =
                (type != null)
                    ? (Event)JsonConvert.DeserializeObject(e.Message, type)
                    : (Event)JsonConvert.DeserializeObject(e.Message, typeof(Event));

            lock (_syncRoot)
            {
                if (_dispatcher == null)
                    return;

                _dispatcher.QueueAction(() =>
                {
                    try
                    {
                        FireEvent(evnt.Type, evnt, this);
                    }
                    catch(Exception ex)
                    {
                        // Handle any exceptions that were thrown by the invoked event handler
                        if (!UnhandledException(this, ex))
                        {
                            Console.WriteLine("The event listener " + evnt.Type.ToString() + " cause an exeption: " + ex.Message);
                        }
                    }
                });
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
            _eventProducer.Connect(_subscribeAllEvents);
        }



        IAriDispatcher CreateDispatcher()
        {
            switch (EventDispatchingStrategy)
            {
                case EventDispatchingStrategy.DedicatedThread: return new DedicatedThreadDispatcher();
                case EventDispatchingStrategy.ThreadPool: return new ThreadPoolDispatcher();
                case EventDispatchingStrategy.AsyncTask: return new AsyncDispatcher();
            }

            throw new AriException(EventDispatchingStrategy.ToString());
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

            _eventProducer.Connect(_subscribeAllEvents);
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