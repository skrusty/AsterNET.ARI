/*
	AsterNET ARI Framework
	Automatically generated file @ 22/07/2014 19:01:02
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;
using AsterNET.ARI;
using RestSharp;

namespace AsterNET.ARI.Actions
{
	
	public class PlaybacksActions : ARIBaseAction
	{

		public PlaybacksActions(StasisEndpoint endPoint)
			: base(endPoint)
		{}

		/// <summary>
		/// Get a playback's details.. 
		/// </summary>
		/// <param name="playbackId">Playback's id</param>
		public Playback Get(string playbackId)
		{
			string path = "/playbacks/{playbackId}";
			var request = GetNewRequest(path, Method.GET);
			request.AddUrlSegment("playbackId", playbackId);

			var response = Client.Execute<Playback>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;

			switch((int)response.StatusCode)
            {
				case 404:
					throw new ARIException("The playback cannot be found");
					break;
				default:
					// Unknown server response
					throw new ARIException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
		/// <summary>
		/// Stop a playback.. 
		/// </summary>
		/// <param name="playbackId">Playback's id</param>
		public void Stop(string playbackId)
		{
			string path = "/playbacks/{playbackId}";
			var request = GetNewRequest(path, Method.DELETE);
			request.AddUrlSegment("playbackId", playbackId);
			var response = Client.Execute(request);
		}
		/// <summary>
		/// Control a playback.. 
		/// </summary>
		/// <param name="playbackId">Playback's id</param>
		/// <param name="operation">Operation to perform on the playback.</param>
		public void Control(string playbackId, string operation)
		{
			string path = "/playbacks/{playbackId}/control";
			var request = GetNewRequest(path, Method.POST);
			request.AddUrlSegment("playbackId", playbackId);
			request.AddParameter("operation", operation, ParameterType.QueryString);
			var response = Client.Execute(request);
		}
	}
}

