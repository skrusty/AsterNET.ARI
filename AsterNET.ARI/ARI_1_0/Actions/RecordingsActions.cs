/*
	AsterNET ARI Framework
	Automatically generated file @ 14/08/2016 22:14:39
*/
using System.Collections.Generic;
using System.Linq;
using AsterNET.ARI.Middleware;
using AsterNET.ARI.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AsterNET.ARI.Actions
{
	
	public class RecordingsActions : ARIBaseAction, IRecordingsActions
	{

		public RecordingsActions(IActionConsumer consumer)
			: base(consumer)
		{}

		/// <summary>
		/// List recordings that are complete.. 
		/// </summary>
		public List<StoredRecording> ListStored()
		{
			string path = "/recordings/stored";
			var request = GetNewRequest(path, HttpMethod.GET);

			var response = Execute<List<StoredRecording>>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Get a stored recording's details.. 
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		public StoredRecording GetStored(string recordingName)
		{
			string path = "/recordings/stored/{recordingName}";
			var request = GetNewRequest(path, HttpMethod.GET);
			if(recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);

			var response = Execute<StoredRecording>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Recording not found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Delete a stored recording.. 
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		public void DeleteStored(string recordingName)
		{
			string path = "/recordings/stored/{recordingName}";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Recording not found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Get the file associated with the stored recording.. 
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		public byte[] GetStoredFile(string recordingName)
		{
			string path = "/recordings/stored/{recordingName}/file";
			var request = GetNewRequest(path, HttpMethod.GET);
			if(recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.RawData;
			switch((int)response.StatusCode)
            {
				case 403:
					throw new AriException("The recording file could not be opened", (int)response.StatusCode);
				case 404:
					throw new AriException("Recording not found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Copy a stored recording.. 
		/// </summary>
		/// <param name="recordingName">The name of the recording to copy</param>
		/// <param name="destinationRecordingName">The destination name of the recording</param>
		public StoredRecording CopyStored(string recordingName, string destinationRecordingName)
		{
			string path = "/recordings/stored/{recordingName}/copy";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);
			if(destinationRecordingName != null)
				request.AddParameter("destinationRecordingName", destinationRecordingName, ParameterType.QueryString);

			var response = Execute<StoredRecording>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Recording not found", (int)response.StatusCode);
				case 409:
					throw new AriException("A recording with the same name already exists on the system", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// List live recordings.. 
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		public LiveRecording GetLive(string recordingName)
		{
			string path = "/recordings/live/{recordingName}";
			var request = GetNewRequest(path, HttpMethod.GET);
			if(recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);

			var response = Execute<LiveRecording>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Recording not found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Stop a live recording and discard it.. 
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		public void Cancel(string recordingName)
		{
			string path = "/recordings/live/{recordingName}";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Recording not found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Stop a live recording and store it.. 
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		public void Stop(string recordingName)
		{
			string path = "/recordings/live/{recordingName}/stop";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Recording not found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Pause a live recording.. Pausing a recording suspends silence detection, which will be restarted when the recording is unpaused. Paused time is not included in the accounting for maxDurationSeconds.
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		public void Pause(string recordingName)
		{
			string path = "/recordings/live/{recordingName}/pause";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Recording not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Recording not in session", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Unpause a live recording.. 
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		public void Unpause(string recordingName)
		{
			string path = "/recordings/live/{recordingName}/pause";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Recording not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Recording not in session", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Mute a live recording.. Muting a recording suspends silence detection, which will be restarted when the recording is unmuted.
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		public void Mute(string recordingName)
		{
			string path = "/recordings/live/{recordingName}/mute";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Recording not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Recording not in session", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Unmute a live recording.. 
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		public void Unmute(string recordingName)
		{
			string path = "/recordings/live/{recordingName}/mute";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Recording not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Recording not in session", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}

		/// <summary>
		/// List recordings that are complete.. 
		/// </summary>
		public async Task<List<StoredRecording>> ListStoredAsync()
		{
			string path = "/recordings/stored";
			var request = GetNewRequest(path, HttpMethod.GET);

			var response = await ExecuteTask<List<StoredRecording>>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Get a stored recording's details.. 
		/// </summary>
		public async Task<StoredRecording> GetStoredAsync(string recordingName)
		{
			string path = "/recordings/stored/{recordingName}";
			var request = GetNewRequest(path, HttpMethod.GET);
			if(recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);

			var response = await ExecuteTask<StoredRecording>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Recording not found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Delete a stored recording.. 
		/// </summary>
		public async Task DeleteStoredAsync(string recordingName)
		{
			string path = "/recordings/stored/{recordingName}";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Recording not found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Get the file associated with the stored recording.. 
		/// </summary>
		public async Task<byte[]> GetStoredFileAsync(string recordingName)
		{
			string path = "/recordings/stored/{recordingName}/file";
			var request = GetNewRequest(path, HttpMethod.GET);
			if(recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.RawData;
			switch((int)response.StatusCode)
            {
				case 403:
					throw new AriException("The recording file could not be opened", (int)response.StatusCode);
				case 404:
					throw new AriException("Recording not found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Copy a stored recording.. 
		/// </summary>
		public async Task<StoredRecording> CopyStoredAsync(string recordingName, string destinationRecordingName)
		{
			string path = "/recordings/stored/{recordingName}/copy";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);
			if(destinationRecordingName != null)
				request.AddParameter("destinationRecordingName", destinationRecordingName, ParameterType.QueryString);

			var response = await ExecuteTask<StoredRecording>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Recording not found", (int)response.StatusCode);
				case 409:
					throw new AriException("A recording with the same name already exists on the system", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// List live recordings.. 
		/// </summary>
		public async Task<LiveRecording> GetLiveAsync(string recordingName)
		{
			string path = "/recordings/live/{recordingName}";
			var request = GetNewRequest(path, HttpMethod.GET);
			if(recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);

			var response = await ExecuteTask<LiveRecording>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Recording not found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Stop a live recording and discard it.. 
		/// </summary>
		public async Task CancelAsync(string recordingName)
		{
			string path = "/recordings/live/{recordingName}";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Recording not found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Stop a live recording and store it.. 
		/// </summary>
		public async Task StopAsync(string recordingName)
		{
			string path = "/recordings/live/{recordingName}/stop";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Recording not found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Pause a live recording.. Pausing a recording suspends silence detection, which will be restarted when the recording is unpaused. Paused time is not included in the accounting for maxDurationSeconds.
		/// </summary>
		public async Task PauseAsync(string recordingName)
		{
			string path = "/recordings/live/{recordingName}/pause";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Recording not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Recording not in session", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Unpause a live recording.. 
		/// </summary>
		public async Task UnpauseAsync(string recordingName)
		{
			string path = "/recordings/live/{recordingName}/pause";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Recording not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Recording not in session", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Mute a live recording.. Muting a recording suspends silence detection, which will be restarted when the recording is unmuted.
		/// </summary>
		public async Task MuteAsync(string recordingName)
		{
			string path = "/recordings/live/{recordingName}/mute";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Recording not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Recording not in session", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Unmute a live recording.. 
		/// </summary>
		public async Task UnmuteAsync(string recordingName)
		{
			string path = "/recordings/live/{recordingName}/mute";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(recordingName != null)
				request.AddUrlSegment("recordingName", recordingName);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Recording not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Recording not in session", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
	}
}

