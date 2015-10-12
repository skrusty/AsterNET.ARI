/*
	AsterNET ARI Framework
	Automatically generated file @ 12/10/2015 11:53:28
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;
using AsterNET.ARI;

namespace AsterNET.ARI.Actions
{
	
	public interface IMailboxesActions
	{
		/// <summary>
		/// List all mailboxes.. 
		/// </summary>
		List<Mailbox> List();
		/// <summary>
		/// Retrieve the current state of a mailbox.. 
		/// </summary>
		/// <param name="mailboxName">Name of the mailbox</param>
		Mailbox Get(string mailboxName);
		/// <summary>
		/// Change the state of a mailbox. (Note - implicitly creates the mailbox).. 
		/// </summary>
		/// <param name="mailboxName">Name of the mailbox</param>
		/// <param name="oldMessages">Count of old messages in the mailbox</param>
		/// <param name="newMessages">Count of new messages in the mailbox</param>
		void Update(string mailboxName, int oldMessages, int newMessages);
		/// <summary>
		/// Destroy a mailbox.. 
		/// </summary>
		/// <param name="mailboxName">Name of the mailbox</param>
		void Delete(string mailboxName);
	}
}
