using System;
using System.Collections.Generic;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Notification of a channel's state change.
	/// </summary>
	public class ChannelStateChangeEvent  : Event
	{
		/// <summary>
		/// no description provided
		/// </summary>
		public Channel Channel { get; set; }

	}
}
