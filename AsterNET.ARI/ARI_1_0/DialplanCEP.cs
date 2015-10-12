/*
	AsterNET ARI Framework
	Automatically generated file @ 12/10/2015 11:53:27
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Dialplan location (context/extension/priority)
	/// </summary>
	public class DialplanCEP 
	{

		/// <summary>
		///
		/// </summary>
		// public ChannelsActions Channel { get; set; }


		/// <summary>
		/// Context in the dialplan
		/// </summary>
		public string Context { get; set; }

		/// <summary>
		/// Extension in the dialplan
		/// </summary>
		public string Exten { get; set; }

		/// <summary>
		/// Priority in the dialplan
		/// </summary>
		public long Priority { get; set; }

	}
}
