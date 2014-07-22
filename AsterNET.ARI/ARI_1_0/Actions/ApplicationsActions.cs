/*
	AsterNET ARI Framework
	Automatically generated file @ 22/07/2014 19:01:02
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;
using AsterNET.ARI;
using RestSharp;

namespace AsterNET.ARI.Actions
{
	
	public class ApplicationsActions : ARIBaseAction
	{

		public ApplicationsActions(StasisEndpoint endPoint)
			: base(endPoint)
		{}

		/// <summary>
		/// List all applications.. 
		/// </summary>
		public List<Application> List()
		{
			string path = "/applications";
			var request = GetNewRequest(path, Method.GET);

			var response = Client.Execute<List<Application>>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;

			switch((int)response.StatusCode)
            {
				default:
					// Unknown server response
					throw new ARIException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
		/// <summary>
		/// Get details of an application.. 
		/// </summary>
		/// <param name="applicationName">Application's name</param>
		public Application Get(string applicationName)
		{
			string path = "/applications/{applicationName}";
			var request = GetNewRequest(path, Method.GET);
			request.AddUrlSegment("applicationName", applicationName);

			var response = Client.Execute<Application>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;

			switch((int)response.StatusCode)
            {
				case 404:
					throw new ARIException("Application does not exist.");
					break;
				default:
					// Unknown server response
					throw new ARIException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
		/// <summary>
		/// Subscribe an application to a event source.. Returns the state of the application after the subscriptions have changed
		/// </summary>
		/// <param name="applicationName">Application's name</param>
		/// <param name="eventSource">URI for event source (channel:{channelId}, bridge:{bridgeId}, endpoint:{tech}/{resource}, deviceState:{deviceName}</param>
		public Application Subscribe(string applicationName, string eventSource)
		{
			string path = "/applications/{applicationName}/subscription";
			var request = GetNewRequest(path, Method.POST);
			request.AddUrlSegment("applicationName", applicationName);
			request.AddParameter("eventSource", eventSource, ParameterType.QueryString);

			var response = Client.Execute<Application>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;

			switch((int)response.StatusCode)
            {
				case 400:
					throw new ARIException("Missing parameter.");
					break;
				case 404:
					throw new ARIException("Application does not exist.");
					break;
				case 422:
					throw new ARIException("Event source does not exist.");
					break;
				default:
					// Unknown server response
					throw new ARIException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
		/// <summary>
		/// Unsubscribe an application from an event source.. Returns the state of the application after the subscriptions have changed
		/// </summary>
		/// <param name="applicationName">Application's name</param>
		/// <param name="eventSource">URI for event source (channel:{channelId}, bridge:{bridgeId}, endpoint:{tech}/{resource}, deviceState:{deviceName}</param>
		public Application Unsubscribe(string applicationName, string eventSource)
		{
			string path = "/applications/{applicationName}/subscription";
			var request = GetNewRequest(path, Method.DELETE);
			request.AddUrlSegment("applicationName", applicationName);
			request.AddParameter("eventSource", eventSource, ParameterType.QueryString);

			var response = Client.Execute<Application>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;

			switch((int)response.StatusCode)
            {
				case 400:
					throw new ARIException("Missing parameter; event source scheme not recognized.");
					break;
				case 404:
					throw new ARIException("Application does not exist.");
					break;
				case 409:
					throw new ARIException("Application not subscribed to event source.");
					break;
				case 422:
					throw new ARIException("Event source does not exist.");
					break;
				default:
					// Unknown server response
					throw new ARIException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
	}
}

