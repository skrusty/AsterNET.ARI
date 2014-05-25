/*
	AsterNET ARI Framework
	Automatically generated file @ 25/05/2014 20:39:48
*/
using System;
using System.Collections.Generic;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// A hangup was requested on the channel.
	/// </summary>
	public class ChannelHangupRequestEvent  : Event
	{
		/// <summary>
		/// Integer representation of the cause of the hangup.
		/// </summary>
		public int Cause { get; set; }

		/// <summary>
		/// Whether the hangup request was a soft hangup request.
		/// </summary>
		public bool Soft { get; set; }

		/// <summary>
		/// The channel on which the hangup was requested.
		/// </summary>
		public Channel Channel { get; set; }

	}
}
