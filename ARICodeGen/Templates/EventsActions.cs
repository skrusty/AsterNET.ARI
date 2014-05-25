/*
	AsterNET ARI Framework
	Automatically generated file @ 25/05/2014 20:39:48
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;
using AsterNET.ARI;
using RestSharp;

namespace AsterNET.ARI.Actions
{
	
	public class EventsActions : ARIBaseAction
	{

		public EventsActions(StasisEndpoint endPoint)
			: base(endPoint)
		{}

		/// <summary>
		/// WebSocket connection for events.
		/// </summary>
		/// <param name="app">Applications to subscribe to.</param>
		public Message EventWebsocket(string app)
		{
			string path = "/events";
			var request = GetNewRequest(path, Method.GET);
			request.AddParameter("app", app, ParameterType.QueryString);

			var response = Client.Execute<Message>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;

			switch((int)response.StatusCode)
            {
				default:
					// Unknown server response
					throw new ARIException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
	}
}

