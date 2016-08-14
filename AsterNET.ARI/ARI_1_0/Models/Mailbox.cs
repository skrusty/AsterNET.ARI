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
	/// Represents the state of a mailbox.
	/// </summary>
	public class Mailbox 
	{


		/// <summary>
		/// Count of new messages in the mailbox.
		/// </summary>
		public int New_messages { get; set; }

		/// <summary>
		/// Name of the mailbox.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Count of old messages in the mailbox.
		/// </summary>
		public int Old_messages { get; set; }

	}
}
