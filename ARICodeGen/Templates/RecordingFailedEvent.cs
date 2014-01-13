using System;
using System.Collections.Generic;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Event showing failure of a recording operation.
	/// </summary>
	public class RecordingFailedEvent  : Event
	{
		/// <summary>
		/// Recording control object
		/// </summary>
		public LiveRecording Recording { get; set; }

	}
}
