using AsterNET.ARI.Actions;
using AsterNET.ARI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using WebSocket4Net;

namespace AsterNET.ARI
{
    /// <summary>
    /// 
    /// </summary>
    public class ARIClient : BaseARIClient_1_0_0
    {
        private WebSocket _client;
        private readonly StasisEndpoint _endPoint;
        private readonly string _application;

        private delegate void ARIEventHandler(object sender, Event e);

        private event ARIEventHandler InternalEvent;

        #region Public Properties
        public AsteriskActions Asterisk { get; set; }
        public ApplicationsActions Applications { get; set; }
        public BridgesActions Bridges { get; set; }
        public ChannelsActions Channels { get; set; }
        public DeviceStatesActions DeviceStates { get; set; }
        public EndpointsActions Endpoints { get; set; }
        public EventsActions Events { get; set; }
        public PlaybacksActions Playbacks { get; set; }
        public RecordingsActions Recordings { get; set; }
        public SoundsActions Sounds { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="application"></param>
        public ARIClient(StasisEndpoint endPoint, string application)
        {
            _endPoint = endPoint;
            _application = application;

            Asterisk = new AsteriskActions(_endPoint);
            Applications = new ApplicationsActions(_endPoint);
            Bridges = new BridgesActions(_endPoint);
            Channels = new ChannelsActions(_endPoint);
            Endpoints = new EndpointsActions(_endPoint);
            Events = new EventsActions(_endPoint);
            Playbacks = new PlaybacksActions(_endPoint);
            Recordings = new RecordingsActions(_endPoint);
            Sounds = new SoundsActions(_endPoint);

            this.InternalEvent += ARIClient_internalEvent;
        }

        #endregion

        #region Internal Methods
        private void ARIClient_internalEvent(object sender, Event e)
        {
            FireEvent(e.Type, e);
        }

        #endregion

        #region Public Methods
        public void Connect()
        {
            try
            {
                _client = new WebSocket(string.Format("ws://{0}:{3}/ari/events?app={1}&api_key={2}",
                    _endPoint.Host, _application, string.Format("{0}:{1}", _endPoint.Username, _endPoint.Password), _endPoint.Port.ToString()));

                _client.MessageReceived += _client_MessageReceived;
                _client.Opened += _client_Opened;
                _client.Error += _client_Error;
                _client.DataReceived += _client_DataReceived;
                _client.Closed += _client_Closed;

                _client.Open();
            }
            catch (Exception ex)
            {
                throw new ARIException(ex.Message);
            }
        }

        public void Disconnect()
        {
            _client.Close();
        }

        public bool Connected
        {
            get { return _client.State == WebSocketState.Open; }
        }
        #endregion

        #region SocketEvents
        private void _client_Closed(object sender, EventArgs e)
        {

        }

        private void _client_DataReceived(object sender, DataReceivedEventArgs e)
        {

        }

        private void _client_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            throw e.Exception;
        }

        private void _client_Opened(object sender, EventArgs e)
        {

        }

        private void _client_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine(e.Message);
#endif
            // load the message
            var jsonMsg = (Newtonsoft.Json.Linq.JObject)JToken.Parse(e.Message);
            var eventName = jsonMsg.SelectToken("type").Value<string>();
            var type = Type.GetType("AsterNET.ARI.Models." + eventName + "Event");
            if (type != null)

                InternalEvent.BeginInvoke(this, (Event)JsonConvert.DeserializeObject(value: e.Message, type: type), new AsyncCallback(eventComplete), null);
            else
                InternalEvent.BeginInvoke(this, (Event)JsonConvert.DeserializeObject(value: e.Message, type: typeof(AsterNET.ARI.Models.Event)), new AsyncCallback(eventComplete), null);
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
        #endregion

    }

}
