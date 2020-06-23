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
