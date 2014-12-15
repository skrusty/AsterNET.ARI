using RestSharp;

namespace AsterNET.ARI
{
    public class ARIBaseAction
    {
        protected RestClient Client;
        private StasisEndpoint _endpoint;

        public ARIBaseAction(StasisEndpoint endPoint)
        {
            Client = new RestClient(endPoint.ARIEndPoint)
            {
                Authenticator = new HttpBasicAuthenticator(endPoint.Username, endPoint.Password)
            };
            _endpoint = endPoint;
        }

        /// <summary>
        /// Returns request object pre-populated with Stasis Information
        /// </summary>
        /// <returns></returns>
        protected RestRequest GetNewRequest(string requestString, Method method)
        {
            var rtn = new RestRequest(requestString, method);
            return rtn;
        }

    }
}
