using System;
using System.Collections.Generic;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Notification that a channel has left a bridge.
	/// </summary>
	public class ChannelLeftBridgeEvent  : Event
	{
		/// <summary>
		/// no description provided
		/// </summary>
		public Bridge Bridge { get; set; }

		/// <summary>
		/// no description provided
		/// </summary>
		public Channel Channel { get; set; }

	}
}
