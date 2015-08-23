/*
	AsterNET ARI Framework
	Automatically generated file @ 23/08/2015 23:04:36
*/
using System.Collections.Generic;
using System.Linq;
using AsterNET.ARI.Middleware;
using AsterNET.ARI.Models;
using Newtonsoft.Json;

namespace AsterNET.ARI.Actions
{
	
	public class PlaybacksActions : ARIBaseAction, IPlaybacksActions
	{

		public PlaybacksActions(IActionConsumer consumer)
			: base(consumer)
		{}

		/// <summary>
		/// Get a playback's details.. 
		/// </summary>
		/// <param name="playbackId">Playback's id</param>
		public Playback Get(string playbackId)
		{
			string path = "/playbacks/{playbackId}";
			var request = GetNewRequest(path, HttpMethod.GET);
			if(playbackId != null)
				request.AddUrlSegment("playbackId", playbackId);

			var response = Execute<Playback>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("The playback cannot be found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Stop a playback.. 
		/// </summary>
		/// <param name="playbackId">Playback's id</param>
		public void Stop(string playbackId)
		{
			string path = "/playbacks/{playbackId}";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(playbackId != null)
				request.AddUrlSegment("playbackId", playbackId);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("The playback cannot be found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Control a playback.. 
		/// </summary>
		/// <param name="playbackId">Playback's id</param>
		/// <param name="operation">Operation to perform on the playback.</param>
		public void Control(string playbackId, string operation)
		{
			string path = "/playbacks/{playbackId}/control";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(playbackId != null)
				request.AddUrlSegment("playbackId", playbackId);
			if(operation != null)
				request.AddParameter("operation", operation, ParameterType.QueryString);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("The provided operation parameter was invalid", (int)response.StatusCode);
				case 404:
					throw new AriException("The playback cannot be found", (int)response.StatusCode);
				case 409:
					throw new AriException("The operation cannot be performed in the playback's current state", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
	}
}

