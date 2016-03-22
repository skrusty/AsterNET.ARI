/*
	AsterNET ARI Framework
	Automatically generated file @ 3/22/2016 11:31:36 AM
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Channel changed Connected Line.
	/// </summary>
	public class ChannelConnectedLineEvent  : Event
	{

		/// <summary>
		///
		/// </summary>
		// public EventsActions Event { get; set; }


		/// <summary>
		/// The channel whose connected line has changed.
		/// </summary>
		public Channel Channel { get; set; }

	}
}
