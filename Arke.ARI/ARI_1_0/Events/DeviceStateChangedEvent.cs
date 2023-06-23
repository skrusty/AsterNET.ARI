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
    /// Notification that a device state has changed.
    /// </summary>
    public class DeviceStateChangedEvent : Event
    {


        /// <summary>
        /// Device state object
        /// </summary>
        public DeviceState Device_state { get; set; }

    }
}
