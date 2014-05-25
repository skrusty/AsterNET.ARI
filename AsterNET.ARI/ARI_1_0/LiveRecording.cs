/*
	AsterNET ARI Framework
	Automatically generated file @ 25/05/2014 20:39:48
*/
using System;
using System.Collections.Generic;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// A recording that is in progress
	/// </summary>
	public class LiveRecording 
	{
		/// <summary>
		/// Base name for the recording
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// no description provided
		/// </summary>
		public string Format { get; set; }

		/// <summary>
		/// no description provided
		/// </summary>
		public string State { get; set; }

		/// <summary>
		/// Cause for recording failure if failed
		/// </summary>
		public string Cause { get; set; }

	}
}
