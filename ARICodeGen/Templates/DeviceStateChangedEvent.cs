using System;
using System.Collections.Generic;

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
