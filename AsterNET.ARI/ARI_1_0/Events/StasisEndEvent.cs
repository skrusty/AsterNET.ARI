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
	/// Notification that a channel has left a Stasis application.
	/// </summary>
	public class StasisEndEvent  : Event
	{

		/// <summary>
		///
		/// </summary>
		// public EventsActions Event { get; set; }


		/// <summary>
		/// no description provided
		/// </summary>
		public Channel Channel { get; set; }

	}
}
