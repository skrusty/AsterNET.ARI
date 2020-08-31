/*
	AsterNET ARI Framework
	Automatically generated file @ 31/08/2020 12:42:41
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
		/// The channel that initiated the unhold event.
		/// </summary>
		public Channel Channel { get; set; }

	}
}
