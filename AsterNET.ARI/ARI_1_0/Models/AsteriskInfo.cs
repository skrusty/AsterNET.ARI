/*
	AsterNET ARI Framework
	Automatically generated file @ 02/08/2016 20:28:17
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Asterisk system information
	/// </summary>
	public class AsteriskInfo 
	{


		/// <summary>
		/// Info about Asterisk status
		/// </summary>
		public StatusInfo Status { get; set; }

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

	}
}
