/*
	AsterNET ARI Framework
	Automatically generated file @ 22/04/2015 09:45:42
*/

using System;

namespace AsterNET.ARI.Models
{
	/// <summary>
	///     Base type for asynchronous events from Asterisk.
	/// </summary>
	public class Event : Message
	{
		/// <summary>
		/// </summary>
		/// <summary>
		///     Name of the application receiving the event.
		/// </summary>
		public string Application { get; set; }

		/// <summary>
		///     Time at which this event was created.
		/// </summary>
		public DateTime Timestamp { get; set; }
	}
}