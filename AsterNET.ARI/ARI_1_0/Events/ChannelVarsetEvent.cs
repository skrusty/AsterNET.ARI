/*
	AsterNET ARI Framework
	Automatically generated file @ 25/05/2014 20:39:48
*/
using System;
using System.Collections.Generic;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Channel variable changed.
	/// </summary>
	public class ChannelVarsetEvent  : Event
	{
		/// <summary>
		/// The variable that changed.
		/// </summary>
		public string Variable { get; set; }

		/// <summary>
		/// The new value of the variable.
		/// </summary>
		public string Value { get; set; }

		/// <summary>
		/// The channel on which the variable was set.  If missing, the variable is a global variable.
		/// </summary>
		public Channel Channel { get; set; }

	}
}
