/*
	AsterNET ARI Framework
	Automatically generated file @ 31/08/2020 12:42:41
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Notification that a bridge has been created.
	/// </summary>
	public class BridgeCreatedEvent  : Event
	{


		/// <summary>
		/// no description provided
		/// </summary>
		public Bridge Bridge { get; set; }

	}
}
