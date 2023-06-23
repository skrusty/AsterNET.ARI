/*
   AsterNET ARI Framework
   Automatically generated file @ 6/21/2023 2:39:14 PM
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
        /// Filter application events types.. Allowed and/or disallowed event type filtering can be done. The body (parameter) should specify a JSON key/value object that describes the type of event filtering needed. One, or both of the following keys can be designated:<br /><br />"allowed" - Specifies an allowed list of event types<br />"disallowed" - Specifies a disallowed list of event types<br /><br />Further, each of those key's value should be a JSON array that holds zero, or more JSON key/value objects. Each of these objects must contain the following key with an associated value:<br /><br />"type" - The type name of the event to filter<br /><br />The value must be the string name (case sensitive) of the event type that needs filtering. For example:<br /><br />{ "allowed": [ { "type": "StasisStart" }, { "type": "StasisEnd" } ] }<br /><br />As this specifies only an allowed list, then only those two event type messages are sent to the application. No other event messages are sent.<br /><br />The following rules apply:<br /><br />* If the body is empty, both the allowed and disallowed filters are set empty.<br />* If both list types are given then both are set to their respective values (note, specifying an empty array for a given type sets that type to empty).<br />* If only one list type is given then only that type is set. The other type is not updated.<br />* An empty "allowed" list means all events are allowed.<br />* An empty "disallowed" list means no events are disallowed.<br />* Disallowed events take precedence over allowed events if the event type is specified in both lists.
        /// </summary>
        /// <param name="applicationName">Application's name</param>
        /// <param name="filter">Specify which event types to allow/disallow</param>
        Application Filter(string applicationName, object filter = null);

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
        /// <summary>
        /// Filter application events types.. Allowed and/or disallowed event type filtering can be done. The body (parameter) should specify a JSON key/value object that describes the type of event filtering needed. One, or both of the following keys can be designated:<br /><br />"allowed" - Specifies an allowed list of event types<br />"disallowed" - Specifies a disallowed list of event types<br /><br />Further, each of those key's value should be a JSON array that holds zero, or more JSON key/value objects. Each of these objects must contain the following key with an associated value:<br /><br />"type" - The type name of the event to filter<br /><br />The value must be the string name (case sensitive) of the event type that needs filtering. For example:<br /><br />{ "allowed": [ { "type": "StasisStart" }, { "type": "StasisEnd" } ] }<br /><br />As this specifies only an allowed list, then only those two event type messages are sent to the application. No other event messages are sent.<br /><br />The following rules apply:<br /><br />* If the body is empty, both the allowed and disallowed filters are set empty.<br />* If both list types are given then both are set to their respective values (note, specifying an empty array for a given type sets that type to empty).<br />* If only one list type is given then only that type is set. The other type is not updated.<br />* An empty "allowed" list means all events are allowed.<br />* An empty "disallowed" list means no events are disallowed.<br />* Disallowed events take precedence over allowed events if the event type is specified in both lists.
        /// </summary>
        /// <param name="applicationName">Application's name</param>
        /// <param name="filter">Specify which event types to allow/disallow</param>
        Task<Application> FilterAsync(string applicationName, object filter = null);
    }
}
