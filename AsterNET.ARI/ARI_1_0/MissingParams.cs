/*
	AsterNET ARI Framework
	Automatically generated file @ 22/04/2015 09:45:42
*/

using System.Collections.Generic;

namespace AsterNET.ARI.Models
{
	/// <summary>
	///     Error event sent when required params are missing.
	/// </summary>
	public class MissingParams : Message
	{
		/// <summary>
		/// </summary>
		/// <summary>
		///     A list of the missing parameters
		/// </summary>
		public List<string> Params { get; set; }
	}
}