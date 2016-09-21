using System;
using RestSharp;
using Newtonsoft.Json;
using RestSharp.Portable;
using RestSharp.Portable.Authenticators;
using RestSharp.Portable.HttpClient;

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
            set { Request.Method = (RestSharp.Portable.Method) Enum.Parse(typeof (RestSharp.Portable.Method), value); }
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
                Request.Serializer = new RestSharp.Portable.Serializers.JsonSerializer();
                Request.AddParameter(name, JsonConvert.SerializeObject(value), (RestSharp.Portable.ParameterType)Enum.Parse(typeof(RestSharp.Portable.ParameterType), type.ToString()));
            }
            else
            {
                Request.AddParameter(name, value, (RestSharp.Portable.ParameterType)Enum.Parse(typeof(RestSharp.Portable.ParameterType), type.ToString()));
            }
        }
    }
}
