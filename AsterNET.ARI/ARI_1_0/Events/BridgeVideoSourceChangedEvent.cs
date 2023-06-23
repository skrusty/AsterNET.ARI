/*
   AsterNET ARI Framework
   Automatically generated file @ 6/21/2023 2:39:09 PM
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
    /// <summary>
    /// Notification that the source of video in a bridge has changed.
    /// </summary>
    public class BridgeVideoSourceChangedEvent : Event
    {


        /// <summary>
        /// no description provided
        /// </summary>
        public Bridge Bridge { get; set; }

        /// <summary>
        /// no description provided
        /// </summary>
        public string Old_video_source_id { get; set; }

    }
}
