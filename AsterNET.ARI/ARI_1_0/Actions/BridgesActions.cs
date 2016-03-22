/*
	AsterNET ARI Framework
	Automatically generated file @ 3/22/2016 11:41:14 AM
*/
using System.Collections.Generic;
using System.Linq;
using AsterNET.ARI.Middleware;
using AsterNET.ARI.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AsterNET.ARI.Actions
{
	
	public class BridgesActions : ARIBaseAction, IBridgesActions
	{

		public BridgesActions(IActionConsumer consumer)
			: base(consumer)
		{}

		/// <summary>
		/// List all active bridges in Asterisk.. 
		/// </summary>
		public async Task<List<Bridge>> List()
		{
			string path = "/bridges";
			var request = GetNewRequest(path, HttpMethod.GET);

			var response = await ExecuteTask<List<Bridge>>(request);

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
		/// Create a new bridge.. This bridge persists until it has been shut down, or Asterisk has been shut down.
		/// </summary>
		/// <param name="type">Comma separated list of bridge type attributes (mixing, holding, dtmf_events, proxy_media).</param>
		/// <param name="bridgeId">Unique ID to give to the bridge being created.</param>
		/// <param name="name">Name to give to the bridge being created.</param>
		public async Task<Bridge> Create(string type = null, string bridgeId = null, string name = null)
		{
			string path = "/bridges";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(type != null)
				request.AddParameter("type", type, ParameterType.QueryString);
			if(bridgeId != null)
				request.AddParameter("bridgeId", bridgeId, ParameterType.QueryString);
			if(name != null)
				request.AddParameter("name", name, ParameterType.QueryString);

			var response = await ExecuteTask<Bridge>(request);

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
		/// Create a new bridge or updates an existing one.. This bridge persists until it has been shut down, or Asterisk has been shut down.
		/// </summary>
		/// <param name="type">Comma separated list of bridge type attributes (mixing, holding, dtmf_events, proxy_media) to set.</param>
		/// <param name="bridgeId">Unique ID to give to the bridge being created.</param>
		/// <param name="name">Set the name of the bridge.</param>
		public async Task<Bridge> CreateWithId(string bridgeId, string type = null, string name = null)
		{
			string path = "/bridges/{bridgeId}";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(type != null)
				request.AddParameter("type", type, ParameterType.QueryString);
			if(bridgeId != null)
				request.AddUrlSegment("bridgeId", bridgeId);
			if(name != null)
				request.AddParameter("name", name, ParameterType.QueryString);

			var response = await ExecuteTask<Bridge>(request);

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
		/// Get bridge details.. 
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		public async Task<Bridge> Get(string bridgeId)
		{
			string path = "/bridges/{bridgeId}";
			var request = GetNewRequest(path, HttpMethod.GET);
			if(bridgeId != null)
				request.AddUrlSegment("bridgeId", bridgeId);

			var response = await ExecuteTask<Bridge>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Bridge not found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Shut down a bridge.. If any channels are in this bridge, they will be removed and resume whatever they were doing beforehand.
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		public async Task Destroy(string bridgeId)
		{
			string path = "/bridges/{bridgeId}";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(bridgeId != null)
				request.AddUrlSegment("bridgeId", bridgeId);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Bridge not found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Add a channel to a bridge.. 
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="channel">Ids of channels to add to bridge</param>
		/// <param name="role">Channel's role in the bridge</param>
		public async Task AddChannel(string bridgeId, string channel, string role = null)
		{
			string path = "/bridges/{bridgeId}/addChannel";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(bridgeId != null)
				request.AddUrlSegment("bridgeId", bridgeId);
			if(channel != null)
				request.AddParameter("channel", channel, ParameterType.QueryString);
			if(role != null)
				request.AddParameter("role", role, ParameterType.QueryString);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 404:
					throw new AriException("Bridge not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Bridge not in Stasis application; Channel currently recording", (int)response.StatusCode);
				case 422:
					throw new AriException("Channel not in Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Remove a channel from a bridge.. 
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="channel">Ids of channels to remove from bridge</param>
		public async Task RemoveChannel(string bridgeId, string channel)
		{
			string path = "/bridges/{bridgeId}/removeChannel";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(bridgeId != null)
				request.AddUrlSegment("bridgeId", bridgeId);
			if(channel != null)
				request.AddParameter("channel", channel, ParameterType.QueryString);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 404:
					throw new AriException("Bridge not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Bridge not in Stasis application", (int)response.StatusCode);
				case 422:
					throw new AriException("Channel not in this bridge", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Play music on hold to a bridge or change the MOH class that is playing.. 
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="mohClass">Channel's id</param>
		public async Task StartMoh(string bridgeId, string mohClass = null)
		{
			string path = "/bridges/{bridgeId}/moh";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(bridgeId != null)
				request.AddUrlSegment("bridgeId", bridgeId);
			if(mohClass != null)
				request.AddParameter("mohClass", mohClass, ParameterType.QueryString);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Bridge not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Bridge not in Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Stop playing music on hold to a bridge.. This will only stop music on hold being played via POST bridges/{bridgeId}/moh.
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		public async Task StopMoh(string bridgeId)
		{
			string path = "/bridges/{bridgeId}/moh";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(bridgeId != null)
				request.AddUrlSegment("bridgeId", bridgeId);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Bridge not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Bridge not in Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Start playback of media on a bridge.. The media URI may be any of a number of URI's. Currently sound:, recording:, number:, digits:, characters:, and tone: URI's are supported. This operation creates a playback resource that can be used to control the playback of media (pause, rewind, fast forward, etc.)
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="media">Media's URI to play.</param>
		/// <param name="lang">For sounds, selects language for sound.</param>
		/// <param name="offsetms">Number of media to skip before playing.</param>
		/// <param name="skipms">Number of milliseconds to skip for forward/reverse operations.</param>
		/// <param name="playbackId">Playback Id.</param>
		public async Task<Playback> Play(string bridgeId, string media, string lang = null, int? offsetms = null, int? skipms = null, string playbackId = null)
		{
			string path = "/bridges/{bridgeId}/play";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(bridgeId != null)
				request.AddUrlSegment("bridgeId", bridgeId);
			if(media != null)
				request.AddParameter("media", media, ParameterType.QueryString);
			if(lang != null)
				request.AddParameter("lang", lang, ParameterType.QueryString);
			if(offsetms != null)
				request.AddParameter("offsetms", offsetms, ParameterType.QueryString);
			if(skipms != null)
				request.AddParameter("skipms", skipms, ParameterType.QueryString);
			if(playbackId != null)
				request.AddParameter("playbackId", playbackId, ParameterType.QueryString);

			var response = await ExecuteTask<Playback>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Bridge not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Bridge not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Start playback of media on a bridge.. The media URI may be any of a number of URI's. Currently sound:, recording:, number:, digits:, characters:, and tone: URI's are supported. This operation creates a playback resource that can be used to control the playback of media (pause, rewind, fast forward, etc.)
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="playbackId">Playback ID.</param>
		/// <param name="media">Media's URI to play.</param>
		/// <param name="lang">For sounds, selects language for sound.</param>
		/// <param name="offsetms">Number of media to skip before playing.</param>
		/// <param name="skipms">Number of milliseconds to skip for forward/reverse operations.</param>
		public async Task<Playback> PlayWithId(string bridgeId, string playbackId, string media, string lang = null, int? offsetms = null, int? skipms = null)
		{
			string path = "/bridges/{bridgeId}/play/{playbackId}";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(bridgeId != null)
				request.AddUrlSegment("bridgeId", bridgeId);
			if(playbackId != null)
				request.AddUrlSegment("playbackId", playbackId);
			if(media != null)
				request.AddParameter("media", media, ParameterType.QueryString);
			if(lang != null)
				request.AddParameter("lang", lang, ParameterType.QueryString);
			if(offsetms != null)
				request.AddParameter("offsetms", offsetms, ParameterType.QueryString);
			if(skipms != null)
				request.AddParameter("skipms", skipms, ParameterType.QueryString);

			var response = await ExecuteTask<Playback>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Bridge not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Bridge not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Start a recording.. This records the mixed audio from all channels participating in this bridge.
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="name">Recording's filename</param>
		/// <param name="format">Format to encode audio in</param>
		/// <param name="maxDurationSeconds">Maximum duration of the recording, in seconds. 0 for no limit.</param>
		/// <param name="maxSilenceSeconds">Maximum duration of silence, in seconds. 0 for no limit.</param>
		/// <param name="ifExists">Action to take if a recording with the same name already exists.</param>
		/// <param name="beep">Play beep when recording begins</param>
		/// <param name="terminateOn">DTMF input to terminate recording.</param>
		public async Task<LiveRecording> Record(string bridgeId, string name, string format, int? maxDurationSeconds = null, int? maxSilenceSeconds = null, string ifExists = null, bool? beep = null, string terminateOn = null)
		{
			string path = "/bridges/{bridgeId}/record";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(bridgeId != null)
				request.AddUrlSegment("bridgeId", bridgeId);
			if(name != null)
				request.AddParameter("name", name, ParameterType.QueryString);
			if(format != null)
				request.AddParameter("format", format, ParameterType.QueryString);
			if(maxDurationSeconds != null)
				request.AddParameter("maxDurationSeconds", maxDurationSeconds, ParameterType.QueryString);
			if(maxSilenceSeconds != null)
				request.AddParameter("maxSilenceSeconds", maxSilenceSeconds, ParameterType.QueryString);
			if(ifExists != null)
				request.AddParameter("ifExists", ifExists, ParameterType.QueryString);
			if(beep != null)
				request.AddParameter("beep", beep, ParameterType.QueryString);
			if(terminateOn != null)
				request.AddParameter("terminateOn", terminateOn, ParameterType.QueryString);

			var response = await ExecuteTask<LiveRecording>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("Invalid parameters", (int)response.StatusCode);
				case 404:
					throw new AriException("Bridge not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Bridge is not in a Stasis application; A recording with the same name already exists on the system and can not be overwritten because it is in progress or ifExists=fail", (int)response.StatusCode);
				case 422:
					throw new AriException("The format specified is unknown on this system", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
	}
}

