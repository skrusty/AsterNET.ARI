using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;

namespace AsterNET.ARI.Actions
{
	
	public class BridgesActions
	{

		/// <summary>
		/// List all active bridges in Asterisk.
		/// </summary>
		public List<Bridge> list()
		{
			string httpMethod = "GET";
			string path = "/bridges";

			var client = new RestClient
		}

		/// <summary>
		/// Get bridge details.
		/// </summary>
		public Bridge get()
		{
			string httpMethod = "GET";
			string path = "/bridges/{bridgeId}";

			var client = new RestClient
		}

		/// <summary>
		/// Add a channel to a bridge.
		/// </summary>
		public void addChannel()
		{
			string httpMethod = "POST";
			string path = "/bridges/{bridgeId}/addChannel";

			var client = new RestClient
		}

		/// <summary>
		/// Remove a channel from a bridge.
		/// </summary>
		public void removeChannel()
		{
			string httpMethod = "POST";
			string path = "/bridges/{bridgeId}/removeChannel";

			var client = new RestClient
		}

		/// <summary>
		/// Play music on hold to a bridge or change the MOH class that is playing.
		/// </summary>
		public void startMoh()
		{
			string httpMethod = "POST";
			string path = "/bridges/{bridgeId}/moh";

			var client = new RestClient
		}

		/// <summary>
		/// Start playback of media on a bridge.
		/// </summary>
		public Playback play()
		{
			string httpMethod = "POST";
			string path = "/bridges/{bridgeId}/play";

			var client = new RestClient
		}

		/// <summary>
		/// Start a recording.
		/// </summary>
		public LiveRecording record()
		{
			string httpMethod = "POST";
			string path = "/bridges/{bridgeId}/record";

			var client = new RestClient
		}

	}
}

