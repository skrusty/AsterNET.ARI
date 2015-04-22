/*
	AsterNET ARI Framework
	Automatically generated file @ 22/04/2015 09:45:42
*/

namespace AsterNET.ARI.Models
{
	/// <summary>
	///     Event showing the start of a media playback operation.
	/// </summary>
	public class PlaybackStartedEvent : Event
	{
		/// <summary>
		/// </summary>
		/// <summary>
		///     Playback control object
		/// </summary>
		public Playback Playback { get; set; }
	}
}