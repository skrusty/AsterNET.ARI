using System;
using System.Net.Sockets;
using SuperSocket.ClientEngine;
using WebSocket4Net;

namespace AsterNET.ARI.Middleware.Default
{
    public class WebSocketEventProducer : IEventProducer
    {
        private readonly string _application;
        private readonly StasisEndpoint _connectionInfo;
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
            get { return _client == null? ConnectionState.None : (ConnectionState)_client.State; }
        }

        #endregion

        #region Public Methods

        public bool Connected
        {
            get { return _client != null && _client.State == WebSocketState.Open; }
        }

        public void Connect(bool subscribeAll = false, bool ssl = false)
        {
            try
            {
                if (!ssl)
                {
                    _client = new WebSocket(string.Format("ws://{0}:{3}/ari/events?app={1}&subscribeAll={4}&api_key={2}",
                        _connectionInfo.Host, _application,
                        string.Format("{0}:{1}", _connectionInfo.Username, _connectionInfo.Password), _connectionInfo.Port, subscribeAll));
                }
                else
                {
                    _client = new WebSocket(string.Format("wss://{0}:{3}/ari/events?app={1}&subscribeAll={4}&api_key={2}",
                        _connectionInfo.Host, _application,
                        string.Format("{0}:{1}", _connectionInfo.Username, _connectionInfo.Password), _connectionInfo.Port, subscribeAll),
                        null, null, null, "", "", WebSocketVersion.None, null,
                        System.Security.Authentication.SslProtocols.Tls12, 0);
                }

                _client.MessageReceived += _client_MessageReceived;
                _client.Opened += _client_Opened;
                _client.Error += _client_Error;
                _client.DataReceived += _client_DataReceived;
                _client.Closed += _client_Closed;

                _client.Open();
            }
            catch (Exception ex)
            {
                throw new AriException(ex.Message);
            }
        }


        public void Disconnect()
        {
            if (_client != null)
                _client.Close();
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

        private void _client_Error(object sender, ErrorEventArgs e)
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
            if (handler != null)
                handler(this, new MessageEventArgs
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
