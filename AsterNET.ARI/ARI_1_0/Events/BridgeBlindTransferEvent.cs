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
	/// Notification that a blind transfer has occurred.
	/// </summary>
	public class BridgeBlindTransferEvent  : Event
	{


		/// <summary>
		/// The context transferred to
		/// </summary>
		public string Context { get; set; }

		/// <summary>
		/// The channel performing the blind transfer
		/// </summary>
		public Channel Channel { get; set; }

		/// <summary>
		/// The extension transferred to
		/// </summary>
		public string Exten { get; set; }

		/// <summary>
		/// The channel that is being transferred
		/// </summary>
		public Channel Transferee { get; set; }

		/// <summary>
		/// Whether the transfer was externally initiated or not
		/// </summary>
		public bool Is_external { get; set; }

		/// <summary>
		/// The channel that is replacing transferer when the transferee(s) can not be transferred directly
		/// </summary>
		public Channel Replace_channel { get; set; }

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
