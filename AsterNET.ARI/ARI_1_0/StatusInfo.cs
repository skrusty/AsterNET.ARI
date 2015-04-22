/*
	AsterNET ARI Framework
	Automatically generated file @ 22/04/2015 09:45:42
*/

using System;

namespace AsterNET.ARI.Models
{
	/// <summary>
	///     Info about Asterisk status
	/// </summary>
	public class StatusInfo
	{
		/// <summary>
		/// </summary>
		/// <summary>
		///     Time when Asterisk was started.
		/// </summary>
		public DateTime Startup_time { get; set; }

		/// <summary>
		///     Time when Asterisk was last reloaded.
		/// </summary>
		public DateTime Last_reload_time { get; set; }
	}
}