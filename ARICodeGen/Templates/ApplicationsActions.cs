using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;

namespace AsterNET.ARI.Actions
{
	
	public class ApplicationsActions
	{

		/// <summary>
		/// List all applications.
		/// </summary>
		public List<Application> list()
		{
			string httpMethod = "GET";
			string path = "/applications";

			var client = new RestClient
		}

		/// <summary>
		/// Get details of an application.
		/// </summary>
		public Application get()
		{
			string httpMethod = "GET";
			string path = "/applications/{applicationName}";

			var client = new RestClient
		}

		/// <summary>
		/// Subscribe an application to a event source.
		/// </summary>
		public Application subscribe()
		{
			string httpMethod = "POST";
			string path = "/applications/{applicationName}/subscription";

			var client = new RestClient
		}

	}
}

