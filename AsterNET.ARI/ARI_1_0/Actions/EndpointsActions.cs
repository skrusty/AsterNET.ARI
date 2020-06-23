/*
   AsterNET ARI Framework
   Automatically generated file @ 6/23/2020 3:09:38 PM
*/
using System.Collections.Generic;
using System.Linq;
using AsterNET.ARI.Middleware;
using AsterNET.ARI.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AsterNET.ARI.Actions
{

    public class EndpointsActions : ARIBaseAction, IEndpointsActions
    {

        public EndpointsActions(IActionConsumer consumer)
            : base(consumer)
        { }

        /// <summary>
        /// List all endpoints.. 
        /// </summary>
        public List<Endpoint> List()
        {
            string path = "endpoints";
            var request = GetNewRequest(path, HttpMethod.GET);

            var response = Execute<List<Endpoint>>(request);

            if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
                return response.Data;
            switch ((int)response.StatusCode)
            {
                default:
                    // Unknown server response
                    throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
        }
        /// <summary>
        /// Send a message to some technology URI or endpoint.. 
        /// </summary>
        /// <param name="to">The endpoint resource or technology specific URI to send the message to. Valid resources are sip, pjsip, and xmpp.</param>
        /// <param name="from">The endpoint resource or technology specific identity to send this message from. Valid resources are sip, pjsip, and xmpp.</param>
        /// <param name="body">The body of the message</param>
        public void SendMessage(string to, string from, string body = null, Dictionary<string, string> variables = null)
        {
            string path = "endpoints/sendMessage";
            var request = GetNewRequest(path, HttpMethod.PUT);
            if (to != null)
                request.AddParameter("to", to, ParameterType.QueryString);
            if (from != null)
                request.AddParameter("from", from, ParameterType.QueryString);
            if (body != null)
                request.AddParameter("body", body, ParameterType.QueryString);
            if (variables != null)
            {
                request.AddParameter("application/json", new { variables = variables }, ParameterType.RequestBody);
            }
            var response = Execute(request);
            if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
                return;
            switch ((int)response.StatusCode)
            {
                case 400:
                    throw new AriException("Invalid parameters for sending a message.", (int)response.StatusCode);
                case 404:
                    throw new AriException("Endpoint not found", (int)response.StatusCode);
                default:
                    // Unknown server response
                    throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
        }
        /// <summary>
        /// List available endoints for a given endpoint technology.. 
        /// </summary>
        /// <param name="tech">Technology of the endpoints (sip,iax2,...)</param>
        public List<Endpoint> ListByTech(string tech)
        {
            string path = "endpoints/{tech}";
            var request = GetNewRequest(path, HttpMethod.GET);
            if (tech != null)
                request.AddUrlSegment("tech", tech);

            var response = Execute<List<Endpoint>>(request);

            if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
                return response.Data;
            switch ((int)response.StatusCode)
            {
                case 404:
                    throw new AriException("Endpoints not found", (int)response.StatusCode);
                default:
                    // Unknown server response
                    throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
        }
        /// <summary>
        /// Details for an endpoint.. 
        /// </summary>
        /// <param name="tech">Technology of the endpoint</param>
        /// <param name="resource">ID of the endpoint</param>
        public Endpoint Get(string tech, string resource)
        {
            string path = "endpoints/{tech}/{resource}";
            var request = GetNewRequest(path, HttpMethod.GET);
            if (tech != null)
                request.AddUrlSegment("tech", tech);
            if (resource != null)
                request.AddUrlSegment("resource", resource);

            var response = Execute<Endpoint>(request);

            if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
                return response.Data;
            switch ((int)response.StatusCode)
            {
                case 400:
                    throw new AriException("Invalid parameters for sending a message.", (int)response.StatusCode);
                case 404:
                    throw new AriException("Endpoints not found", (int)response.StatusCode);
                default:
                    // Unknown server response
                    throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
        }
        /// <summary>
        /// Send a message to some endpoint in a technology.. 
        /// </summary>
        /// <param name="tech">Technology of the endpoint</param>
        /// <param name="resource">ID of the endpoint</param>
        /// <param name="from">The endpoint resource or technology specific identity to send this message from. Valid resources are sip, pjsip, and xmpp.</param>
        /// <param name="body">The body of the message</param>
        public void SendMessageToEndpoint(string tech, string resource, string from, string body = null, Dictionary<string, string> variables = null)
        {
            string path = "endpoints/{tech}/{resource}/sendMessage";
            var request = GetNewRequest(path, HttpMethod.PUT);
            if (tech != null)
                request.AddUrlSegment("tech", tech);
            if (resource != null)
                request.AddUrlSegment("resource", resource);
            if (from != null)
                request.AddParameter("from", from, ParameterType.QueryString);
            if (body != null)
                request.AddParameter("body", body, ParameterType.QueryString);
            if (variables != null)
            {
                request.AddParameter("application/json", new { variables = variables }, ParameterType.RequestBody);
            }
            var response = Execute(request);
            if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
                return;
            switch ((int)response.StatusCode)
            {
                case 400:
                    throw new AriException("Invalid parameters for sending a message.", (int)response.StatusCode);
                case 404:
                    throw new AriException("Endpoint not found", (int)response.StatusCode);
                default:
                    // Unknown server response
                    throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
        }

        /// <summary>
        /// List all endpoints.. 
        /// </summary>
        public async Task<List<Endpoint>> ListAsync()
        {
            string path = "endpoints";
            var request = GetNewRequest(path, HttpMethod.GET);

            var response = await ExecuteTask<List<Endpoint>>(request);

            if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
                return response.Data;
            switch ((int)response.StatusCode)
            {
                default:
                    // Unknown server response
                    throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
        }
        /// <summary>
        /// Send a message to some technology URI or endpoint.. 
        /// </summary>
        public async Task SendMessageAsync(string to, string from, string body = null, Dictionary<string, string> variables = null)
        {
            string path = "endpoints/sendMessage";
            var request = GetNewRequest(path, HttpMethod.PUT);
            if (to != null)
                request.AddParameter("to", to, ParameterType.QueryString);
            if (from != null)
                request.AddParameter("from", from, ParameterType.QueryString);
            if (body != null)
                request.AddParameter("body", body, ParameterType.QueryString);
            if (variables != null)
            {
                request.AddParameter("application/json", new { variables = variables }, ParameterType.RequestBody);
            }
            var response = await ExecuteTask(request);
            if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
                return;
            switch ((int)response.StatusCode)
            {
                case 400:
                    throw new AriException("Invalid parameters for sending a message.", (int)response.StatusCode);
                case 404:
                    throw new AriException("Endpoint not found", (int)response.StatusCode);
                default:
                    // Unknown server response
                    throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
        }
        /// <summary>
        /// List available endoints for a given endpoint technology.. 
        /// </summary>
        public async Task<List<Endpoint>> ListByTechAsync(string tech)
        {
            string path = "endpoints/{tech}";
            var request = GetNewRequest(path, HttpMethod.GET);
            if (tech != null)
                request.AddUrlSegment("tech", tech);

            var response = await ExecuteTask<List<Endpoint>>(request);

            if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
                return response.Data;
            switch ((int)response.StatusCode)
            {
                case 404:
                    throw new AriException("Endpoints not found", (int)response.StatusCode);
                default:
                    // Unknown server response
                    throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
        }
        /// <summary>
        /// Details for an endpoint.. 
        /// </summary>
        public async Task<Endpoint> GetAsync(string tech, string resource)
        {
            string path = "endpoints/{tech}/{resource}";
            var request = GetNewRequest(path, HttpMethod.GET);
            if (tech != null)
                request.AddUrlSegment("tech", tech);
            if (resource != null)
                request.AddUrlSegment("resource", resource);

            var response = await ExecuteTask<Endpoint>(request);

            if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
                return response.Data;
            switch ((int)response.StatusCode)
            {
                case 400:
                    throw new AriException("Invalid parameters for sending a message.", (int)response.StatusCode);
                case 404:
                    throw new AriException("Endpoints not found", (int)response.StatusCode);
                default:
                    // Unknown server response
                    throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
        }
        /// <summary>
        /// Send a message to some endpoint in a technology.. 
        /// </summary>
        public async Task SendMessageToEndpointAsync(string tech, string resource, string from, string body = null, Dictionary<string, string> variables = null)
        {
            string path = "endpoints/{tech}/{resource}/sendMessage";
            var request = GetNewRequest(path, HttpMethod.PUT);
            if (tech != null)
                request.AddUrlSegment("tech", tech);
            if (resource != null)
                request.AddUrlSegment("resource", resource);
            if (from != null)
                request.AddParameter("from", from, ParameterType.QueryString);
            if (body != null)
                request.AddParameter("body", body, ParameterType.QueryString);
            if (variables != null)
            {
                request.AddParameter("application/json", new { variables = variables }, ParameterType.RequestBody);
            }
            var response = await ExecuteTask(request);
            if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
                return;
            switch ((int)response.StatusCode)
            {
                case 400:
                    throw new AriException("Invalid parameters for sending a message.", (int)response.StatusCode);
                case 404:
                    throw new AriException("Endpoint not found", (int)response.StatusCode);
                default:
                    // Unknown server response
                    throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
        }
    }
}

