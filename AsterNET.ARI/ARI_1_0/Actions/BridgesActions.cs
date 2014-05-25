/*
	AsterNET ARI Framework
	Automatically generated file @ 25/05/2014 20:39:48
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;
using AsterNET.ARI;
using RestSharp;

namespace AsterNET.ARI.Actions
{
	
	public class BridgesActions : ARIBaseAction
	{

		public BridgesActions(StasisEndpoint endPoint)
			: base(endPoint)
		{}

		/// <summary>
		/// List all active bridges in Asterisk.
		/// </summary>
		public List<Bridge> List()
		{
			string path = "/bridges";
			var request = GetNewRequest(path, Method.GET);

			var response = Client.Execute<List<Bridge>>(request);

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
		/// Create a new bridge.
		/// </summary>
		/// <param name="type">Type of bridge to create.</param>
		/// <param name="name">Name to give to the bridge being created.</param>
		public Bridge Create(string type, string name)
		{
			string path = "/bridges";
			var request = GetNewRequest(path, Method.POST);
			request.AddParameter("type", type, ParameterType.QueryString);
			request.AddParameter("name", name, ParameterType.QueryString);

			var response = Client.Execute<Bridge>(request);

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
		/// Get bridge details.
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		public Bridge Get(string bridgeId)
		{
			string path = "/bridges/{bridgeId}";
			var request = GetNewRequest(path, Method.GET);
			request.AddUrlSegment("bridgeId", bridgeId);

			var response = Client.Execute<Bridge>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;

			switch((int)response.StatusCode)
            {
				case 404:
					throw new ARIException("Bridge not found");
					break;
				default:
					// Unknown server response
					throw new ARIException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
		/// <summary>
		/// Shut down a bridge.
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		public void Destroy(string bridgeId)
		{
			string path = "/bridges/{bridgeId}";
			var request = GetNewRequest(path, Method.DELETE);
			request.AddUrlSegment("bridgeId", bridgeId);
			var response = Client.Execute(request);
		}
		/// <summary>
		/// Add a channel to a bridge.
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="channel">Ids of channels to add to bridge</param>
		/// <param name="role">Channel's role in the bridge</param>
		public void AddChannel(string bridgeId, string channel, string role)
		{
			string path = "/bridges/{bridgeId}/addChannel";
			var request = GetNewRequest(path, Method.POST);
			request.AddUrlSegment("bridgeId", bridgeId);
			request.AddParameter("channel", channel, ParameterType.QueryString);
			request.AddParameter("role", role, ParameterType.QueryString);
			var response = Client.Execute(request);
		}
		/// <summary>
		/// Remove a channel from a bridge.
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="channel">Ids of channels to remove from bridge</param>
		public void RemoveChannel(string bridgeId, string channel)
		{
			string path = "/bridges/{bridgeId}/removeChannel";
			var request = GetNewRequest(path, Method.POST);
			request.AddUrlSegment("bridgeId", bridgeId);
			request.AddParameter("channel", channel, ParameterType.QueryString);
			var response = Client.Execute(request);
		}
		/// <summary>
		/// Play music on hold to a bridge or change the MOH class that is playing.
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="mohClass">Channel's id</param>
		public void StartMoh(string bridgeId, string mohClass)
		{
			string path = "/bridges/{bridgeId}/moh";
			var request = GetNewRequest(path, Method.POST);
			request.AddUrlSegment("bridgeId", bridgeId);
			request.AddParameter("mohClass", mohClass, ParameterType.QueryString);
			var response = Client.Execute(request);
		}
		/// <summary>
		/// Stop playing music on hold to a bridge.
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		public void StopMoh(string bridgeId)
		{
			string path = "/bridges/{bridgeId}/moh";
			var request = GetNewRequest(path, Method.DELETE);
			request.AddUrlSegment("bridgeId", bridgeId);
			var response = Client.Execute(request);
		}
		/// <summary>
		/// Start playback of media on a bridge.
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="media">Media's URI to play.</param>
		/// <param name="lang">For sounds, selects language for sound.</param>
		/// <param name="offsetms">Number of media to skip before playing.</param>
		/// <param name="skipms">Number of milliseconds to skip for forward/reverse operations.</param>
		public Playback Play(string bridgeId, string media, string lang, int offsetms, int skipms)
		{
			string path = "/bridges/{bridgeId}/play";
			var request = GetNewRequest(path, Method.POST);
			request.AddUrlSegment("bridgeId", bridgeId);
			request.AddParameter("media", media, ParameterType.QueryString);
			request.AddParameter("lang", lang, ParameterType.QueryString);
			request.AddParameter("offsetms", offsetms, ParameterType.QueryString);
			request.AddParameter("skipms", skipms, ParameterType.QueryString);

			var response = Client.Execute<Playback>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;

			switch((int)response.StatusCode)
            {
				case 404:
					throw new ARIException("Bridge not found");
					break;
				case 409:
					throw new ARIException("Bridge not in a Stasis application");
					break;
				default:
					// Unknown server response
					throw new ARIException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
		/// <summary>
		/// Start a recording.
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="name">Recording's filename</param>
		/// <param name="format">Format to encode audio in</param>
		/// <param name="maxDurationSeconds">Maximum duration of the recording, in seconds. 0 for no limit.</param>
		/// <param name="maxSilenceSeconds">Maximum duration of silence, in seconds. 0 for no limit.</param>
		/// <param name="ifExists">Action to take if a recording with the same name already exists.</param>
		/// <param name="beep">Play beep when recording begins</param>
		/// <param name="terminateOn">DTMF input to terminate recording.</param>
		public LiveRecording Record(string bridgeId, string name, string format, int maxDurationSeconds, int maxSilenceSeconds, string ifExists, bool beep, string terminateOn)
		{
			string path = "/bridges/{bridgeId}/record";
			var request = GetNewRequest(path, Method.POST);
			request.AddUrlSegment("bridgeId", bridgeId);
			request.AddParameter("name", name, ParameterType.QueryString);
			request.AddParameter("format", format, ParameterType.QueryString);
			request.AddParameter("maxDurationSeconds", maxDurationSeconds, ParameterType.QueryString);
			request.AddParameter("maxSilenceSeconds", maxSilenceSeconds, ParameterType.QueryString);
			request.AddParameter("ifExists", ifExists, ParameterType.QueryString);
			request.AddParameter("beep", beep, ParameterType.QueryString);
			request.AddParameter("terminateOn", terminateOn, ParameterType.QueryString);

			var response = Client.Execute<LiveRecording>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;

			switch((int)response.StatusCode)
            {
				case 400:
					throw new ARIException("Invalid parameters");
					break;
				case 404:
					throw new ARIException("Bridge not found");
					break;
				case 409:
					throw new ARIException("Bridge is not in a Stasis application; A recording with the same name already exists on the system and can not be overwritten because it is in progress or ifExists=fail");
					break;
				case 422:
					throw new ARIException("The format specified is unknown on this system");
					break;
				default:
					// Unknown server response
					throw new ARIException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
	}
}

