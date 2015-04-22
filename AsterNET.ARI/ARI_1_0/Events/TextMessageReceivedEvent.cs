/*
	AsterNET ARI Framework
	Automatically generated file @ 22/04/2015 09:45:42
*/

namespace AsterNET.ARI.Models
{
	/// <summary>
	///     A text message was received from an endpoint.
	/// </summary>
	public class TextMessageReceivedEvent : Event
	{
		/// <summary>
		/// </summary>
		/// <summary>
		///     no description provided
		/// </summary>
		public TextMessage Message { get; set; }

		/// <summary>
		///     no description provided
		/// </summary>
		public Endpoint Endpoint { get; set; }
	}
}