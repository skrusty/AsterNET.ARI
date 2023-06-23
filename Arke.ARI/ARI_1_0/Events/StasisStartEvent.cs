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
    /// Notification that a channel has entered a Stasis application.
    /// </summary>
    public class StasisStartEvent : Event
    {


        /// <summary>
        /// Arguments to the application
        /// </summary>
        public List<string> Args { get; set; }

        /// <summary>
        /// no description provided
        /// </summary>
        public Channel Channel { get; set; }

        /// <summary>
        /// no description provided
        /// </summary>
        public Channel Replace_channel { get; set; }

    }
}
