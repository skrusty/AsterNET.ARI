using System;
using System.Collections.Generic;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Notification that a channel has left a Stasis application.
	/// </summary>
	public class StasisEndEvent  : Event
	{
		/// <summary>
		/// no description provided
		/// </summary>
		public Channel Channel { get; set; }

	}
}
