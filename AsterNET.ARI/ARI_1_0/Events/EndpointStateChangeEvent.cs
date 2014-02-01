using System;
using System.Collections.Generic;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Endpoint state changed.
	/// </summary>
	public class EndpointStateChangeEvent  : Event
	{
		/// <summary>
		/// no description provided
		/// </summary>
		public Endpoint Endpoint { get; set; }

	}
}
