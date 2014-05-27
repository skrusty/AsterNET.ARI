/*
	AsterNET ARI Framework
	Automatically generated file @ 27/05/2014 20:58:03
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Notification that a blind transfer has occurred.
	/// </summary>
	public class BridgeBlindTransferEvent  : Event
	{

		/// <summary>
		///
		/// </summary>
		// public EventsActions Event { get; set; }


		/// <summary>
		/// The context transferred to
		/// </summary>
		public string Context { get; set; }

		/// <summary>
		/// The channel performing the blind transfer
		/// </summary>
		public Channel Channel { get; set; }

		/// <summary>
		/// Whether the transfer was externally initiated or not
		/// </summary>
		public bool Is_external { get; set; }

		/// <summary>
		/// The extension transferred to
		/// </summary>
		public string Exten { get; set; }

		/// <summary>
		/// The result of the transfer attempt
		/// </summary>
		public string Result { get; set; }

		/// <summary>
		/// The bridge being transferred
		/// </summary>
		public Bridge Bridge { get; set; }

	}
}
