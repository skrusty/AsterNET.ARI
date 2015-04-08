/*
	AsterNET ARI Framework
	Automatically generated file @ 17/03/2015 15:48:04
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Notification that a channel has left a bridge.
	/// </summary>
	public class ChannelLeftBridgeEvent  : Event
	{

		/// <summary>
		///
		/// </summary>
		// public EventsActions Event { get; set; }


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
