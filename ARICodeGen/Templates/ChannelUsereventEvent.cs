/*
	AsterNET ARI Framework
	Automatically generated file @ 27/05/2014 20:58:04
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// User-generated event with additional user-defined fields in the object.
	/// </summary>
	public class ChannelUsereventEvent  : Event
	{

		/// <summary>
		///
		/// </summary>
		// public EventsActions Event { get; set; }


		/// <summary>
		/// The name of the user event.
		/// </summary>
		public string Eventname { get; set; }

		/// <summary>
		/// Custom Userevent data
		/// </summary>
		public object Userevent { get; set; }

		/// <summary>
		/// A endpoint that is signaled with the user event.
		/// </summary>
		public Endpoint Endpoint { get; set; }

		/// <summary>
		/// A channel that is signaled with the user event.
		/// </summary>
		public Channel Channel { get; set; }

		/// <summary>
		/// A bridge that is signaled with the user event.
		/// </summary>
		public Bridge Bridge { get; set; }

	}
}
