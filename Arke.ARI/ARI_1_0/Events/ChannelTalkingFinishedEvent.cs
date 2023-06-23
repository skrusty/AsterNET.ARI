/*
   Arke ARI Framework
   Automatically generated file @ 6/23/2023 11:34:36 AM
*/
using System;
using System.Collections.Generic;
using Arke.ARI.Actions;

namespace Arke.ARI.Models
{
    /// <summary>
    /// Talking is no longer detected on the channel.
    /// </summary>
    public class ChannelTalkingFinishedEvent : Event
    {


        /// <summary>
        /// The channel on which talking completed.
        /// </summary>
        public Channel Channel { get; set; }

        /// <summary>
        /// The length of time, in milliseconds, that talking was detected on the channel
        /// </summary>
        public int Duration { get; set; }

    }
}
