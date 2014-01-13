using System;
using System.Collections.Generic;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Base type for errors and events
	/// </summary>
	public class Message 
	{
		/// <summary>
		/// Indicates the type of this message.
		/// </summary>
		public string Type { get; set; }

	}
}
