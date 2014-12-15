using AsterNET.ARI.Actions;
using AsterNET.ARI.Middleware;
using AsterNET.ARI.Middleware.Default;
using AsterNET.ARI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading;
using WebSocket4Net;

namespace AsterNET.ARI
{
    /// <summary>
    /// 
    /// </summary>
    public class ARIClient : BaseARIClient_1_0_0
    {
        public delegate void ConnectionStateChangedHandler(object sender);
        public event ConnectionStateChangedHandler OnConnectionStateChanged;

        #region Private Fields
        private readonly IActionConsumer _actionConsumer;
        private readonly IEventProducer _eventProducer;

        private bool _autoReconnect;
        private TimeSpan _autoReconnectDelay;
        private ConnectionState _lastKnownState;

        private delegate void ARIEventHandler(object sender, Event e);
        private event ARIEventHandler InternalEvent; 
        #endregion

        #region Public Properties

        public IAsteriskActions Asterisk
        {
            get { return _actionConsumer.Asterisk; }
        }
        public IApplicationsActions Applications {
            get { return _actionConsumer.Applications; }
        }
        public IBridgesActions Bridges {
            get { return _actionConsumer.Bridges; }
        }
        public IChannelsActions Channels {
            get { return _actionConsumer.Channels; }
        }
        public IDeviceStatesActions DeviceStates {
            get { return _actionConsumer.DeviceStates; }
        }
        public IEndpointsActions Endpoints {
            get { return _actionConsumer.Endpoints; }
        }
        public IEventsActions Events {
            get { return _actionConsumer.Events; }
        }
        public IPlaybacksActions Playbacks {
            get { return _actionConsumer.Playbacks; }
        }
        public IRecordingsActions Recordings {
            get { return _actionConsumer.Recordings; }
        }
        public ISoundsActions Sounds {
            get { return _actionConsumer.Sounds; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="application"></param>
        public ARIClient(StasisEndpoint endPoint, string application)
        {
            // Use Default Middleware
            _eventProducer = new WebSocketEventProducer(endPoint, application);
            _actionConsumer = new RESTActionConsumer(endPoint);

            Init();
        }

        public ARIClient(IActionConsumer actionConsumer, IEventProducer eventProducer, string application)
        {
            _actionConsumer = actionConsumer;
            _eventProducer = eventProducer;

            Init();
        }

        #endregion

        #region Internal Methods

        internal void Init()
        {
            // Setup Event Handlers
            InternalEvent += ARIClient_internalEvent;
            _eventProducer.OnMessageReceived += _eventProducer_OnMessageReceived;
            _eventProducer.OnConnectionStateChanged += _eventProducer_OnConnectionStateChanged;
        }

        void _eventProducer_OnConnectionStateChanged(object sender, EventArgs e)
        {
            if(_eventProducer.State !=ConnectionState.Open)
                Reconnect();
        }
        void _eventProducer_OnMessageReceived(object sender, MessageEventArgs e)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine(e.Message);
#endif
            // load the message
            var jsonMsg = (JObject)JToken.Parse(e.Message);
            var eventName = jsonMsg.SelectToken("type").Value<string>();
            var type = Type.GetType("AsterNET.ARI.Models." + eventName + "Event");
            if (type != null)
                InternalEvent.BeginInvoke(this, (Event)JsonConvert.DeserializeObject(value: e.Message, type: type), eventComplete, null);
            else
                InternalEvent.BeginInvoke(this, (Event)JsonConvert.DeserializeObject(value: e.Message, type: typeof(Event)), eventComplete, null);
        }

        private void ARIClient_internalEvent(object sender, Event e)
        {
            FireEvent(e.Type, e);
        }

        private void eventComplete(IAsyncResult result)
        {
            var ar = (System.Runtime.Remoting.Messaging.AsyncResult)result;
            var invokedMethod = (ARIEventHandler)ar.AsyncDelegate;

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
                if(_autoReconnectDelay!=TimeSpan.Zero)
                    Thread.Sleep(_autoReconnectDelay);
                Connect();
            }
        }

        #endregion

        #region Public Methods
        public void Connect(bool autoReconnect = true, int autoReconnectDelay = 5)
        {
            _eventProducer.Connect();
        }

        public void Disconnect()
        {
            _autoReconnect = false;
            _eventProducer.Disconnect();
        }

        public bool Connected
        {
            get { return _eventProducer.State == ConnectionState.Open; }
        }
        #endregion


        protected virtual void RaiseOnConnectionStateChanged()
        {
            if (_eventProducer.State == _lastKnownState) return;

            _lastKnownState = _eventProducer.State;
            var handler = OnConnectionStateChanged;
            if (handler != null) handler(this);
        }
    }
}
