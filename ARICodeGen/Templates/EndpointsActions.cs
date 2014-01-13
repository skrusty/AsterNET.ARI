using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;

namespace AsterNET.ARI.Actions
{
	
	public class EndpointsActions
	{

		/// <summary>
		/// List all endpoints.
		/// </summary>
		public List<Endpoint> list()
		{
			string httpMethod = "GET";
			string path = "/endpoints";

			var client = new RestClient
		}

		/// <summary>
		/// List available endoints for a given endpoint technology.
		/// </summary>
		public List<Endpoint> listByTech()
		{
			string httpMethod = "GET";
			string path = "/endpoints/{tech}";

			var client = new RestClient
		}

		/// <summary>
		/// Details for an endpoint.
		/// </summary>
		public Endpoint get()
		{
			string httpMethod = "GET";
			string path = "/endpoints/{tech}/{resource}";

			var client = new RestClient
		}

	}
}

