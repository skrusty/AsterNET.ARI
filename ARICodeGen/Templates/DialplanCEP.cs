using System;
using System.Collections.Generic;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Dialplan location (context/extension/priority)
	/// </summary>
	public class DialplanCEP 
	{
		/// <summary>
		/// Context in the dialplan
		/// </summary>
		public string Context { get; set; }

		/// <summary>
		/// Extension in the dialplan
		/// </summary>
		public string Exten { get; set; }

		/// <summary>
		/// Priority in the dialplan
		/// </summary>
		public long Priority { get; set; }

	}
}
