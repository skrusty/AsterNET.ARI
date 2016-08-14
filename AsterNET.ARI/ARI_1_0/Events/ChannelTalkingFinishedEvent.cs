/*
	AsterNET ARI Framework
	Automatically generated file @ 14/08/2016 18:59:17
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Talking is no longer detected on the channel.
	/// </summary>
	public class ChannelTalkingFinishedEvent  : Event
	{


		/// <summary>
		/// The length of time, in milliseconds, that talking was detected on the channel
		/// </summary>
		public int Duration { get; set; }

		/// <summary>
		/// The channel on which talking completed.
		/// </summary>
		public Channel Channel { get; set; }

	}
}
