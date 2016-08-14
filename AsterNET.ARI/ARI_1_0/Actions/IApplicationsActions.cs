/*
	AsterNET ARI Framework
	Automatically generated file @ 7/5/2016 4:16:58 PM
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
		List<Application> List();
		/// <summary>
		/// Get details of an application.. 
		/// </summary>
		/// <param name="applicationName">Application's name</param>
		Application Get(string applicationName);
		/// <summary>
		/// Subscribe an application to a event source.. Returns the state of the application after the subscriptions have changed
		/// </summary>
		/// <param name="applicationName">Application's name</param>
		/// <param name="eventSource">URI for event source (channel:{channelId}, bridge:{bridgeId}, endpoint:{tech}[/{resource}], deviceState:{deviceName}</param>
		Application Subscribe(string applicationName, string eventSource);
		/// <summary>
		/// Unsubscribe an application from an event source.. Returns the state of the application after the subscriptions have changed
		/// </summary>
		/// <param name="applicationName">Application's name</param>
		/// <param name="eventSource">URI for event source (channel:{channelId}, bridge:{bridgeId}, endpoint:{tech}[/{resource}], deviceState:{deviceName}</param>
		Application Unsubscribe(string applicationName, string eventSource);

		/// <summary>
		/// List all applications.. 
		/// </summary>
		Task<List<Application>> ListAsync();
		/// <summary>
		/// Get details of an application.. 
		/// </summary>
		/// <param name="applicationName">Application's name</param>
		Task<Application> GetAsync(string applicationName);
		/// <summary>
		/// Subscribe an application to a event source.. Returns the state of the application after the subscriptions have changed
		/// </summary>
		/// <param name="applicationName">Application's name</param>
		/// <param name="eventSource">URI for event source (channel:{channelId}, bridge:{bridgeId}, endpoint:{tech}[/{resource}], deviceState:{deviceName}</param>
		Task<Application> SubscribeAsync(string applicationName, string eventSource);
		/// <summary>
		/// Unsubscribe an application from an event source.. Returns the state of the application after the subscriptions have changed
		/// </summary>
		/// <param name="applicationName">Application's name</param>
		/// <param name="eventSource">URI for event source (channel:{channelId}, bridge:{bridgeId}, endpoint:{tech}[/{resource}], deviceState:{deviceName}</param>
		Task<Application> UnsubscribeAsync(string applicationName, string eventSource);
	}
}
