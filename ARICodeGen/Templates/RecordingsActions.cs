using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;

namespace AsterNET.ARI.Actions
{
	
	public class RecordingsActions
	{

		/// <summary>
		/// List recordings that are complete.
		/// </summary>
		public List<StoredRecording> listStored()
		{
			string httpMethod = "GET";
			string path = "/recordings/stored";

			var client = new RestClient
		}

		/// <summary>
		/// Get a stored recording's details.
		/// </summary>
		public StoredRecording getStored()
		{
			string httpMethod = "GET";
			string path = "/recordings/stored/{recordingName}";

			var client = new RestClient
		}

		/// <summary>
		/// List live recordings.
		/// </summary>
		public LiveRecording getLive()
		{
			string httpMethod = "GET";
			string path = "/recordings/live/{recordingName}";

			var client = new RestClient
		}

		/// <summary>
		/// Stop a live recording and store it.
		/// </summary>
		public void stop()
		{
			string httpMethod = "POST";
			string path = "/recordings/live/{recordingName}/stop";

			var client = new RestClient
		}

		/// <summary>
		/// Pause a live recording.
		/// </summary>
		public void pause()
		{
			string httpMethod = "POST";
			string path = "/recordings/live/{recordingName}/pause";

			var client = new RestClient
		}

		/// <summary>
		/// Mute a live recording.
		/// </summary>
		public void mute()
		{
			string httpMethod = "POST";
			string path = "/recordings/live/{recordingName}/mute";

			var client = new RestClient
		}

	}
}

