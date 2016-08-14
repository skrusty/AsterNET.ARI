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
