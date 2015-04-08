/*
	AsterNET ARI Framework
	Automatically generated file @ 17/03/2015 15:48:04
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Middleware;
using AsterNET.ARI.Models;
using AsterNET.ARI;

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
					throw new AriException("The playback cannot be found");
					break;
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
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
		}
	}
}

