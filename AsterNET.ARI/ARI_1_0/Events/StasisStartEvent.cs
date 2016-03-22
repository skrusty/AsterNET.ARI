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
	/// Notification that a channel has entered a Stasis application.
	/// </summary>
	public class StasisStartEvent  : Event
	{

		/// <summary>
		///
		/// </summary>
		// public EventsActions Event { get; set; }


		/// <summary>
		/// Arguments to the application
		/// </summary>
		public List<string> Args { get; set; }

		/// <summary>
		/// no description provided
		/// </summary>
		public Channel Channel { get; set; }

		/// <summary>
		/// no description provided
		/// </summary>
		public Channel Replace_channel { get; set; }

	}
}
