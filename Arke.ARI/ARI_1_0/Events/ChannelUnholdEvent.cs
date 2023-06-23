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
    /// A channel initiated a media unhold.
    /// </summary>
    public class ChannelUnholdEvent : Event
    {


        /// <summary>
        /// The channel that initiated the unhold event.
        /// </summary>
        public Channel Channel { get; set; }

    }
}
