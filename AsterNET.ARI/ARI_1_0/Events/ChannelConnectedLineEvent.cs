/*
	AsterNET ARI Framework
	Automatically generated file @ 9/22/2016 4:43:49 PM
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
    /// <summary>
    /// Channel changed Connected Line.
    /// </summary>
    public class ChannelConnectedLineEvent : Event
    {


        /// <summary>
        /// The channel whose connected line has changed.
        /// </summary>
        public Channel Channel { get; set; }

    }
}
