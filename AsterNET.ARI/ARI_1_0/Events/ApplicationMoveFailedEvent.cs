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
    /// Notification that trying to move a channel to another Stasis application failed.
    /// </summary>
    public class ApplicationMoveFailedEvent : Event
    {


        /// <summary>
        /// no description provided
        /// </summary>
        public Channel Channel { get; set; }

        /// <summary>
        /// no description provided
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Arguments to the application
        /// </summary>
        public List<string> Args { get; set; }

    }
}
