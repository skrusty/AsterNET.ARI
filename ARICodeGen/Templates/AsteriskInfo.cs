/*
	AsterNET ARI Framework
	Automatically generated file @ 25/05/2014 20:39:48
*/
using System;
using System.Collections.Generic;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Asterisk system information
	/// </summary>
	public class AsteriskInfo 
	{
		/// <summary>
		/// Info about how Asterisk was built
		/// </summary>
		public BuildInfo Build { get; set; }

		/// <summary>
		/// Info about the system running Asterisk
		/// </summary>
		public SystemInfo System { get; set; }

		/// <summary>
		/// Info about Asterisk configuration
		/// </summary>
		public ConfigInfo Config { get; set; }

		/// <summary>
		/// Info about Asterisk status
		/// </summary>
		public StatusInfo Status { get; set; }

	}
}
