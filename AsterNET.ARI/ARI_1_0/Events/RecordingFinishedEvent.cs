/*
	AsterNET ARI Framework
	Automatically generated file @ 22/04/2015 09:45:42
*/

namespace AsterNET.ARI.Models
{
	/// <summary>
	///     Event showing the completion of a recording operation.
	/// </summary>
	public class RecordingFinishedEvent : Event
	{
		/// <summary>
		/// </summary>
		/// <summary>
		///     Recording control object
		/// </summary>
		public LiveRecording Recording { get; set; }
	}
}