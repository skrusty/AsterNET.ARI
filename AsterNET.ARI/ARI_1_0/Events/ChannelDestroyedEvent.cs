/*
	AsterNET ARI Framework
	Automatically generated file @ 14/08/2016 22:14:39
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Notification that a channel has been destroyed.
	/// </summary>
	public class ChannelDestroyedEvent  : Event
	{


		/// <summary>
		/// Integer representation of the cause of the hangup
		/// </summary>
		public int Cause { get; set; }

		/// <summary>
		/// Text representation of the cause of the hangup
		/// </summary>
		public string Cause_txt { get; set; }

		/// <summary>
		/// no description provided
		/// </summary>
		public Channel Channel { get; set; }

	}
}
