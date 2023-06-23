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
    /// Notification that a channel has been destroyed.
    /// </summary>
    public class ChannelDestroyedEvent : Event
    {


        /// <summary>
        /// Integer representation of the cause of the hangup
        /// </summary>
        public int Cause { get; set; }

        /// <summary>
        /// Text representation of the cause of the hangup
        /// </summary>
        public string Cause_txt { get; set; }

        /// <summary>
        /// no description provided
        /// </summary>
        public Channel Channel { get; set; }

    }
}
