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
	/// Channel changed Caller ID.
	/// </summary>
	public class ChannelCallerIdEvent  : Event
	{

		/// <summary>
		///
		/// </summary>
		// public EventsActions Event { get; set; }


		/// <summary>
		/// The text representation of the Caller Presentation value.
		/// </summary>
		public string Caller_presentation_txt { get; set; }

		/// <summary>
		/// The integer representation of the Caller Presentation value.
		/// </summary>
		public int Caller_presentation { get; set; }

		/// <summary>
		/// The channel that changed Caller ID.
		/// </summary>
		public Channel Channel { get; set; }

	}
}
