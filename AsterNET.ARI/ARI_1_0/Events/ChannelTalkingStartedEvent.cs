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
    /// Talking was detected on the channel.
    /// </summary>
    public class ChannelTalkingStartedEvent : Event
    {


        /// <summary>
        /// The channel on which talking started.
        /// </summary>
        public Channel Channel { get; set; }

    }
}
