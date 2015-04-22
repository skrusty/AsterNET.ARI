/*
	AsterNET ARI Framework
	Automatically generated file @ 22/04/2015 09:45:42
*/

namespace AsterNET.ARI.Models
{
	/// <summary>
	///     Represents the state of a mailbox.
	/// </summary>
	public class Mailbox
	{
		/// <summary>
		/// </summary>
		/// <summary>
		///     Name of the mailbox.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		///     Count of old messages in the mailbox.
		/// </summary>
		public int Old_messages { get; set; }

		/// <summary>
		///     Count of new messages in the mailbox.
		/// </summary>
		public int New_messages { get; set; }
	}
}