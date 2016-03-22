/*
	AsterNET ARI Framework
	Automatically generated file @ 3/22/2016 11:41:14 AM
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;
using AsterNET.ARI;
using System.Threading.Tasks;

namespace AsterNET.ARI.Actions
{
	
	public interface IApplicationsActions
	{
		/// <summary>
		/// List all applications.. 
		/// </summary>
		Task<List<Application>> List();
		/// <summary>
		/// Get details of an application.. 
		/// </summary>
		/// <param name="applicationName">Application's name</param>
		Task<Application> Get(string applicationName);
		/// <summary>
		/// Subscribe an application to a event source.. Returns the state of the application after the subscriptions have changed
		/// </summary>
		/// <param name="applicationName">Application's name</param>
		/// <param name="eventSource">URI for event source (channel:{channelId}, bridge:{bridgeId}, endpoint:{tech}[/{resource}], deviceState:{deviceName}</param>
		Task<Application> Subscribe(string applicationName, string eventSource);
		/// <summary>
		/// Unsubscribe an application from an event source.. Returns the state of the application after the subscriptions have changed
		/// </summary>
		/// <param name="applicationName">Application's name</param>
		/// <param name="eventSource">URI for event source (channel:{channelId}, bridge:{bridgeId}, endpoint:{tech}[/{resource}], deviceState:{deviceName}</param>
		Task<Application> Unsubscribe(string applicationName, string eventSource);
	}
}
