/*
	AsterNET ARI Framework
	Automatically generated file @ 02/08/2016 20:28:17
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// A media file that may be played back.
	/// </summary>
	public class Sound 
	{


		/// <summary>
		/// Sound's identifier.
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Text description of the sound, usually the words spoken.
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// The formats and languages in which this sound is available.
		/// </summary>
		public List<FormatLangPair> Formats { get; set; }

	}
}
