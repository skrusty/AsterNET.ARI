/*
	AsterNET ARI Framework
	Automatically generated file @ 10.10.2019 19:36:54
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// A channel initiated a media hold.
	/// </summary>
	public class ChannelHoldEvent  : Event
	{


		/// <summary>
		/// The channel that initiated the hold event.
		/// </summary>
		public Channel Channel { get; set; }

		/// <summary>
		/// The music on hold class that the initiator requested.
		/// </summary>
		public string Musicclass { get; set; }

	}
}
