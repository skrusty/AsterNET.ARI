/*
	AsterNET ARI Framework
	Automatically generated file @ 22/04/2015 09:45:42
*/

using System.Collections.Generic;

namespace AsterNET.ARI.Models
{
	/// <summary>
	///     Notification that a channel has entered a Stasis application.
	/// </summary>
	public class StasisStartEvent : Event
	{
		/// <summary>
		/// </summary>
		/// <summary>
		///     Arguments to the application
		/// </summary>
		public List<string> Args { get; set; }

		/// <summary>
		///     no description provided
		/// </summary>
		public Channel Channel { get; set; }

		/// <summary>
		///     no description provided
		/// </summary>
		public Channel Replace_channel { get; set; }
	}
}