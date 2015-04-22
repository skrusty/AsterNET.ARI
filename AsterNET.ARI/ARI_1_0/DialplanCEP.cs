/*
	AsterNET ARI Framework
	Automatically generated file @ 22/04/2015 09:45:42
*/

namespace AsterNET.ARI.Models
{
	/// <summary>
	///     Dialplan location (context/extension/priority)
	/// </summary>
	public class DialplanCEP
	{
		/// <summary>
		/// </summary>
		/// <summary>
		///     Context in the dialplan
		/// </summary>
		public string Context { get; set; }

		/// <summary>
		///     Extension in the dialplan
		/// </summary>
		public string Exten { get; set; }

		/// <summary>
		///     Priority in the dialplan
		/// </summary>
		public long Priority { get; set; }
	}
}