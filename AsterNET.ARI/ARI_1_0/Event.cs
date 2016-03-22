/*
	AsterNET ARI Framework
	Automatically generated file @ 3/22/2016 10:50:20 AM
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Base type for asynchronous events from Asterisk.
	/// </summary>
	public class Event  : Message
	{

		/// <summary>
		///
		/// </summary>
		// public EventsActions Event { get; set; }


		/// <summary>
		/// Name of the application receiving the event.
		/// </summary>
		public string Application { get; set; }

		/// <summary>
		/// Time at which this event was created.
		/// </summary>
		public DateTime Timestamp { get; set; }

	}
}
