/*
   AsterNET ARI Framework
   Automatically generated file @ 6/21/2023 1:51:28 PM
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
    /// <summary>
    /// Notification that one bridge has merged into another.
    /// </summary>
    public class BridgeMergedEvent : Event
    {


        /// <summary>
        /// no description provided
        /// </summary>
        public Bridge Bridge { get; set; }

        /// <summary>
        /// no description provided
        /// </summary>
        public Bridge Bridge_from { get; set; }

    }
}
