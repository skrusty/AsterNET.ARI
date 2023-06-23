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
    /// A text message was received from an endpoint.
    /// </summary>
    public class TextMessageReceivedEvent : Event
    {


        /// <summary>
        /// no description provided
        /// </summary>
        public TextMessage Message { get; set; }

        /// <summary>
        /// no description provided
        /// </summary>
        public Endpoint Endpoint { get; set; }

    }
}
