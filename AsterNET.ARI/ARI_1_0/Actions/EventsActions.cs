/*
	AsterNET ARI Framework
	Automatically generated file @ 14/08/2016 22:14:39
*/
using System.Collections.Generic;
using System.Linq;
using AsterNET.ARI.Middleware;
using AsterNET.ARI.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AsterNET.ARI.Actions
{
	
	public class EventsActions : ARIBaseAction, IEventsActions
	{

		public EventsActions(IActionConsumer consumer)
			: base(consumer)
		{}

		/// <summary>
		/// WebSocket connection for events.. 
		/// </summary>
		/// <param name="app">Applications to subscribe to.</param>
		/// <param name="subscribeAll">Subscribe to all Asterisk events. If provided, the applications listed will be subscribed to all events, effectively disabling the application specific subscriptions. Default is 'false'.</param>
		public Message EventWebsocket(string app, bool? subscribeAll = null)
		{
			string path = "/events";
			var request = GetNewRequest(path, HttpMethod.GET);
			if(app != null)
				request.AddParameter("app", app, ParameterType.QueryString);
			if(subscribeAll != null)
				request.AddParameter("subscribeAll", subscribeAll, ParameterType.QueryString);

			var response = Execute<Message>(request);

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
		/// Generate a user event.. 
		/// </summary>
		/// <param name="eventName">Event name</param>
		/// <param name="application">The name of the application that will receive this event</param>
		/// <param name="source">URI for event source (channel:{channelId}, bridge:{bridgeId}, endpoint:{tech}/{resource}, deviceState:{deviceName}</param>
		/// <param name="variables">The "variables" key in the body object holds custom key/value pairs to add to the user event. Ex. { "variables": { "key": "value" } }</param>
		public void UserEvent(string eventName, string application, string source = null, Dictionary<string, string> variables = null)
		{
			string path = "/events/user/{eventName}";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(eventName != null)
				request.AddUrlSegment("eventName", eventName);
			if(application != null)
				request.AddParameter("application", application, ParameterType.QueryString);
			if(source != null)
				request.AddParameter("source", source, ParameterType.QueryString);
			if(variables != null)
			{
				request.AddParameter("application/json", new { variables = variables }, ParameterType.RequestBody);
			}
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Application does not exist.", (int)response.StatusCode);
				case 422:
					throw new AriException("Event source not found.", (int)response.StatusCode);
				case 400:
					throw new AriException("Invalid even tsource URI or userevent data.", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}

		/// <summary>
		/// WebSocket connection for events.. 
		/// </summary>
		public async Task<Message> EventWebsocketAsync(string app, bool? subscribeAll = null)
		{
			string path = "/events";
			var request = GetNewRequest(path, HttpMethod.GET);
			if(app != null)
				request.AddParameter("app", app, ParameterType.QueryString);
			if(subscribeAll != null)
				request.AddParameter("subscribeAll", subscribeAll, ParameterType.QueryString);

			var response = await ExecuteTask<Message>(request);

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
		/// Generate a user event.. 
		/// </summary>
		public async Task UserEventAsync(string eventName, string application, string source = null, Dictionary<string, string> variables = null)
		{
			string path = "/events/user/{eventName}";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(eventName != null)
				request.AddUrlSegment("eventName", eventName);
			if(application != null)
				request.AddParameter("application", application, ParameterType.QueryString);
			if(source != null)
				request.AddParameter("source", source, ParameterType.QueryString);
			if(variables != null)
			{
				request.AddParameter("application/json", new { variables = variables }, ParameterType.RequestBody);
			}
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Application does not exist.", (int)response.StatusCode);
				case 422:
					throw new AriException("Event source not found.", (int)response.StatusCode);
				case 400:
					throw new AriException("Invalid even tsource URI or userevent data.", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
	}
}

