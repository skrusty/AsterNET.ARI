﻿/*
	AsterNET ARI Framework
	Automatically generated file @ 9/22/2016 4:43:49 PM
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;
using AsterNET.ARI;
using System.Threading.Tasks;

namespace AsterNET.ARI.Actions
{

    public interface IEventsActions
    {
        /// <summary>
        /// WebSocket connection for events.. 
        /// </summary>
        /// <param name="app">Applications to subscribe to.</param>
        /// <param name="subscribeAll">Subscribe to all Asterisk events. If provided, the applications listed will be subscribed to all events, effectively disabling the application specific subscriptions. Default is 'false'.</param>
        Message EventWebsocket(string app, bool? subscribeAll = null);
        /// <summary>
        /// Generate a user event.. 
        /// </summary>
        /// <param name="eventName">Event name</param>
        /// <param name="application">The name of the application that will receive this event</param>
        /// <param name="source">URI for event source (channel:{channelId}, bridge:{bridgeId}, endpoint:{tech}/{resource}, deviceState:{deviceName}</param>
        /// <param name="variables">The "variables" key in the body object holds custom key/value pairs to add to the user event. Ex. { "variables": { "key": "value" } }</param>
        void UserEvent(string eventName, string application, string source = null, Dictionary<string, string> variables = null);

        /// <summary>
        /// WebSocket connection for events.. 
        /// </summary>
        /// <param name="app">Applications to subscribe to.</param>
        /// <param name="subscribeAll">Subscribe to all Asterisk events. If provided, the applications listed will be subscribed to all events, effectively disabling the application specific subscriptions. Default is 'false'.</param>
        Task<Message> EventWebsocketAsync(string app, bool? subscribeAll = null);
        /// <summary>
        /// Generate a user event.. 
        /// </summary>
        /// <param name="eventName">Event name</param>
        /// <param name="application">The name of the application that will receive this event</param>
        /// <param name="source">URI for event source (channel:{channelId}, bridge:{bridgeId}, endpoint:{tech}/{resource}, deviceState:{deviceName}</param>
        /// <param name="variables">The "variables" key in the body object holds custom key/value pairs to add to the user event. Ex. { "variables": { "key": "value" } }</param>
        Task UserEventAsync(string eventName, string application, string source = null, Dictionary<string, string> variables = null);
    }
}
