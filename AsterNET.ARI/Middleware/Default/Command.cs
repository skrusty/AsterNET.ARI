using System;
using RestSharp;
using Newtonsoft.Json;

namespace AsterNET.ARI.Middleware.Default
{
    public class Command : IRestCommand
    {
        internal RestClient Client;
        internal RestRequest Request;

        public Command(StasisEndpoint info, string path)
        {
            Client = new RestClient(info.AriEndPoint)
            {
                Authenticator = new HttpBasicAuthenticator(info.Username, info.Password)
            };
            Request = new RestRequest(path);
        }


        public string UniqueId { get; set; }
        public string Url { get; set; }

        public string Method
        {
            get { return Request.Method.ToString(); }
            set { Request.Method = (RestSharp.Method) Enum.Parse(typeof (RestSharp.Method), value); }
        }


        public string Body { get; private set; }

        public void AddUrlSegment(string segName, string value)
        {
            Request.AddUrlSegment(segName, value);
        }

        public void AddParameter(string name, object value, Middleware.ParameterType type)
        {
            if (type == ParameterType.RequestBody)
            {
                Request.RequestFormat = DataFormat.Json;
                Request.AddParameter(name, JsonConvert.SerializeObject(value), (RestSharp.ParameterType)Enum.Parse(typeof(RestSharp.ParameterType), type.ToString()));
            }
            else
            {
                Request.AddParameter(name, value, (RestSharp.ParameterType)Enum.Parse(typeof(RestSharp.ParameterType), type.ToString()));
            }
        }
    }
}
