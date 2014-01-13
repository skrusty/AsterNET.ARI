using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;

namespace AsterNET.ARI.Actions
{
	
	public class PlaybacksActions
	{

		/// <summary>
		/// Get a playback's details.
		/// </summary>
		public Playback get()
		{
			string httpMethod = "GET";
			string path = "/playbacks/{playbackId}";

			var client = new RestClient
		}

		/// <summary>
		/// Control a playback.
		/// </summary>
		public void control()
		{
			string httpMethod = "POST";
			string path = "/playbacks/{playbackId}/control";

			var client = new RestClient
		}

	}
}

