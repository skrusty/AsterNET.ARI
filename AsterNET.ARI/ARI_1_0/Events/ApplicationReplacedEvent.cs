/*
	AsterNET ARI Framework
	Automatically generated file @ 22/04/2015 09:45:42
*/

namespace AsterNET.ARI.Models
{
	/// <summary>
	///     Notification that another WebSocket has taken over for an application.  An application may only be subscribed to by
	///     a single WebSocket at a time. If multiple WebSockets attempt to subscribe to the same application, the newer
	///     WebSocket wins, and the older one receives this event.
	/// </summary>
	public class ApplicationReplacedEvent : Event
	{
		
	}
}