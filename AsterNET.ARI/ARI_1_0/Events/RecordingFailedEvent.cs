/*
   AsterNET ARI Framework
   Automatically generated file @ 6/21/2023 1:51:26 PM
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
    /// <summary>
    /// Event showing failure of a recording operation.
    /// </summary>
    public class RecordingFailedEvent : Event
    {


        /// <summary>
        /// Recording control object
        /// </summary>
        public LiveRecording Recording { get; set; }

    }
}
