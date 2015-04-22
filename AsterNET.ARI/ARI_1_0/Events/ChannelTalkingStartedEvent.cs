/*
	AsterNET ARI Framework
	Automatically generated file @ 22/04/2015 09:45:42
*/

namespace AsterNET.ARI.Models
{
	/// <summary>
	///     Talking was detected on the channel.
	/// </summary>
	public class ChannelTalkingStartedEvent : Event
	{
		/// <summary>
		/// </summary>
		/// <summary>
		///     The channel on which talking started.
		/// </summary>
		public Channel Channel { get; set; }
	}
}