/*
	AsterNET ARI Framework
	Automatically generated file @ 02/08/2016 20:28:17
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// A text message.
	/// </summary>
	public class TextMessage 
	{


		/// <summary>
		/// A technology specific URI specifying the destination of the message. Valid technologies include sip, pjsip, and xmp. The destination of a message should be an endpoint.
		/// </summary>
		public string To { get; set; }

		/// <summary>
		/// A technology specific URI specifying the source of the message. For sip and pjsip technologies, any SIP URI can be specified. For xmpp, the URI must correspond to the client connection being used to send the message.
		/// </summary>
		public string From { get; set; }

		/// <summary>
		/// The text of the message.
		/// </summary>
		public string Body { get; set; }

		/// <summary>
		/// Technology specific key/value pairs associated with the message.
		/// </summary>
		public List<TextMessageVariable> Variables { get; set; }

	}
}
