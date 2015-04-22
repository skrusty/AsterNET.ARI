/*
	AsterNET ARI Framework
	Automatically generated file @ 22/04/2015 09:45:42
*/

namespace AsterNET.ARI.Models
{
	/// <summary>
	///     Notification that a channel has entered a bridge.
	/// </summary>
	public class ChannelEnteredBridgeEvent : Event
	{
		/// <summary>
		/// </summary>
		/// <summary>
		///     no description provided
		/// </summary>
		public Bridge Bridge { get; set; }

		/// <summary>
		///     no description provided
		/// </summary>
		public Channel Channel { get; set; }
	}
}