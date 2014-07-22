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
	
	public class RecordingsActions : ARIBaseAction
	{

		public RecordingsActions(StasisEndpoint endPoint)
			: base(endPoint)
		{}

		/// <summary>
		/// List recordings that are complete.. 
		/// </summary>
		public List<StoredRecording> ListStored()
		{
			string path = "/recordings/stored";
			var request = GetNewRequest(path, Method.GET);

			var response = Client.Execute<List<StoredRecording>>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;

			switch((int)response.StatusCode)
            {
				default:
					// Unknown server response
					throw new ARIException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
		/// <summary>
		/// Get a stored recording's details.. 
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		public StoredRecording GetStored(string recordingName)
		{
			string path = "/recordings/stored/{recordingName}";
			var request = GetNewRequest(path, Method.GET);
			request.AddUrlSegment("recordingName", recordingName);

			var response = Client.Execute<StoredRecording>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;

			switch((int)response.StatusCode)
            {
				case 404:
					throw new ARIException("Recording not found");
					break;
				default:
					// Unknown server response
					throw new ARIException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
		/// <summary>
		/// Delete a stored recording.. 
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		public void DeleteStored(string recordingName)
		{
			string path = "/recordings/stored/{recordingName}";
			var request = GetNewRequest(path, Method.DELETE);
			request.AddUrlSegment("recordingName", recordingName);
			var response = Client.Execute(request);
		}
		/// <summary>
		/// List live recordings.. 
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		public LiveRecording GetLive(string recordingName)
		{
			string path = "/recordings/live/{recordingName}";
			var request = GetNewRequest(path, Method.GET);
			request.AddUrlSegment("recordingName", recordingName);

			var response = Client.Execute<LiveRecording>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;

			switch((int)response.StatusCode)
            {
				case 404:
					throw new ARIException("Recording not found");
					break;
				default:
					// Unknown server response
					throw new ARIException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
		/// <summary>
		/// Stop a live recording and discard it.. 
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		public void Cancel(string recordingName)
		{
			string path = "/recordings/live/{recordingName}";
			var request = GetNewRequest(path, Method.DELETE);
			request.AddUrlSegment("recordingName", recordingName);
			var response = Client.Execute(request);
		}
		/// <summary>
		/// Stop a live recording and store it.. 
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		public void Stop(string recordingName)
		{
			string path = "/recordings/live/{recordingName}/stop";
			var request = GetNewRequest(path, Method.POST);
			request.AddUrlSegment("recordingName", recordingName);
			var response = Client.Execute(request);
		}
		/// <summary>
		/// Pause a live recording.. Pausing a recording suspends silence detection, which will be restarted when the recording is unpaused. Paused time is not included in the accounting for maxDurationSeconds.
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		public void Pause(string recordingName)
		{
			string path = "/recordings/live/{recordingName}/pause";
			var request = GetNewRequest(path, Method.POST);
			request.AddUrlSegment("recordingName", recordingName);
			var response = Client.Execute(request);
		}
		/// <summary>
		/// Unpause a live recording.. 
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		public void Unpause(string recordingName)
		{
			string path = "/recordings/live/{recordingName}/pause";
			var request = GetNewRequest(path, Method.DELETE);
			request.AddUrlSegment("recordingName", recordingName);
			var response = Client.Execute(request);
		}
		/// <summary>
		/// Mute a live recording.. Muting a recording suspends silence detection, which will be restarted when the recording is unmuted.
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		public void Mute(string recordingName)
		{
			string path = "/recordings/live/{recordingName}/mute";
			var request = GetNewRequest(path, Method.POST);
			request.AddUrlSegment("recordingName", recordingName);
			var response = Client.Execute(request);
		}
		/// <summary>
		/// Unmute a live recording.. 
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		public void Unmute(string recordingName)
		{
			string path = "/recordings/live/{recordingName}/mute";
			var request = GetNewRequest(path, Method.DELETE);
			request.AddUrlSegment("recordingName", recordingName);
			var response = Client.Execute(request);
		}
	}
}

