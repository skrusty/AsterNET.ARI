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
    /// Base type for errors and events
    /// </summary>
    public class Message
    {


        /// <summary>
        /// Indicates the type of this message.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The unique ID for the Asterisk instance that raised this event.
        /// </summary>
        public string Asterisk_id { get; set; }

    }
}
