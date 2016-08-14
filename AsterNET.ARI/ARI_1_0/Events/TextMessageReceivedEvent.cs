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
	/// A text message was received from an endpoint.
	/// </summary>
	public class TextMessageReceivedEvent  : Event
	{

		/// <summary>
		///
		/// </summary>
		// public EventsActions Event { get; set; }


		/// <summary>
		/// no description provided
		/// </summary>
		public TextMessage Message { get; set; }

		/// <summary>
		/// no description provided
		/// </summary>
		public Endpoint Endpoint { get; set; }

	}
}
