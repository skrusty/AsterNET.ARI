﻿/*
	AsterNET ARI Framework
	Automatically generated file @ 31/08/2020 12:42:41
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Base type for asynchronous events from Asterisk.
	/// </summary>
	public class Event  : Message
	{


		/// <summary>
		/// Name of the application receiving the event.
		/// </summary>
		public string Application { get; set; }

		/// <summary>
		/// Time at which this event was created.
		/// </summary>
		public DateTime Timestamp { get; set; }

	}
}
