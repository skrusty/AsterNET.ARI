/*
   AsterNET ARI Framework
   Automatically generated file @ 6/21/2023 1:51:52 PM
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;
using AsterNET.ARI;
using System.Threading.Tasks;

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
        /// <param name="variables">		void SendMessage(string to, string from, string body = null, Dictionary<string, string> variables = null);
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
        /// <param name="variables">		void SendMessageToEndpoint(string tech, string resource, string from, string body = null, Dictionary<string, string> variables = null);

        /// <summary>
        /// List all endpoints.. 
        /// </summary>
        Task<List<Endpoint>> ListAsync();
        /// <summary>
        /// Send a message to some technology URI or endpoint.. 
        /// </summary>
        /// <param name="to">The endpoint resource or technology specific URI to send the message to. Valid resources are sip, pjsip, and xmpp.</param>
        /// <param name="from">The endpoint resource or technology specific identity to send this message from. Valid resources are sip, pjsip, and xmpp.</param>
        /// <param name="body">The body of the message</param>
        Task SendMessageAsync(string to, string from, string body = null, Dictionary<string, string> variables = null);
        /// <summary>
        /// List available endoints for a given endpoint technology.. 
        /// </summary>
        /// <param name="tech">Technology of the endpoints (sip,iax2,...)</param>
        Task<List<Endpoint>> ListByTechAsync(string tech);
        /// <summary>
        /// Details for an endpoint.. 
        /// </summary>
        /// <param name="tech">Technology of the endpoint</param>
        /// <param name="resource">ID of the endpoint</param>
        Task<Endpoint> GetAsync(string tech, string resource);
        /// <summary>
        /// Send a message to some endpoint in a technology.. 
        /// </summary>
        /// <param name="tech">Technology of the endpoint</param>
        /// <param name="resource">ID of the endpoint</param>
        /// <param name="from">The endpoint resource or technology specific identity to send this message from. Valid resources are sip, pjsip, and xmpp.</param>
        /// <param name="body">The body of the message</param>
        Task SendMessageToEndpointAsync(string tech, string resource, string from, string body = null, Dictionary<string, string> variables = null);
    }
}
