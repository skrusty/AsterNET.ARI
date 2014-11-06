/*
	AsterNET ARI Framework
	Automatically generated file @ 06/11/2014 10:02:06
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Notification of a channel's state change.
	/// </summary>
	public class ChannelStateChangeEvent  : Event
	{

		/// <summary>
		///
		/// </summary>
		// public EventsActions Event { get; set; }


		/// <summary>
		/// no description provided
		/// </summary>
		public Channel Channel { get; set; }

	}
}
