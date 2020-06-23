/*
   AsterNET ARI Framework
   Automatically generated file @ 6/23/2020 3:09:38 PM
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
