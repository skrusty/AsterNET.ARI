/*
   AsterNET ARI Framework
   Automatically generated file @ 6/21/2023 2:39:14 PM
*/
using System.Collections.Generic;
using System.Linq;
using AsterNET.ARI.Middleware;
using AsterNET.ARI.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AsterNET.ARI.Actions
{

    public class ApplicationsActions : ARIBaseAction, IApplicationsActions
    {

        public ApplicationsActions(IActionConsumer consumer)
            : base(consumer)
        { }

        /// <summary>
        /// List all applications.. 
        /// </summary>
        public virtual List<Application> List()
        {
            string path = "applications";
            var request = GetNewRequest(path, HttpMethod.GET);

            var response = Execute<List<Application>>(request);

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
        /// Get details of an application.. 
        /// </summary>
        /// <param name="applicationName">Application's name</param>
        public virtual Application Get(string applicationName)
        {
            string path = "applications/{applicationName}";
            var request = GetNewRequest(path, HttpMethod.GET);
            if (applicationName != null)
                request.AddUrlSegment("applicationName", applicationName);

            var response = Execute<Application>(request);

            if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
                return response.Data;
            switch ((int)response.StatusCode)
            {
                case 404:
                    throw new AriException("Application does not exist.", (int)response.StatusCode);
                default:
                    // Unknown server response
                    throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
        }
        /// <summary>
        /// Subscribe an application to a event source.. Returns the state of the application after the subscriptions have changed
        /// </summary>
        /// <param name="applicationName">Application's name</param>
        /// <param name="eventSource">URI for event source (channel:{channelId}, bridge:{bridgeId}, endpoint:{tech}[/{resource}], deviceState:{deviceName}</param>
        public virtual Application Subscribe(string applicationName, string eventSource)
        {
            string path = "applications/{applicationName}/subscription";
            var request = GetNewRequest(path, HttpMethod.POST);
            if (applicationName != null)
                request.AddUrlSegment("applicationName", applicationName);
            if (eventSource != null)
                request.AddParameter("eventSource", eventSource, ParameterType.QueryString);

            var response = Execute<Application>(request);

            if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
                return response.Data;
            switch ((int)response.StatusCode)
            {
                case 400:
                    throw new AriException("Missing parameter.", (int)response.StatusCode);
                case 404:
                    throw new AriException("Application does not exist.", (int)response.StatusCode);
                case 422:
                    throw new AriException("Event source does not exist.", (int)response.StatusCode);
                default:
                    // Unknown server response
                    throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
        }
        /// <summary>
        /// Unsubscribe an application from an event source.. Returns the state of the application after the subscriptions have changed
        /// </summary>
        /// <param name="applicationName">Application's name</param>
        /// <param name="eventSource">URI for event source (channel:{channelId}, bridge:{bridgeId}, endpoint:{tech}[/{resource}], deviceState:{deviceName}</param>
        public virtual Application Unsubscribe(string applicationName, string eventSource)
        {
            string path = "applications/{applicationName}/subscription";
            var request = GetNewRequest(path, HttpMethod.DELETE);
            if (applicationName != null)
                request.AddUrlSegment("applicationName", applicationName);
            if (eventSource != null)
                request.AddParameter("eventSource", eventSource, ParameterType.QueryString);

            var response = Execute<Application>(request);

            if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
                return response.Data;
            switch ((int)response.StatusCode)
            {
                case 400:
                    throw new AriException("Missing parameter; event source scheme not recognized.", (int)response.StatusCode);
                case 404:
                    throw new AriException("Application does not exist.", (int)response.StatusCode);
                case 409:
                    throw new AriException("Application not subscribed to event source.", (int)response.StatusCode);
                case 422:
                    throw new AriException("Event source does not exist.", (int)response.StatusCode);
                default:
                    // Unknown server response
                    throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
        }
        /// <summary>
        /// Filter application events types.. Allowed and/or disallowed event type filtering can be done. The body (parameter) should specify a JSON key/value object that describes the type of event filtering needed. One, or both of the following keys can be designated:<br /><br />"allowed" - Specifies an allowed list of event types<br />"disallowed" - Specifies a disallowed list of event types<br /><br />Further, each of those key's value should be a JSON array that holds zero, or more JSON key/value objects. Each of these objects must contain the following key with an associated value:<br /><br />"type" - The type name of the event to filter<br /><br />The value must be the string name (case sensitive) of the event type that needs filtering. For example:<br /><br />{ "allowed": [ { "type": "StasisStart" }, { "type": "StasisEnd" } ] }<br /><br />As this specifies only an allowed list, then only those two event type messages are sent to the application. No other event messages are sent.<br /><br />The following rules apply:<br /><br />* If the body is empty, both the allowed and disallowed filters are set empty.<br />* If both list types are given then both are set to their respective values (note, specifying an empty array for a given type sets that type to empty).<br />* If only one list type is given then only that type is set. The other type is not updated.<br />* An empty "allowed" list means all events are allowed.<br />* An empty "disallowed" list means no events are disallowed.<br />* Disallowed events take precedence over allowed events if the event type is specified in both lists.
        /// </summary>
        /// <param name="applicationName">Application's name</param>
        /// <param name="filter">Specify which event types to allow/disallow</param>
        public virtual Application Filter(string applicationName, object filter = null)
        {
            string path = "applications/{applicationName}/eventFilter";
            var request = GetNewRequest(path, HttpMethod.PUT);
            if (applicationName != null)
                request.AddUrlSegment("applicationName", applicationName);
            if (filter != null)
            {
                request.AddParameter("application/json", new { filter = filter }, ParameterType.RequestBody);
            }

            var response = Execute<Application>(request);

            if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
                return response.Data;
            switch ((int)response.StatusCode)
            {
                case 400:
                    throw new AriException("Bad request.", (int)response.StatusCode);
                case 404:
                    throw new AriException("Application does not exist.", (int)response.StatusCode);
                default:
                    // Unknown server response
                    throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
        }

        /// <summary>
        /// List all applications.. 
        /// </summary>
        public virtual async Task<List<Application>> ListAsync()
        {
            string path = "applications";
            var request = GetNewRequest(path, HttpMethod.GET);

            var response = await ExecuteTask<List<Application>>(request);

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
        /// Get details of an application.. 
        /// </summary>
        public virtual async Task<Application> GetAsync(string applicationName)
        {
            string path = "applications/{applicationName}";
            var request = GetNewRequest(path, HttpMethod.GET);
            if (applicationName != null)
                request.AddUrlSegment("applicationName", applicationName);

            var response = await ExecuteTask<Application>(request);

            if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
                return response.Data;
            switch ((int)response.StatusCode)
            {
                case 404:
                    throw new AriException("Application does not exist.", (int)response.StatusCode);
                default:
                    // Unknown server response
                    throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
        }
        /// <summary>
        /// Subscribe an application to a event source.. Returns the state of the application after the subscriptions have changed
        /// </summary>
        public virtual async Task<Application> SubscribeAsync(string applicationName, string eventSource)
        {
            string path = "applications/{applicationName}/subscription";
            var request = GetNewRequest(path, HttpMethod.POST);
            if (applicationName != null)
                request.AddUrlSegment("applicationName", applicationName);
            if (eventSource != null)
                request.AddParameter("eventSource", eventSource, ParameterType.QueryString);

            var response = await ExecuteTask<Application>(request);

            if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
                return response.Data;
            switch ((int)response.StatusCode)
            {
                case 400:
                    throw new AriException("Missing parameter.", (int)response.StatusCode);
                case 404:
                    throw new AriException("Application does not exist.", (int)response.StatusCode);
                case 422:
                    throw new AriException("Event source does not exist.", (int)response.StatusCode);
                default:
                    // Unknown server response
                    throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
        }
        /// <summary>
        /// Unsubscribe an application from an event source.. Returns the state of the application after the subscriptions have changed
        /// </summary>
        public virtual async Task<Application> UnsubscribeAsync(string applicationName, string eventSource)
        {
            string path = "applications/{applicationName}/subscription";
            var request = GetNewRequest(path, HttpMethod.DELETE);
            if (applicationName != null)
                request.AddUrlSegment("applicationName", applicationName);
            if (eventSource != null)
                request.AddParameter("eventSource", eventSource, ParameterType.QueryString);

            var response = await ExecuteTask<Application>(request);

            if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
                return response.Data;
            switch ((int)response.StatusCode)
            {
                case 400:
                    throw new AriException("Missing parameter; event source scheme not recognized.", (int)response.StatusCode);
                case 404:
                    throw new AriException("Application does not exist.", (int)response.StatusCode);
                case 409:
                    throw new AriException("Application not subscribed to event source.", (int)response.StatusCode);
                case 422:
                    throw new AriException("Event source does not exist.", (int)response.StatusCode);
                default:
                    // Unknown server response
                    throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
        }
        /// <summary>
        /// Filter application events types.. Allowed and/or disallowed event type filtering can be done. The body (parameter) should specify a JSON key/value object that describes the type of event filtering needed. One, or both of the following keys can be designated:<br /><br />"allowed" - Specifies an allowed list of event types<br />"disallowed" - Specifies a disallowed list of event types<br /><br />Further, each of those key's value should be a JSON array that holds zero, or more JSON key/value objects. Each of these objects must contain the following key with an associated value:<br /><br />"type" - The type name of the event to filter<br /><br />The value must be the string name (case sensitive) of the event type that needs filtering. For example:<br /><br />{ "allowed": [ { "type": "StasisStart" }, { "type": "StasisEnd" } ] }<br /><br />As this specifies only an allowed list, then only those two event type messages are sent to the application. No other event messages are sent.<br /><br />The following rules apply:<br /><br />* If the body is empty, both the allowed and disallowed filters are set empty.<br />* If both list types are given then both are set to their respective values (note, specifying an empty array for a given type sets that type to empty).<br />* If only one list type is given then only that type is set. The other type is not updated.<br />* An empty "allowed" list means all events are allowed.<br />* An empty "disallowed" list means no events are disallowed.<br />* Disallowed events take precedence over allowed events if the event type is specified in both lists.
        /// </summary>
        public virtual async Task<Application> FilterAsync(string applicationName, object filter = null)
        {
            string path = "applications/{applicationName}/eventFilter";
            var request = GetNewRequest(path, HttpMethod.PUT);
            if (applicationName != null)
                request.AddUrlSegment("applicationName", applicationName);
            if (filter != null)
            {
                request.AddParameter("application/json", new { filter = filter }, ParameterType.RequestBody);
            }

            var response = await ExecuteTask<Application>(request);

            if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
                return response.Data;
            switch ((int)response.StatusCode)
            {
                case 400:
                    throw new AriException("Bad request.", (int)response.StatusCode);
                case 404:
                    throw new AriException("Application does not exist.", (int)response.StatusCode);
                default:
                    // Unknown server response
                    throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
        }
    }
}

