/*
	AsterNET ARI Framework
	Automatically generated file @ 27/05/2014 20:58:03
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// DTMF received on a channel.  This event is sent when the DTMF ends. There is no notification about the start of DTMF
	/// </summary>
	public class ChannelDtmfReceivedEvent  : Event
	{

		/// <summary>
		///
		/// </summary>
		// public EventsActions Event { get; set; }


		/// <summary>
		/// DTMF digit received (0-9, A-E, # or *)
		/// </summary>
		public string Digit { get; set; }

		/// <summary>
		/// Number of milliseconds DTMF was received
		/// </summary>
		public int Duration_ms { get; set; }

		/// <summary>
		/// The channel on which DTMF was received
		/// </summary>
		public Channel Channel { get; set; }

	}
}
