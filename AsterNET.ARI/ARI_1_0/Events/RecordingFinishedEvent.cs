using System;
using System.Collections.Generic;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Event showing the completion of a recording operation.
	/// </summary>
	public class RecordingFinishedEvent  : Event
	{
		/// <summary>
		/// Recording control object
		/// </summary>
		public LiveRecording Recording { get; set; }

	}
}
