using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;

namespace AsterNET.ARI.Actions
{
	
	public class ChannelsActions
	{

		/// <summary>
		/// List all active channels in Asterisk.
		/// </summary>
		public List<Channel> list()
		{
			string httpMethod = "GET";
			string path = "/channels";

			var client = new RestClient
		}

		/// <summary>
		/// Channel details.
		/// </summary>
		public Channel get()
		{
			string httpMethod = "GET";
			string path = "/channels/{channelId}";

			var client = new RestClient
		}

		/// <summary>
		/// Exit application; continue execution in the dialplan.
		/// </summary>
		public void continueInDialplan()
		{
			string httpMethod = "POST";
			string path = "/channels/{channelId}/continue";

			var client = new RestClient
		}

		/// <summary>
		/// Answer a channel.
		/// </summary>
		public void answer()
		{
			string httpMethod = "POST";
			string path = "/channels/{channelId}/answer";

			var client = new RestClient
		}

		/// <summary>
		/// Indicate ringing to a channel.
		/// </summary>
		public void ring()
		{
			string httpMethod = "POST";
			string path = "/channels/{channelId}/ring";

			var client = new RestClient
		}

		/// <summary>
		/// Send provided DTMF to a given channel.
		/// </summary>
		public void sendDTMF()
		{
			string httpMethod = "POST";
			string path = "/channels/{channelId}/dtmf";

			var client = new RestClient
		}

		/// <summary>
		/// Mute a channel.
		/// </summary>
		public void mute()
		{
			string httpMethod = "POST";
			string path = "/channels/{channelId}/mute";

			var client = new RestClient
		}

		/// <summary>
		/// Hold a channel.
		/// </summary>
		public void hold()
		{
			string httpMethod = "POST";
			string path = "/channels/{channelId}/hold";

			var client = new RestClient
		}

		/// <summary>
		/// Play music on hold to a channel.
		/// </summary>
		public void startMoh()
		{
			string httpMethod = "POST";
			string path = "/channels/{channelId}/moh";

			var client = new RestClient
		}

		/// <summary>
		/// Play silence to a channel.
		/// </summary>
		public void startSilence()
		{
			string httpMethod = "POST";
			string path = "/channels/{channelId}/silence";

			var client = new RestClient
		}

		/// <summary>
		/// Start playback of media.
		/// </summary>
		public Playback play()
		{
			string httpMethod = "POST";
			string path = "/channels/{channelId}/play";

			var client = new RestClient
		}

		/// <summary>
		/// Start a recording.
		/// </summary>
		public LiveRecording record()
		{
			string httpMethod = "POST";
			string path = "/channels/{channelId}/record";

			var client = new RestClient
		}

		/// <summary>
		/// Get the value of a channel variable or function.
		/// </summary>
		public Variable getChannelVar()
		{
			string httpMethod = "GET";
			string path = "/channels/{channelId}/variable";

			var client = new RestClient
		}

		/// <summary>
		/// Start snooping.
		/// </summary>
		public Channel snoopChannel()
		{
			string httpMethod = "POST";
			string path = "/channels/{channelId}/snoop";

			var client = new RestClient
		}

	}
}

