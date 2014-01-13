using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;

namespace AsterNET.ARI.Actions
{
	
	public class EventsActions
	{

		/// <summary>
		/// WebSocket connection for events.
		/// </summary>
		public Message eventWebsocket()
		{
			string httpMethod = "GET";
			string path = "/events";

			var client = new RestClient
		}

	}
}

