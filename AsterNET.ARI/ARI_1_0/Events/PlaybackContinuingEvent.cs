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
    /// Event showing the continuation of a media playback operation from one media URI to the next in the list.
    /// </summary>
    public class PlaybackContinuingEvent : Event
    {


        /// <summary>
        /// Playback control object
        /// </summary>
        public Playback Playback { get; set; }

    }
}
