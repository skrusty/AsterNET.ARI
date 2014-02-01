using System;
using System.Collections.Generic;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Notification that a bridge has been created.
	/// </summary>
	public class BridgeCreatedEvent  : Event
	{
		/// <summary>
		/// no description provided
		/// </summary>
		public Bridge Bridge { get; set; }

	}
}
