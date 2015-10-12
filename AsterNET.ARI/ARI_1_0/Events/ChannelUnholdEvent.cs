/*
	AsterNET ARI Framework
	Automatically generated file @ 12/10/2015 11:53:27
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// A channel initiated a media unhold.
	/// </summary>
	public class ChannelUnholdEvent  : Event
	{

		/// <summary>
		///
		/// </summary>
		// public EventsActions Event { get; set; }


		/// <summary>
		/// The channel that initiated the unhold event.
		/// </summary>
		public Channel Channel { get; set; }

	}
}
