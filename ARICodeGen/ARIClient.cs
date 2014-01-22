using AsterNET.ARI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;
using WebSocket4Net;

namespace AsterNET.ARI
{
    /// <summary>
    /// 
    /// </summary>
    public class ARIClient : BaseARIClient_1_0_0
    {
        private WebSocket _client;
        private StasisEndpoint EndPoint;
        private string Application;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="application"></param>
        public ARIClient(StasisEndpoint endPoint, string application)
        {
            EndPoint = endPoint;
            Application = application;
        }

        #region Public Methods
        public void Connect()
        {
            try
            {
                _client = new WebSocket(string.Format("ws://{0}:{3}/ari/events?app={1}&api_key={2}",
                    EndPoint.Host, Application, string.Format("{0}:{1}", EndPoint.Username, EndPoint.Password), EndPoint.Port.ToString()));

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

        }

        private void _client_Opened(object sender, EventArgs e)
        {

        }

        private void _client_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            // load the message
            var jsonMsg = (Newtonsoft.Json.Linq.JObject)JToken.Parse(e.Message);
            var eventName = jsonMsg.SelectToken("type").Value<string>();
            var type = Type.GetType("AsterNET.ARI.Models." + eventName + "Event");
            if (type != null)
                FireEvent(eventName, JsonConvert.DeserializeObject(value: e.Message, type: type));
            else
                FireEvent(eventName, JsonConvert.DeserializeObject(value: e.Message, type: typeof(AsterNET.ARI.Models.Event)));
        } 
        #endregion
        
    }

}
