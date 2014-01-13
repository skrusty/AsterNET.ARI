using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using WebSocket4Net;

namespace AsterNET.ARI.TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = "username";
            string password = "test";
            string uri = "192.168.1.71";
            string port = "8088";
            
            WebSocket websocket = new WebSocket(string.Format("ws://{0}:{1}/ari/events?app={2}&api_key={3}",
                uri, port, "hello", string.Format("{0}:{1}", username, password)));

            websocket.MessageReceived += websocket_MessageReceived;
            websocket.Open();
            
            Console.ReadKey();

        }

        static void websocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Console.WriteLine(e.Message);


        }

        public static string JsonSerializer<T>(T t)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, t);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return jsonString;
        }
        /// <summary>
        /// JSON Deserialization
        /// </summary>
        public static T JsonDeserialize<T>(string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)ser.ReadObject(ms);
            return obj;
        }

        
    }
}
