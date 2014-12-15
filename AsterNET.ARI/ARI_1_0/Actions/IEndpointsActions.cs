/*
	AsterNET ARI Framework
	Automatically generated file @ 08/12/2014 20:34:10
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;
using AsterNET.ARI;

namespace AsterNET.ARI.Actions
{
	
	public interface IEndpointsActions
	{
		/// <summary>
		/// List all endpoints.. 
		/// </summary>
		List<Endpoint> List();
		/// <summary>
		/// List available endoints for a given endpoint technology.. 
		/// </summary>
		/// <param name="tech">Technology of the endpoints (sip,iax2,...)</param>
		List<Endpoint> ListByTech(string tech);
		/// <summary>
		/// Details for an endpoint.. 
		/// </summary>
		/// <param name="tech">Technology of the endpoint</param>
		/// <param name="resource">ID of the endpoint</param>
		Endpoint Get(string tech, string resource);
	}
}
