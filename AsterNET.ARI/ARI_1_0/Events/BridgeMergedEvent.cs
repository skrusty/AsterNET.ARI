/*
	AsterNET ARI Framework
	Automatically generated file @ 22/04/2015 09:45:42
*/

namespace AsterNET.ARI.Models
{
	/// <summary>
	///     Notification that one bridge has merged into another.
	/// </summary>
	public class BridgeMergedEvent : Event
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
		public Bridge Bridge_from { get; set; }
	}
}