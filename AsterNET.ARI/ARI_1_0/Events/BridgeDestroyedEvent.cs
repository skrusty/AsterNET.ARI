using System;
using System.Collections.Generic;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Notification that a bridge has been destroyed.
	/// </summary>
	public class BridgeDestroyedEvent  : Event
	{
		/// <summary>
		/// no description provided
		/// </summary>
		public Bridge Bridge { get; set; }

	}
}
