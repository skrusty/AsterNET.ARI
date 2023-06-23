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
    /// Event showing the completion of a recording operation.
    /// </summary>
    public class RecordingFinishedEvent : Event
    {


        /// <summary>
        /// Recording control object
        /// </summary>
        public LiveRecording Recording { get; set; }

    }
}
