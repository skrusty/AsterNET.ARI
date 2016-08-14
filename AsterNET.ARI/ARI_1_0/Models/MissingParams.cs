/*
	AsterNET ARI Framework
	Automatically generated file @ 14/08/2016 18:59:17
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

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
