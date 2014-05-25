/*
	AsterNET ARI Framework
	Automatically generated file @ 25/05/2014 20:39:48
*/
using System;
using System.Collections.Generic;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Error event sent when required params are missing.
	/// </summary>
	public class MissingParams  : Message
	{
		/// <summary>
		/// A list of the missing parameters
		/// </summary>
		public List<string> Params { get; set; }

	}
}
