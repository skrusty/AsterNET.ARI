/*
	AsterNET ARI Framework
	Automatically generated file @ 14/08/2016 18:59:17
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
		/// no description provided
		/// </summary>
		public TextMessage Message { get; set; }

		/// <summary>
		/// no description provided
		/// </summary>
		public Endpoint Endpoint { get; set; }

	}
}
