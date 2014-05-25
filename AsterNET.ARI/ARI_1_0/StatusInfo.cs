/*
	AsterNET ARI Framework
	Automatically generated file @ 25/05/2014 20:39:48
*/
using System;
using System.Collections.Generic;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Info about Asterisk status
	/// </summary>
	public class StatusInfo 
	{
		/// <summary>
		/// Time when Asterisk was started.
		/// </summary>
		public DateTime Startup_time { get; set; }

		/// <summary>
		/// Time when Asterisk was last reloaded.
		/// </summary>
		public DateTime Last_reload_time { get; set; }

	}
}
