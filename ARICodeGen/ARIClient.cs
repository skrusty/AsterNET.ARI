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
    public partial class ARIClient
    {
        private WebSocket _client;

        public ARIClient()
        {
            
        }
        public void Connect(string uri, string username, string password, string application)
        {

            _client = new WebSocket(string.Format("ws://{0}/ari/events?app={1}&api_key={2}",
                uri, application, string.Format("{0}:{1}", username, password)));

            _client.MessageReceived += _client_MessageReceived;
            _client.Opened += _client_Opened;
            _client.Error += _client_Error;
            _client.DataReceived += _client_DataReceived;
            _client.Closed += _client_Closed;

            _client.Open();
        }

        public void Disconnect()
        {
            _client.Close();
        }

        public bool Connected
        {
            get { return _client.State == WebSocketState.Open; }
        }

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
            var eventArgs = JsonConvert.DeserializeObject(value: e.Message, type: Type.GetType("AsterNET.ARI.Models." + eventName + "Event"));

            FireEvent(eventName, eventArgs);
        }
        
    }

    public class MessageHandler
    {
        public string EventName;
        public Type EventClass;
    }
}
