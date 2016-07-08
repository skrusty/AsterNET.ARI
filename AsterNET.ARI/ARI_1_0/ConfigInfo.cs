﻿/*
	AsterNET ARI Framework
	Automatically generated file @ 7/5/2016 4:16:58 PM
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Info about Asterisk configuration
	/// </summary>
	public class ConfigInfo 
	{

		/// <summary>
		///
		/// </summary>
		// public AsteriskActions Asteris { get; set; }


		/// <summary>
		/// Default language for media playback.
		/// </summary>
		public string Default_language { get; set; }

		/// <summary>
		/// Asterisk system name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Effective user/group id for running Asterisk.
		/// </summary>
		public SetId Setid { get; set; }

		/// <summary>
		/// Maximum number of open file handles (files, sockets).
		/// </summary>
		public int Max_open_files { get; set; }

		/// <summary>
		/// Maximum number of simultaneous channels.
		/// </summary>
		public int Max_channels { get; set; }

		/// <summary>
		/// Maximum load avg on system.
		/// </summary>
		public double Max_load { get; set; }

	}
}
