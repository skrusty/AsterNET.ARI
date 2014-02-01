using System;
using System.Collections.Generic;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Represents the state of a device.
	/// </summary>
	public class DeviceState 
	{
		/// <summary>
		/// Name of the device.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Device's state
		/// </summary>
		public string State { get; set; }

	}
}
