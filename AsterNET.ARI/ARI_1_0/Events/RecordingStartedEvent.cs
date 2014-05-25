/*
	AsterNET ARI Framework
	Automatically generated file @ 25/05/2014 20:39:48
*/
using System;
using System.Collections.Generic;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Event showing the start of a recording operation.
	/// </summary>
	public class RecordingStartedEvent  : Event
	{
		/// <summary>
		/// Recording control object
		/// </summary>
		public LiveRecording Recording { get; set; }

	}
}
