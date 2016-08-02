/*
	AsterNET ARI Framework
	Automatically generated file @ 02/08/2016 20:28:17
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
		/// Send a message to some technology URI or endpoint.. 
		/// </summary>
		/// <param name="to">The endpoint resource or technology specific URI to send the message to. Valid resources are sip, pjsip, and xmpp.</param>
		/// <param name="from">The endpoint resource or technology specific identity to send this message from. Valid resources are sip, pjsip, and xmpp.</param>
		/// <param name="body">The body of the message</param>
		void SendMessage(string to, string from, string body = null, Dictionary<string, string> variables = null);
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
		/// <summary>
		/// Send a message to some endpoint in a technology.. 
		/// </summary>
		/// <param name="tech">Technology of the endpoint</param>
		/// <param name="resource">ID of the endpoint</param>
		/// <param name="from">The endpoint resource or technology specific identity to send this message from. Valid resources are sip, pjsip, and xmpp.</param>
		/// <param name="body">The body of the message</param>
		void SendMessageToEndpoint(string tech, string resource, string from, string body = null, Dictionary<string, string> variables = null);
	}
}
