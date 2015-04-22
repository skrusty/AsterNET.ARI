/*
	AsterNET ARI Framework
	Automatically generated file @ 22/04/2015 09:45:42
*/

namespace AsterNET.ARI.Models
{
	/// <summary>
	///     Event showing the start of a recording operation.
	/// </summary>
	public class RecordingStartedEvent : Event
	{
		/// <summary>
		/// </summary>
		/// <summary>
		///     Recording control object
		/// </summary>
		public LiveRecording Recording { get; set; }
	}
}