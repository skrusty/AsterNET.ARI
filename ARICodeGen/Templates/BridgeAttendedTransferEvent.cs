/*
	AsterNET ARI Framework
	Automatically generated file @ 06/11/2014 10:21:07
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Notification that an attended transfer has occurred.
	/// </summary>
	public class BridgeAttendedTransferEvent  : Event
	{

		/// <summary>
		///
		/// </summary>
		// public EventsActions Event { get; set; }


		/// <summary>
		/// Transferer channel that survived the threeway result
		/// </summary>
		public Channel Destination_threeway_channel { get; set; }

		/// <summary>
		/// First leg of the transferer
		/// </summary>
		public Channel Transferer_first_leg { get; set; }

		/// <summary>
		/// Application that has been transferred into
		/// </summary>
		public string Destination_application { get; set; }

		/// <summary>
		/// Bridge the transferer first leg is in
		/// </summary>
		public Bridge Transferer_first_leg_bridge { get; set; }

		/// <summary>
		/// Bridge that survived the merge result
		/// </summary>
		public string Destination_bridge { get; set; }

		/// <summary>
		/// Whether the transfer was externally initiated or not
		/// </summary>
		public bool Is_external { get; set; }

		/// <summary>
		/// How the transfer was accomplished
		/// </summary>
		public string Destination_type { get; set; }

		/// <summary>
		/// Second leg of the transferer
		/// </summary>
		public Channel Transferer_second_leg { get; set; }

		/// <summary>
		/// The result of the transfer attempt
		/// </summary>
		public string Result { get; set; }

		/// <summary>
		/// Second leg of a link transfer result
		/// </summary>
		public Channel Destination_link_second_leg { get; set; }

		/// <summary>
		/// Bridge the transferer second leg is in
		/// </summary>
		public Bridge Transferer_second_leg_bridge { get; set; }

		/// <summary>
		/// First leg of a link transfer result
		/// </summary>
		public Channel Destination_link_first_leg { get; set; }

		/// <summary>
		/// Bridge that survived the threeway result
		/// </summary>
		public Bridge Destination_threeway_bridge { get; set; }

	}
}
