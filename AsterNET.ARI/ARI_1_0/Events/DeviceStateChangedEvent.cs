/*
	AsterNET ARI Framework
	Automatically generated file @ 22/04/2015 09:45:42
*/

namespace AsterNET.ARI.Models
{
	/// <summary>
	///     Notification that a device state has changed.
	/// </summary>
	public class DeviceStateChangedEvent : Event
	{
		/// <summary>
		/// </summary>
		/// <summary>
		///     Device state object
		/// </summary>
		public DeviceState Device_state { get; set; }
	}
}