/*
	AsterNET ARI Framework
	Automatically generated file @ 22/04/2015 09:45:42
*/

using System.Collections.Generic;

namespace AsterNET.ARI.Models
{
	/// <summary>
	///     A media file that may be played back.
	/// </summary>
	public class Sound
	{
		/// <summary>
		/// </summary>
		/// <summary>
		///     Sound's identifier.
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		///     Text description of the sound, usually the words spoken.
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		///     The formats and languages in which this sound is available.
		/// </summary>
		public List<FormatLangPair> Formats { get; set; }
	}
}