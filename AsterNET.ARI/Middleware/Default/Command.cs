using System;
using RestSharp;
using RestSharp.Authenticators;

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

            Request = new RestRequest(path) {RequestFormat = DataFormat.Json};
        }


        public string UniqueId { get; set; }
        public string Url { get; set; }

        public string Method
        {
            get => Request.Method.ToString();
            set => Request.Method = (RestSharp.Method) Enum.Parse(typeof (RestSharp.Method), value);
        }

        public void AddUrlSegment(string segName, string value)
        {
            Request.AddUrlSegment(segName, value);
        }

        public void AddBody(object body)
        {
            Request.AddJsonBody(body);
        }

        public void AddParameter(string name, object value)
        {
            Request.AddParameter(name, value, ParameterType.QueryString);
        }
    }
}
