using System;
using System.Net.Sockets;
using WebSocket4Net;

namespace AsterNET.ARI.Middleware.Default
{
    public class WebSocketEventProducer : IEventProducer
    {
        private readonly StasisEndpoint _connectionInfo;
        private readonly string _application;
        private WebSocket _client;
        private WebSocketState _lastKnownState;

        public event EventHandler<MessageEventArgs> OnMessageReceived;
        public event EventHandler OnConnectionStateChanged;

        #region Constructor
        public WebSocketEventProducer(StasisEndpoint connectionInfo, string application)
        {
            _connectionInfo = connectionInfo;
            _application = application;
        } 
        #endregion

        #region Public Properties
        public ConnectionState State
        {
            get { return _client.State == WebSocketState.Open ? ConnectionState.Open : ConnectionState.Closed; }
        }

        #endregion

        #region Public Methods
        public void Connect()
        {
            try
            {
                _client = new WebSocket(string.Format("ws://{0}:{3}/ari/events?app={1}&api_key={2}",
                    _connectionInfo.Host, _application, string.Format("{0}:{1}", _connectionInfo.Username, _connectionInfo.Password), _connectionInfo.Port.ToString()));

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
            RaiseOnConnectionStateChanged();
        }

        private void _client_DataReceived(object sender, DataReceivedEventArgs e)
        {

        }

        private void _client_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            if (e.Exception is SocketException)
                RaiseOnConnectionStateChanged();
        }

        private void _client_Opened(object sender, EventArgs e)
        {
            RaiseOnConnectionStateChanged();
        }

        private void _client_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            // Raise Event
            var handler = OnMessageReceived;
            if (handler != null) handler(this, new MessageEventArgs()
            {
                Message = e.Message
            });
        }

       
        #endregion

        #region Private Methods
        protected virtual void RaiseOnConnectionStateChanged()
        {
            if (_client.State == _lastKnownState) return;

            _lastKnownState = _client.State;
            var handler = OnConnectionStateChanged;
            if (handler != null) handler(this, null);
        }

        #endregion
    }
}
