/*
	AsterNET ARI Framework
	Automatically generated file @ 7/5/2016 4:16:58 PM
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Notification that a channel has been destroyed.
	/// </summary>
	public class ChannelDestroyedEvent  : Event
	{

		/// <summary>
		///
		/// </summary>
		// public EventsActions Event { get; set; }


		/// <summary>
		/// Text representation of the cause of the hangup
		/// </summary>
		public string Cause_txt { get; set; }

		/// <summary>
		/// Integer representation of the cause of the hangup
		/// </summary>
		public int Cause { get; set; }

		/// <summary>
		/// no description provided
		/// </summary>
		public Channel Channel { get; set; }

	}
}
