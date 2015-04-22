/*
	AsterNET ARI Framework
	Automatically generated file @ 22/04/2015 09:45:42
*/

using System.Collections.Generic;
using AsterNET.ARI.Middleware;
using AsterNET.ARI.Models;

namespace AsterNET.ARI.Actions
{
	public class RecordingsActions : ARIBaseAction, IRecordingsActions
	{
		public RecordingsActions(IActionConsumer consumer)
			: base(consumer)
		{
		}

		/// <summary>
		///     List recordings that are complete..
		/// </summary>
		public List<StoredRecording> ListStored()
		{
			var path = "/recordings/stored";
			var request = GetNewRequest(path, HttpMethod.GET);

			var response = Execute<List<StoredRecording>>(request);

			if ((int) response.StatusCode >= 200 && (int) response.StatusCode < 300)
				return response.Data;

			switch ((int) response.StatusCode)
			{
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode));
			}
		}

		/// <summary>
		///     Get a stored recording's details..
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		public StoredRecording GetStored(string recordingName)
		{
			var path = "/recordings/stored/{recordingName}";
			var request = GetNewRequest(path, HttpMethod.GET);
			if (recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);

			var response = Execute<StoredRecording>(request);

			if ((int) response.StatusCode >= 200 && (int) response.StatusCode < 300)
				return response.Data;

			switch ((int) response.StatusCode)
			{
				case 404:
					throw new AriException("Recording not found");
					break;
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode));
			}
		}

		/// <summary>
		///     Delete a stored recording..
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		public void DeleteStored(string recordingName)
		{
			var path = "/recordings/stored/{recordingName}";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if (recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);
			var response = Execute(request);
		}

		/// <summary>
		///     Copy a stored recording..
		/// </summary>
		/// <param name="recordingName">The name of the recording to copy</param>
		/// <param name="destinationRecordingName">The destination name of the recording</param>
		public StoredRecording CopyStored(string recordingName, string destinationRecordingName)
		{
			var path = "/recordings/stored/{recordingName}/copy";
			var request = GetNewRequest(path, HttpMethod.POST);
			if (recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);
			if (destinationRecordingName != null)
				request.AddParameter("destinationRecordingName", destinationRecordingName, ParameterType.QueryString);

			var response = Execute<StoredRecording>(request);

			if ((int) response.StatusCode >= 200 && (int) response.StatusCode < 300)
				return response.Data;

			switch ((int) response.StatusCode)
			{
				case 404:
					throw new AriException("Recording not found");
					break;
				case 409:
					throw new AriException("A recording with the same name already exists on the system");
					break;
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode));
			}
		}

		/// <summary>
		///     List live recordings..
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		public LiveRecording GetLive(string recordingName)
		{
			var path = "/recordings/live/{recordingName}";
			var request = GetNewRequest(path, HttpMethod.GET);
			if (recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);

			var response = Execute<LiveRecording>(request);

			if ((int) response.StatusCode >= 200 && (int) response.StatusCode < 300)
				return response.Data;

			switch ((int) response.StatusCode)
			{
				case 404:
					throw new AriException("Recording not found");
					break;
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode));
			}
		}

		/// <summary>
		///     Stop a live recording and discard it..
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		public void Cancel(string recordingName)
		{
			var path = "/recordings/live/{recordingName}";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if (recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);
			var response = Execute(request);
		}

		/// <summary>
		///     Stop a live recording and store it..
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		public void Stop(string recordingName)
		{
			var path = "/recordings/live/{recordingName}/stop";
			var request = GetNewRequest(path, HttpMethod.POST);
			if (recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);
			var response = Execute(request);
		}

		/// <summary>
		///     Pause a live recording.. Pausing a recording suspends silence detection, which will be restarted when the recording
		///     is unpaused. Paused time is not included in the accounting for maxDurationSeconds.
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		public void Pause(string recordingName)
		{
			var path = "/recordings/live/{recordingName}/pause";
			var request = GetNewRequest(path, HttpMethod.POST);
			if (recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);
			var response = Execute(request);
		}

		/// <summary>
		///     Unpause a live recording..
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		public void Unpause(string recordingName)
		{
			var path = "/recordings/live/{recordingName}/pause";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if (recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);
			var response = Execute(request);
		}

		/// <summary>
		///     Mute a live recording.. Muting a recording suspends silence detection, which will be restarted when the recording
		///     is unmuted.
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		public void Mute(string recordingName)
		{
			var path = "/recordings/live/{recordingName}/mute";
			var request = GetNewRequest(path, HttpMethod.POST);
			if (recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);
			var response = Execute(request);
		}

		/// <summary>
		///     Unmute a live recording..
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		public void Unmute(string recordingName)
		{
			var path = "/recordings/live/{recordingName}/mute";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if (recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);
			var response = Execute(request);
		}
	}
}