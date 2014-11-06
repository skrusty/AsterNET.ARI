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
	/// Talking was detected on the channel.
	/// </summary>
	public class ChannelTalkingStartedEvent  : Event
	{

		/// <summary>
		///
		/// </summary>
		// public EventsActions Event { get; set; }


		/// <summary>
		/// The channel on which talking started.
		/// </summary>
		public Channel Channel { get; set; }

	}
}
