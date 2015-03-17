/*
	AsterNET ARI Framework
	Automatically generated file @ 17/03/2015 15:48:04
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Middleware;
using AsterNET.ARI.Models;
using AsterNET.ARI;

namespace AsterNET.ARI.Actions
{
	
	public class EndpointsActions : ARIBaseAction, IEndpointsActions
	{

		public EndpointsActions(IActionConsumer consumer)
			: base(consumer)
		{}

		/// <summary>
		/// List all endpoints.. 
		/// </summary>
		public List<Endpoint> List()
		{
			string path = "/endpoints";
			var request = GetNewRequest(path, HttpMethod.GET);

			var response = Execute<List<Endpoint>>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;

			switch((int)response.StatusCode)
            {
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
		/// <summary>
		/// List available endoints for a given endpoint technology.. 
		/// </summary>
		/// <param name="tech">Technology of the endpoints (sip,iax2,...)</param>
		public List<Endpoint> ListByTech(string tech)
		{
			string path = "/endpoints/{tech}";
			var request = GetNewRequest(path, HttpMethod.GET);
			if(tech != null)
				request.AddUrlSegment("tech", tech);

			var response = Execute<List<Endpoint>>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;

			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Endpoints not found");
					break;
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
		/// <summary>
		/// Details for an endpoint.. 
		/// </summary>
		/// <param name="tech">Technology of the endpoint</param>
		/// <param name="resource">ID of the endpoint</param>
		public Endpoint Get(string tech, string resource)
		{
			string path = "/endpoints/{tech}/{resource}";
			var request = GetNewRequest(path, HttpMethod.GET);
			if(tech != null)
				request.AddUrlSegment("tech", tech);
			if(resource != null)
				request.AddUrlSegment("resource", resource);

			var response = Execute<Endpoint>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;

			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Endpoints not found");
					break;
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
	}
}

