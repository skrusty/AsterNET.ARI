/*
	AsterNET ARI Framework
	Automatically generated file @ 08/12/2014 20:34:10
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// A recording that is in progress
	/// </summary>
	public class LiveRecording 
	{

		/// <summary>
		///
		/// </summary>
		// public RecordingsActions Recording { get; set; }


		/// <summary>
		/// no description provided
		/// </summary>
		public string State { get; set; }

		/// <summary>
		/// no description provided
		/// </summary>
		public string Format { get; set; }

		/// <summary>
		/// Cause for recording failure if failed
		/// </summary>
		public string Cause { get; set; }

		/// <summary>
		/// Base name for the recording
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// URI for the channel or bridge being recorded
		/// </summary>
		public string Target_uri { get; set; }

	}
}
