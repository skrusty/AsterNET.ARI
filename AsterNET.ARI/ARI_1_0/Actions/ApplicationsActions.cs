/*
	AsterNET ARI Framework
	Automatically generated file @ 10.10.2019 19:36:54
*/
using System.Collections.Generic;
using System.Linq;
using AsterNET.ARI.Middleware;
using AsterNET.ARI.Models;
using System.Threading.Tasks;

namespace AsterNET.ARI.Actions
{
	
	public class ApplicationsActions : ARIBaseAction, IApplicationsActions
	{

		public ApplicationsActions(IActionConsumer consumer)
			: base(consumer)
		{}

		/// <summary>
		/// List all applications.. 
		/// </summary>
		public List<Application> List()
		{
			string path = "applications";
			var request = GetNewRequest(path, HttpMethod.GET);

			var response = Execute<List<Application>>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
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
		public Application Get(string applicationName)
		{
			string path = "applications/{applicationName}";
			var request = GetNewRequest(path, HttpMethod.GET);
			if(applicationName != null)
				request.AddUrlSegment("applicationName", applicationName);

			var response = Execute<Application>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
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
		public Application Subscribe(string applicationName, string eventSource)
		{
			string path = "applications/{applicationName}/subscription";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(applicationName != null)
				request.AddUrlSegment("applicationName", applicationName);
			if(eventSource != null)
				request.AddParameter("eventSource", eventSource);

			var response = Execute<Application>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
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
		public Application Unsubscribe(string applicationName, string eventSource)
		{
			string path = "applications/{applicationName}/subscription";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(applicationName != null)
				request.AddUrlSegment("applicationName", applicationName);
			if(eventSource != null)
				request.AddParameter("eventSource", eventSource);

			var response = Execute<Application>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
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
		/// List all applications.. 
		/// </summary>
		public async Task<List<Application>> ListAsync()
		{
			string path = "applications";
			var request = GetNewRequest(path, HttpMethod.GET);

			var response = await ExecuteTask<List<Application>>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Get details of an application.. 
		/// </summary>
		public async Task<Application> GetAsync(string applicationName)
		{
			string path = "applications/{applicationName}";
			var request = GetNewRequest(path, HttpMethod.GET);
			if(applicationName != null)
				request.AddUrlSegment("applicationName", applicationName);

			var response = await ExecuteTask<Application>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
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
		public async Task<Application> SubscribeAsync(string applicationName, string eventSource)
		{
			string path = "applications/{applicationName}/subscription";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(applicationName != null)
				request.AddUrlSegment("applicationName", applicationName);
			if(eventSource != null)
				request.AddParameter("eventSource", eventSource);

			var response = await ExecuteTask<Application>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
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
		public async Task<Application> UnsubscribeAsync(string applicationName, string eventSource)
		{
			string path = "applications/{applicationName}/subscription";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(applicationName != null)
				request.AddUrlSegment("applicationName", applicationName);
			if(eventSource != null)
				request.AddParameter("eventSource", eventSource);

			var response = await ExecuteTask<Application>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
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
	}
}

