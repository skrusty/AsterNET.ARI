/*
	AsterNET ARI Framework
	Automatically generated file @ 25/05/2014 20:39:48
*/
using System;
using System.Collections.Generic;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// User-generated event with additional user-defined fields in the object.
	/// </summary>
	public class ChannelUsereventEvent  : Event
	{
		/// <summary>
		/// The name of the user event.
		/// </summary>
		public string Eventname { get; set; }

		/// <summary>
		/// The channel that signaled the user event.
		/// </summary>
		public Channel Channel { get; set; }

		/// <summary>
		/// Custom Userevent data
		/// </summary>
		public object Userevent { get; set; }

	}
}
