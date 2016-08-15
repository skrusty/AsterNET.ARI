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
	/// The state of a peer associated with an endpoint has changed.
	/// </summary>
	public class PeerStatusChangeEvent  : Event
	{


		/// <summary>
		/// no description provided
		/// </summary>
		public Endpoint Endpoint { get; set; }

		/// <summary>
		/// no description provided
		/// </summary>
		public Peer Peer { get; set; }

	}
}
