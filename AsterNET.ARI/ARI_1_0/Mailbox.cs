/*
	AsterNET ARI Framework
	Automatically generated file @ 3/22/2016 10:50:20 AM
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
		///
		/// </summary>
		// public MailboxesActions Mailboxe { get; set; }


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
