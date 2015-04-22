/*
	AsterNET ARI Framework
	Automatically generated file @ 22/04/2015 09:45:42
*/

namespace AsterNET.ARI.Models
{
	/// <summary>
	///     Asterisk system information
	/// </summary>
	public class AsteriskInfo
	{
		/// <summary>
		/// </summary>
		/// <summary>
		///     Info about how Asterisk was built
		/// </summary>
		public BuildInfo Build { get; set; }

		/// <summary>
		///     Info about the system running Asterisk
		/// </summary>
		public SystemInfo System { get; set; }

		/// <summary>
		///     Info about Asterisk configuration
		/// </summary>
		public ConfigInfo Config { get; set; }

		/// <summary>
		///     Info about Asterisk status
		/// </summary>
		public StatusInfo Status { get; set; }
	}
}