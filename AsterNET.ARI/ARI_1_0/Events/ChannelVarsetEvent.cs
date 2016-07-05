/*
	AsterNET ARI Framework
	Automatically generated file @ 7/5/2016 4:16:58 PM
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Channel variable changed.
	/// </summary>
	public class ChannelVarsetEvent  : Event
	{

		/// <summary>
		///
		/// </summary>
		// public EventsActions Event { get; set; }


		/// <summary>
		/// The channel on which the variable was set.  If missing, the variable is a global variable.
		/// </summary>
		public Channel Channel { get; set; }

		/// <summary>
		/// The variable that changed.
		/// </summary>
		public string Variable { get; set; }

		/// <summary>
		/// The new value of the variable.
		/// </summary>
		public string Value { get; set; }

	}
}
