/*
	AsterNET ARI Framework
	Automatically generated file @ 22/04/2015 09:45:42
*/

namespace AsterNET.ARI.Models
{
	/// <summary>
	///     Talking is no longer detected on the channel.
	/// </summary>
	public class ChannelTalkingFinishedEvent : Event
	{
		/// <summary>
		/// </summary>
		/// <summary>
		///     The channel on which talking completed.
		/// </summary>
		public Channel Channel { get; set; }

		/// <summary>
		///     The length of time, in milliseconds, that talking was detected on the channel
		/// </summary>
		public int Duration { get; set; }
	}
}