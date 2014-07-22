/*
	AsterNET ARI Framework
	Automatically generated file @ 22/07/2014 19:01:01
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;
using AsterNET.ARI;
using RestSharp;

namespace AsterNET.ARI.Actions
{
	
	public class ChannelsActions : ARIBaseAction
	{

		public ChannelsActions(StasisEndpoint endPoint)
			: base(endPoint)
		{}

		/// <summary>
		/// List all active channels in Asterisk.. 
		/// </summary>
		public List<Channel> List()
		{
			string path = "/channels";
			var request = GetNewRequest(path, Method.GET);

			var response = Client.Execute<List<Channel>>(request);

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
		/// Create a new channel (originate).. The new channel is created immediately and a snapshot of it returned. If a Stasis application is provided it will be automatically subscribed to the originated channel for further events and updates.
		/// </summary>
		/// <param name="endpoint">Endpoint to call.</param>
		/// <param name="extension">The extension to dial after the endpoint answers</param>
		/// <param name="context">The context to dial after the endpoint answers. If omitted, uses 'default'</param>
		/// <param name="priority">The priority to dial after the endpoint answers. If omitted, uses 1</param>
		/// <param name="app">The application that is subscribed to the originated channel, and passed to the Stasis application.</param>
		/// <param name="appArgs">The application arguments to pass to the Stasis application.</param>
		/// <param name="callerId">CallerID to use when dialing the endpoint or extension.</param>
		/// <param name="timeout">Timeout (in seconds) before giving up dialing, or -1 for no timeout.</param>
		/// <param name="variables">The "variables" key in the body object holds variable key/value pairs to set on the channel on creation. Other keys in the body object are interpreted as query parameters. Ex. { "endpoint": "SIP/Alice", "variables": { "CALLERID(name)": "Alice" } }</param>
		/// <param name="channelId">The unique id to assign the channel on creation.</param>
		/// <param name="otherChannelId">The unique id to assign the second channel when using local channels.</param>
		public Channel Originate(string endpoint, string extension, string context, long priority, string app, string appArgs, string callerId, int timeout, List<KeyValuePair<string, string>> variables, string channelId, string otherChannelId)
		{
			string path = "/channels";
			var request = GetNewRequest(path, Method.POST);
			request.AddParameter("endpoint", endpoint, ParameterType.QueryString);
			request.AddParameter("extension", extension, ParameterType.QueryString);
			request.AddParameter("context", context, ParameterType.QueryString);
			request.AddParameter("priority", priority, ParameterType.QueryString);
			request.AddParameter("app", app, ParameterType.QueryString);
			request.AddParameter("appArgs", appArgs, ParameterType.QueryString);
			request.AddParameter("callerId", callerId, ParameterType.QueryString);
			request.AddParameter("timeout", timeout, ParameterType.QueryString);
			request.AddParameter("variables", variables, ParameterType.QueryString);
			request.AddParameter("channelId", channelId, ParameterType.QueryString);
			request.AddParameter("otherChannelId", otherChannelId, ParameterType.QueryString);

			var response = Client.Execute<Channel>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;

			switch((int)response.StatusCode)
            {
				case 400:
					throw new ARIException("Invalid parameters for originating a channel.");
					break;
				default:
					// Unknown server response
					throw new ARIException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
		/// <summary>
		/// Channel details.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		public Channel Get(string channelId)
		{
			string path = "/channels/{channelId}";
			var request = GetNewRequest(path, Method.GET);
			request.AddUrlSegment("channelId", channelId);

			var response = Client.Execute<Channel>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;

			switch((int)response.StatusCode)
            {
				case 404:
					throw new ARIException("Channel not found");
					break;
				default:
					// Unknown server response
					throw new ARIException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
		/// <summary>
		/// Create a new channel (originate with id).. The new channel is created immediately and a snapshot of it returned. If a Stasis application is provided it will be automatically subscribed to the originated channel for further events and updates.
		/// </summary>
		/// <param name="channelId">The unique id to assign the channel on creation.</param>
		/// <param name="endpoint">Endpoint to call.</param>
		/// <param name="extension">The extension to dial after the endpoint answers</param>
		/// <param name="context">The context to dial after the endpoint answers. If omitted, uses 'default'</param>
		/// <param name="priority">The priority to dial after the endpoint answers. If omitted, uses 1</param>
		/// <param name="app">The application that is subscribed to the originated channel, and passed to the Stasis application.</param>
		/// <param name="appArgs">The application arguments to pass to the Stasis application.</param>
		/// <param name="callerId">CallerID to use when dialing the endpoint or extension.</param>
		/// <param name="timeout">Timeout (in seconds) before giving up dialing, or -1 for no timeout.</param>
		/// <param name="variables">The "variables" key in the body object holds variable key/value pairs to set on the channel on creation. Other keys in the body object are interpreted as query parameters. Ex. { "endpoint": "SIP/Alice", "variables": { "CALLERID(name)": "Alice" } }</param>
		/// <param name="otherChannelId">The unique id to assign the second channel when using local channels.</param>
		public Channel OriginateWithId(string channelId, string endpoint, string extension, string context, long priority, string app, string appArgs, string callerId, int timeout, List<KeyValuePair<string, string>> variables, string otherChannelId)
		{
			string path = "/channels/{channelId}";
			var request = GetNewRequest(path, Method.POST);
			request.AddUrlSegment("channelId", channelId);
			request.AddParameter("endpoint", endpoint, ParameterType.QueryString);
			request.AddParameter("extension", extension, ParameterType.QueryString);
			request.AddParameter("context", context, ParameterType.QueryString);
			request.AddParameter("priority", priority, ParameterType.QueryString);
			request.AddParameter("app", app, ParameterType.QueryString);
			request.AddParameter("appArgs", appArgs, ParameterType.QueryString);
			request.AddParameter("callerId", callerId, ParameterType.QueryString);
			request.AddParameter("timeout", timeout, ParameterType.QueryString);
			request.AddParameter("variables", variables, ParameterType.QueryString);
			request.AddParameter("otherChannelId", otherChannelId, ParameterType.QueryString);

			var response = Client.Execute<Channel>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;

			switch((int)response.StatusCode)
            {
				case 400:
					throw new ARIException("Invalid parameters for originating a channel.");
					break;
				default:
					// Unknown server response
					throw new ARIException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
		/// <summary>
		/// Delete (i.e. hangup) a channel.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="reason">Reason for hanging up the channel</param>
		public void Hangup(string channelId, string reason)
		{
			string path = "/channels/{channelId}";
			var request = GetNewRequest(path, Method.DELETE);
			request.AddUrlSegment("channelId", channelId);
			request.AddParameter("reason", reason, ParameterType.QueryString);
			var response = Client.Execute(request);
		}
		/// <summary>
		/// Exit application; continue execution in the dialplan.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="context">The context to continue to.</param>
		/// <param name="extension">The extension to continue to.</param>
		/// <param name="priority">The priority to continue to.</param>
		public void ContinueInDialplan(string channelId, string context, string extension, int priority)
		{
			string path = "/channels/{channelId}/continue";
			var request = GetNewRequest(path, Method.POST);
			request.AddUrlSegment("channelId", channelId);
			request.AddParameter("context", context, ParameterType.QueryString);
			request.AddParameter("extension", extension, ParameterType.QueryString);
			request.AddParameter("priority", priority, ParameterType.QueryString);
			var response = Client.Execute(request);
		}
		/// <summary>
		/// Answer a channel.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		public void Answer(string channelId)
		{
			string path = "/channels/{channelId}/answer";
			var request = GetNewRequest(path, Method.POST);
			request.AddUrlSegment("channelId", channelId);
			var response = Client.Execute(request);
		}
		/// <summary>
		/// Indicate ringing to a channel.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		public void Ring(string channelId)
		{
			string path = "/channels/{channelId}/ring";
			var request = GetNewRequest(path, Method.POST);
			request.AddUrlSegment("channelId", channelId);
			var response = Client.Execute(request);
		}
		/// <summary>
		/// Stop ringing indication on a channel if locally generated.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		public void RingStop(string channelId)
		{
			string path = "/channels/{channelId}/ring";
			var request = GetNewRequest(path, Method.DELETE);
			request.AddUrlSegment("channelId", channelId);
			var response = Client.Execute(request);
		}
		/// <summary>
		/// Send provided DTMF to a given channel.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="dtmf">DTMF To send.</param>
		/// <param name="before">Amount of time to wait before DTMF digits (specified in milliseconds) start.</param>
		/// <param name="between">Amount of time in between DTMF digits (specified in milliseconds).</param>
		/// <param name="duration">Length of each DTMF digit (specified in milliseconds).</param>
		/// <param name="after">Amount of time to wait after DTMF digits (specified in milliseconds) end.</param>
		public void SendDTMF(string channelId, string dtmf, int before, int between, int duration, int after)
		{
			string path = "/channels/{channelId}/dtmf";
			var request = GetNewRequest(path, Method.POST);
			request.AddUrlSegment("channelId", channelId);
			request.AddParameter("dtmf", dtmf, ParameterType.QueryString);
			request.AddParameter("before", before, ParameterType.QueryString);
			request.AddParameter("between", between, ParameterType.QueryString);
			request.AddParameter("duration", duration, ParameterType.QueryString);
			request.AddParameter("after", after, ParameterType.QueryString);
			var response = Client.Execute(request);
		}
		/// <summary>
		/// Mute a channel.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="direction">Direction in which to mute audio</param>
		public void Mute(string channelId, string direction)
		{
			string path = "/channels/{channelId}/mute";
			var request = GetNewRequest(path, Method.POST);
			request.AddUrlSegment("channelId", channelId);
			request.AddParameter("direction", direction, ParameterType.QueryString);
			var response = Client.Execute(request);
		}
		/// <summary>
		/// Unmute a channel.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="direction">Direction in which to unmute audio</param>
		public void Unmute(string channelId, string direction)
		{
			string path = "/channels/{channelId}/mute";
			var request = GetNewRequest(path, Method.DELETE);
			request.AddUrlSegment("channelId", channelId);
			request.AddParameter("direction", direction, ParameterType.QueryString);
			var response = Client.Execute(request);
		}
		/// <summary>
		/// Hold a channel.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		public void Hold(string channelId)
		{
			string path = "/channels/{channelId}/hold";
			var request = GetNewRequest(path, Method.POST);
			request.AddUrlSegment("channelId", channelId);
			var response = Client.Execute(request);
		}
		/// <summary>
		/// Remove a channel from hold.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		public void Unhold(string channelId)
		{
			string path = "/channels/{channelId}/hold";
			var request = GetNewRequest(path, Method.DELETE);
			request.AddUrlSegment("channelId", channelId);
			var response = Client.Execute(request);
		}
		/// <summary>
		/// Play music on hold to a channel.. Using media operations such as /play on a channel playing MOH in this manner will suspend MOH without resuming automatically. If continuing music on hold is desired, the stasis application must reinitiate music on hold.
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="mohClass">Music on hold class to use</param>
		public void StartMoh(string channelId, string mohClass)
		{
			string path = "/channels/{channelId}/moh";
			var request = GetNewRequest(path, Method.POST);
			request.AddUrlSegment("channelId", channelId);
			request.AddParameter("mohClass", mohClass, ParameterType.QueryString);
			var response = Client.Execute(request);
		}
		/// <summary>
		/// Stop playing music on hold to a channel.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		public void StopMoh(string channelId)
		{
			string path = "/channels/{channelId}/moh";
			var request = GetNewRequest(path, Method.DELETE);
			request.AddUrlSegment("channelId", channelId);
			var response = Client.Execute(request);
		}
		/// <summary>
		/// Play silence to a channel.. Using media operations such as /play on a channel playing silence in this manner will suspend silence without resuming automatically.
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		public void StartSilence(string channelId)
		{
			string path = "/channels/{channelId}/silence";
			var request = GetNewRequest(path, Method.POST);
			request.AddUrlSegment("channelId", channelId);
			var response = Client.Execute(request);
		}
		/// <summary>
		/// Stop playing silence to a channel.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		public void StopSilence(string channelId)
		{
			string path = "/channels/{channelId}/silence";
			var request = GetNewRequest(path, Method.DELETE);
			request.AddUrlSegment("channelId", channelId);
			var response = Client.Execute(request);
		}
		/// <summary>
		/// Start playback of media.. The media URI may be any of a number of URI's. Currently sound:, recording:, number:, digits:, characters:, and tone: URI's are supported. This operation creates a playback resource that can be used to control the playback of media (pause, rewind, fast forward, etc.)
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="media">Media's URI to play.</param>
		/// <param name="lang">For sounds, selects language for sound.</param>
		/// <param name="offsetms">Number of media to skip before playing.</param>
		/// <param name="skipms">Number of milliseconds to skip for forward/reverse operations.</param>
		/// <param name="playbackId">Playback ID.</param>
		public Playback Play(string channelId, string media, string lang, int offsetms, int skipms, string playbackId)
		{
			string path = "/channels/{channelId}/play";
			var request = GetNewRequest(path, Method.POST);
			request.AddUrlSegment("channelId", channelId);
			request.AddParameter("media", media, ParameterType.QueryString);
			request.AddParameter("lang", lang, ParameterType.QueryString);
			request.AddParameter("offsetms", offsetms, ParameterType.QueryString);
			request.AddParameter("skipms", skipms, ParameterType.QueryString);
			request.AddParameter("playbackId", playbackId, ParameterType.QueryString);

			var response = Client.Execute<Playback>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;

			switch((int)response.StatusCode)
            {
				case 404:
					throw new ARIException("Channel not found");
					break;
				case 409:
					throw new ARIException("Channel not in a Stasis application");
					break;
				default:
					// Unknown server response
					throw new ARIException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
		/// <summary>
		/// Start playback of media and specify the playbackId.. The media URI may be any of a number of URI's. Currently sound: and recording: URI's are supported. This operation creates a playback resource that can be used to control the playback of media (pause, rewind, fast forward, etc.)
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="playbackId">Playback ID.</param>
		/// <param name="media">Media's URI to play.</param>
		/// <param name="lang">For sounds, selects language for sound.</param>
		/// <param name="offsetms">Number of media to skip before playing.</param>
		/// <param name="skipms">Number of milliseconds to skip for forward/reverse operations.</param>
		public Playback PlayWithId(string channelId, string playbackId, string media, string lang, int offsetms, int skipms)
		{
			string path = "/channels/{channelId}/play/{playbackId}";
			var request = GetNewRequest(path, Method.POST);
			request.AddUrlSegment("channelId", channelId);
			request.AddUrlSegment("playbackId", playbackId);
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
					throw new ARIException("Channel not found");
					break;
				case 409:
					throw new ARIException("Channel not in a Stasis application");
					break;
				default:
					// Unknown server response
					throw new ARIException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
		/// <summary>
		/// Start a recording.. Record audio from a channel. Note that this will not capture audio sent to the channel. The bridge itself has a record feature if that's what you want.
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="name">Recording's filename</param>
		/// <param name="format">Format to encode audio in</param>
		/// <param name="maxDurationSeconds">Maximum duration of the recording, in seconds. 0 for no limit</param>
		/// <param name="maxSilenceSeconds">Maximum duration of silence, in seconds. 0 for no limit</param>
		/// <param name="ifExists">Action to take if a recording with the same name already exists.</param>
		/// <param name="beep">Play beep when recording begins</param>
		/// <param name="terminateOn">DTMF input to terminate recording</param>
		public LiveRecording Record(string channelId, string name, string format, int maxDurationSeconds, int maxSilenceSeconds, string ifExists, bool beep, string terminateOn)
		{
			string path = "/channels/{channelId}/record";
			var request = GetNewRequest(path, Method.POST);
			request.AddUrlSegment("channelId", channelId);
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
					throw new ARIException("Channel not found");
					break;
				case 409:
					throw new ARIException("Channel is not in a Stasis application; the channel is currently bridged with other hcannels; A recording with the same name already exists on the system and can not be overwritten because it is in progress or ifExists=fail");
					break;
				case 422:
					throw new ARIException("The format specified is unknown on this system");
					break;
				default:
					// Unknown server response
					throw new ARIException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
		/// <summary>
		/// Get the value of a channel variable or function.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="variable">The channel variable or function to get</param>
		public Variable GetChannelVar(string channelId, string variable)
		{
			string path = "/channels/{channelId}/variable";
			var request = GetNewRequest(path, Method.GET);
			request.AddUrlSegment("channelId", channelId);
			request.AddParameter("variable", variable, ParameterType.QueryString);

			var response = Client.Execute<Variable>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;

			switch((int)response.StatusCode)
            {
				case 400:
					throw new ARIException("Missing variable parameter.");
					break;
				case 404:
					throw new ARIException("Channel not found");
					break;
				case 409:
					throw new ARIException("Channel not in a Stasis application");
					break;
				default:
					// Unknown server response
					throw new ARIException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
		/// <summary>
		/// Set the value of a channel variable or function.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="variable">The channel variable or function to set</param>
		/// <param name="value">The value to set the variable to</param>
		public void SetChannelVar(string channelId, string variable, string value)
		{
			string path = "/channels/{channelId}/variable";
			var request = GetNewRequest(path, Method.POST);
			request.AddUrlSegment("channelId", channelId);
			request.AddParameter("variable", variable, ParameterType.QueryString);
			request.AddParameter("value", value, ParameterType.QueryString);
			var response = Client.Execute(request);
		}
		/// <summary>
		/// Start snooping.. Snoop (spy/whisper) on a specific channel.
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="spy">Direction of audio to spy on</param>
		/// <param name="whisper">Direction of audio to whisper into</param>
		/// <param name="app">Application the snooping channel is placed into</param>
		/// <param name="appArgs">The application arguments to pass to the Stasis application</param>
		/// <param name="snoopId">Unique ID to assign to snooping channel</param>
		public Channel SnoopChannel(string channelId, string spy, string whisper, string app, string appArgs, string snoopId)
		{
			string path = "/channels/{channelId}/snoop";
			var request = GetNewRequest(path, Method.POST);
			request.AddUrlSegment("channelId", channelId);
			request.AddParameter("spy", spy, ParameterType.QueryString);
			request.AddParameter("whisper", whisper, ParameterType.QueryString);
			request.AddParameter("app", app, ParameterType.QueryString);
			request.AddParameter("appArgs", appArgs, ParameterType.QueryString);
			request.AddParameter("snoopId", snoopId, ParameterType.QueryString);

			var response = Client.Execute<Channel>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;

			switch((int)response.StatusCode)
            {
				case 400:
					throw new ARIException("Invalid parameters");
					break;
				case 404:
					throw new ARIException("Channel not found");
					break;
				default:
					// Unknown server response
					throw new ARIException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
		/// <summary>
		/// Start snooping.. Snoop (spy/whisper) on a specific channel.
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="snoopId">Unique ID to assign to snooping channel</param>
		/// <param name="spy">Direction of audio to spy on</param>
		/// <param name="whisper">Direction of audio to whisper into</param>
		/// <param name="app">Application the snooping channel is placed into</param>
		/// <param name="appArgs">The application arguments to pass to the Stasis application</param>
		public Channel SnoopChannelWithId(string channelId, string snoopId, string spy, string whisper, string app, string appArgs)
		{
			string path = "/channels/{channelId}/snoop/{snoopId}";
			var request = GetNewRequest(path, Method.POST);
			request.AddUrlSegment("channelId", channelId);
			request.AddUrlSegment("snoopId", snoopId);
			request.AddParameter("spy", spy, ParameterType.QueryString);
			request.AddParameter("whisper", whisper, ParameterType.QueryString);
			request.AddParameter("app", app, ParameterType.QueryString);
			request.AddParameter("appArgs", appArgs, ParameterType.QueryString);

			var response = Client.Execute<Channel>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;

			switch((int)response.StatusCode)
            {
				case 400:
					throw new ARIException("Invalid parameters");
					break;
				case 404:
					throw new ARIException("Channel not found");
					break;
				default:
					// Unknown server response
					throw new ARIException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
	}
}

