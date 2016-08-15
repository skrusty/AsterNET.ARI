/*
	AsterNET ARI Framework
	Automatically generated file @ 14/08/2016 22:14:39
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Notification that a device state has changed.
	/// </summary>
	public class DeviceStateChangedEvent  : Event
	{


		/// <summary>
		/// Device state object
		/// </summary>
		public DeviceState Device_state { get; set; }

	}
}
