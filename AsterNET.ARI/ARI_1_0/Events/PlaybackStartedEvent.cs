/*
   AsterNET ARI Framework
   Automatically generated file @ 6/21/2023 2:39:08 PM
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
    /// <summary>
    /// Event showing the start of a media playback operation.
    /// </summary>
    public class PlaybackStartedEvent : Event
    {


        /// <summary>
        /// Playback control object
        /// </summary>
        public Playback Playback { get; set; }

    }
}
