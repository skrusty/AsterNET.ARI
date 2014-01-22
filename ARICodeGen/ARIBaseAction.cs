using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace AsterNET.ARI
{
    public class ARIBaseAction
    {
        protected RestClient Client;
        private StasisEndpoint Endpoint;

        public ARIBaseAction(StasisEndpoint endPoint)
        {
            this.Client = new RestClient(endPoint.ARIEndPoint);
            this.Client.Authenticator = new HttpBasicAuthenticator(endPoint.Username, endPoint.Password);
            this.Endpoint = endPoint;
        }

        /// <summary>
        /// Returns request object pre-populated with Stasis Information
        /// </summary>
        /// <returns></returns>
        protected RestRequest GetNewRequest(string requestString, Method method)
        {
            RestRequest rtn = new RestRequest(requestString, method);
            return rtn;
        }

    }
}
