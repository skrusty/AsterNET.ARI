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
	/// An external device that may offer/accept calls to/from Asterisk.  Unlike most resources, which have a single unique identifier, an endpoint is uniquely identified by the technology/resource pair.
	/// </summary>
	public class Endpoint 
	{


		/// <summary>
		/// Technology of the endpoint
		/// </summary>
		public string Technology { get; set; }

		/// <summary>
		/// Identifier of the endpoint, specific to the given technology.
		/// </summary>
		public string Resource { get; set; }

		/// <summary>
		/// Endpoint's state
		/// </summary>
		public string State { get; set; }

		/// <summary>
		/// Id's of channels associated with this endpoint
		/// </summary>
		public List<string> Channel_ids { get; set; }

	}
}
