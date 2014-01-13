using System;
using System.Collections.Generic;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Notification that a channel has been created.
	/// </summary>
	public class ChannelCreatedEvent  : Event
	{
		/// <summary>
		/// no description provided
		/// </summary>
		public Channel Channel { get; set; }

	}
}
