/*
	AsterNET ARI Framework
	Automatically generated file @ 14/08/2016 18:59:17
*/
using System.Collections.Generic;
using System.Linq;
using AsterNET.ARI.Middleware;
using AsterNET.ARI.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AsterNET.ARI.Actions
{
	
	public class ChannelsActions : ARIBaseAction, IChannelsActions
	{

		public ChannelsActions(IActionConsumer consumer)
			: base(consumer)
		{}

		/// <summary>
		/// List all active channels in Asterisk.. 
		/// </summary>
		public List<Channel> List()
		{
			string path = "/channels";
			var request = GetNewRequest(path, HttpMethod.GET);

			var response = Execute<List<Channel>>(request);

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
		/// Create a new channel (originate).. The new channel is created immediately and a snapshot of it returned. If a Stasis application is provided it will be automatically subscribed to the originated channel for further events and updates.
		/// </summary>
		/// <param name="endpoint">Endpoint to call.</param>
		/// <param name="extension">The extension to dial after the endpoint answers. Mutually exclusive with 'app'.</param>
		/// <param name="context">The context to dial after the endpoint answers. If omitted, uses 'default'. Mutually exclusive with 'app'.</param>
		/// <param name="priority">The priority to dial after the endpoint answers. If omitted, uses 1. Mutually exclusive with 'app'.</param>
		/// <param name="label">The label to dial after the endpoint answers. Will supersede 'priority' if provided. Mutually exclusive with 'app'.</param>
		/// <param name="app">The application that is subscribed to the originated channel. When the channel is answered, it will be passed to this Stasis application. Mutually exclusive with 'context', 'extension', 'priority', and 'label'.</param>
		/// <param name="appArgs">The application arguments to pass to the Stasis application provided by 'app'. Mutually exclusive with 'context', 'extension', 'priority', and 'label'.</param>
		/// <param name="callerId">CallerID to use when dialing the endpoint or extension.</param>
		/// <param name="timeout">Timeout (in seconds) before giving up dialing, or -1 for no timeout.</param>
		/// <param name="variables">The "variables" key in the body object holds variable key/value pairs to set on the channel on creation. Other keys in the body object are interpreted as query parameters. Ex. { "endpoint": "SIP/Alice", "variables": { "CALLERID(name)": "Alice" } }</param>
		/// <param name="channelId">The unique id to assign the channel on creation.</param>
		/// <param name="otherChannelId">The unique id to assign the second channel when using local channels.</param>
		/// <param name="originator">The unique id of the channel which is originating this one.</param>
		public Channel Originate(string endpoint, string extension = null, string context = null, long? priority = null, string label = null, string app = null, string appArgs = null, string callerId = null, int? timeout = null, Dictionary<string, string> variables = null, string channelId = null, string otherChannelId = null, string originator = null)
		{
			string path = "/channels";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(endpoint != null)
				request.AddParameter("endpoint", endpoint, ParameterType.QueryString);
			if(extension != null)
				request.AddParameter("extension", extension, ParameterType.QueryString);
			if(context != null)
				request.AddParameter("context", context, ParameterType.QueryString);
			if(priority != null)
				request.AddParameter("priority", priority, ParameterType.QueryString);
			if(label != null)
				request.AddParameter("label", label, ParameterType.QueryString);
			if(app != null)
				request.AddParameter("app", app, ParameterType.QueryString);
			if(appArgs != null)
				request.AddParameter("appArgs", appArgs, ParameterType.QueryString);
			if(callerId != null)
				request.AddParameter("callerId", callerId, ParameterType.QueryString);
			if(timeout != null)
				request.AddParameter("timeout", timeout, ParameterType.QueryString);
			if(variables != null)
			{
				request.AddParameter("application/json", new { variables = variables }, ParameterType.RequestBody);
			}
			if(channelId != null)
				request.AddParameter("channelId", channelId, ParameterType.QueryString);
			if(otherChannelId != null)
				request.AddParameter("otherChannelId", otherChannelId, ParameterType.QueryString);
			if(originator != null)
				request.AddParameter("originator", originator, ParameterType.QueryString);

			var response = Execute<Channel>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("Invalid parameters for originating a channel.", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Channel details.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		public Channel Get(string channelId)
		{
			string path = "/channels/{channelId}";
			var request = GetNewRequest(path, HttpMethod.GET);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);

			var response = Execute<Channel>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Create a new channel (originate with id).. The new channel is created immediately and a snapshot of it returned. If a Stasis application is provided it will be automatically subscribed to the originated channel for further events and updates.
		/// </summary>
		/// <param name="channelId">The unique id to assign the channel on creation.</param>
		/// <param name="endpoint">Endpoint to call.</param>
		/// <param name="extension">The extension to dial after the endpoint answers. Mutually exclusive with 'app'.</param>
		/// <param name="context">The context to dial after the endpoint answers. If omitted, uses 'default'. Mutually exclusive with 'app'.</param>
		/// <param name="priority">The priority to dial after the endpoint answers. If omitted, uses 1. Mutually exclusive with 'app'.</param>
		/// <param name="label">The label to dial after the endpoint answers. Will supersede 'priority' if provided. Mutually exclusive with 'app'.</param>
		/// <param name="app">The application that is subscribed to the originated channel. When the channel is answered, it will be passed to this Stasis application. Mutually exclusive with 'context', 'extension', 'priority', and 'label'.</param>
		/// <param name="appArgs">The application arguments to pass to the Stasis application provided by 'app'. Mutually exclusive with 'context', 'extension', 'priority', and 'label'.</param>
		/// <param name="callerId">CallerID to use when dialing the endpoint or extension.</param>
		/// <param name="timeout">Timeout (in seconds) before giving up dialing, or -1 for no timeout.</param>
		/// <param name="variables">The "variables" key in the body object holds variable key/value pairs to set on the channel on creation. Other keys in the body object are interpreted as query parameters. Ex. { "endpoint": "SIP/Alice", "variables": { "CALLERID(name)": "Alice" } }</param>
		/// <param name="otherChannelId">The unique id to assign the second channel when using local channels.</param>
		/// <param name="originator">The unique id of the channel which is originating this one.</param>
		public Channel OriginateWithId(string channelId, string endpoint, string extension = null, string context = null, long? priority = null, string label = null, string app = null, string appArgs = null, string callerId = null, int? timeout = null, Dictionary<string, string> variables = null, string otherChannelId = null, string originator = null)
		{
			string path = "/channels/{channelId}";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			if(endpoint != null)
				request.AddParameter("endpoint", endpoint, ParameterType.QueryString);
			if(extension != null)
				request.AddParameter("extension", extension, ParameterType.QueryString);
			if(context != null)
				request.AddParameter("context", context, ParameterType.QueryString);
			if(priority != null)
				request.AddParameter("priority", priority, ParameterType.QueryString);
			if(label != null)
				request.AddParameter("label", label, ParameterType.QueryString);
			if(app != null)
				request.AddParameter("app", app, ParameterType.QueryString);
			if(appArgs != null)
				request.AddParameter("appArgs", appArgs, ParameterType.QueryString);
			if(callerId != null)
				request.AddParameter("callerId", callerId, ParameterType.QueryString);
			if(timeout != null)
				request.AddParameter("timeout", timeout, ParameterType.QueryString);
			if(variables != null)
			{
				request.AddParameter("application/json", new { variables = variables }, ParameterType.RequestBody);
			}
			if(otherChannelId != null)
				request.AddParameter("otherChannelId", otherChannelId, ParameterType.QueryString);
			if(originator != null)
				request.AddParameter("originator", originator, ParameterType.QueryString);

			var response = Execute<Channel>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("Invalid parameters for originating a channel.", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Delete (i.e. hangup) a channel.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="reason">Reason for hanging up the channel</param>
		public void Hangup(string channelId, string reason = null)
		{
			string path = "/channels/{channelId}";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			if(reason != null)
				request.AddParameter("reason", reason, ParameterType.QueryString);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("Invalid reason for hangup provided", (int)response.StatusCode);
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Exit application; continue execution in the dialplan.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="context">The context to continue to.</param>
		/// <param name="extension">The extension to continue to.</param>
		/// <param name="priority">The priority to continue to.</param>
		/// <param name="label">The label to continue to - will supersede 'priority' if both are provided.</param>
		public void ContinueInDialplan(string channelId, string context = null, string extension = null, int? priority = null, string label = null)
		{
			string path = "/channels/{channelId}/continue";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			if(context != null)
				request.AddParameter("context", context, ParameterType.QueryString);
			if(extension != null)
				request.AddParameter("extension", extension, ParameterType.QueryString);
			if(priority != null)
				request.AddParameter("priority", priority, ParameterType.QueryString);
			if(label != null)
				request.AddParameter("label", label, ParameterType.QueryString);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Redirect the channel to a different location.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="endpoint">The endpoint to redirect the channel to</param>
		public void Redirect(string channelId, string endpoint)
		{
			string path = "/channels/{channelId}/redirect";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			if(endpoint != null)
				request.AddParameter("endpoint", endpoint, ParameterType.QueryString);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("Endpoint parameter not provided", (int)response.StatusCode);
				case 404:
					throw new AriException("Channel or endpoint not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				case 422:
					throw new AriException("Endpoint is not the same type as the channel", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Answer a channel.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		public void Answer(string channelId)
		{
			string path = "/channels/{channelId}/answer";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Indicate ringing to a channel.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		public void Ring(string channelId)
		{
			string path = "/channels/{channelId}/ring";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Stop ringing indication on a channel if locally generated.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		public void RingStop(string channelId)
		{
			string path = "/channels/{channelId}/ring";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
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
		public void SendDTMF(string channelId, string dtmf = null, int? before = null, int? between = null, int? duration = null, int? after = null)
		{
			string path = "/channels/{channelId}/dtmf";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			if(dtmf != null)
				request.AddParameter("dtmf", dtmf, ParameterType.QueryString);
			if(before != null)
				request.AddParameter("before", before, ParameterType.QueryString);
			if(between != null)
				request.AddParameter("between", between, ParameterType.QueryString);
			if(duration != null)
				request.AddParameter("duration", duration, ParameterType.QueryString);
			if(after != null)
				request.AddParameter("after", after, ParameterType.QueryString);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("DTMF is required", (int)response.StatusCode);
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Mute a channel.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="direction">Direction in which to mute audio</param>
		public void Mute(string channelId, string direction = null)
		{
			string path = "/channels/{channelId}/mute";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			if(direction != null)
				request.AddParameter("direction", direction, ParameterType.QueryString);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Unmute a channel.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="direction">Direction in which to unmute audio</param>
		public void Unmute(string channelId, string direction = null)
		{
			string path = "/channels/{channelId}/mute";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			if(direction != null)
				request.AddParameter("direction", direction, ParameterType.QueryString);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Hold a channel.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		public void Hold(string channelId)
		{
			string path = "/channels/{channelId}/hold";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Remove a channel from hold.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		public void Unhold(string channelId)
		{
			string path = "/channels/{channelId}/hold";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Play music on hold to a channel.. Using media operations such as /play on a channel playing MOH in this manner will suspend MOH without resuming automatically. If continuing music on hold is desired, the stasis application must reinitiate music on hold.
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="mohClass">Music on hold class to use</param>
		public void StartMoh(string channelId, string mohClass = null)
		{
			string path = "/channels/{channelId}/moh";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			if(mohClass != null)
				request.AddParameter("mohClass", mohClass, ParameterType.QueryString);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Stop playing music on hold to a channel.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		public void StopMoh(string channelId)
		{
			string path = "/channels/{channelId}/moh";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Play silence to a channel.. Using media operations such as /play on a channel playing silence in this manner will suspend silence without resuming automatically.
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		public void StartSilence(string channelId)
		{
			string path = "/channels/{channelId}/silence";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Stop playing silence to a channel.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		public void StopSilence(string channelId)
		{
			string path = "/channels/{channelId}/silence";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
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
		public Playback Play(string channelId, string media, string lang = null, int? offsetms = null, int? skipms = null, string playbackId = null)
		{
			string path = "/channels/{channelId}/play";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
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

			var response = Execute<Playback>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Start playback of media and specify the playbackId.. The media URI may be any of a number of URI's. Currently sound:, recording:, number:, digits:, characters:, and tone: URI's are supported. This operation creates a playback resource that can be used to control the playback of media (pause, rewind, fast forward, etc.)
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="playbackId">Playback ID.</param>
		/// <param name="media">Media's URI to play.</param>
		/// <param name="lang">For sounds, selects language for sound.</param>
		/// <param name="offsetms">Number of media to skip before playing.</param>
		/// <param name="skipms">Number of milliseconds to skip for forward/reverse operations.</param>
		public Playback PlayWithId(string channelId, string playbackId, string media, string lang = null, int? offsetms = null, int? skipms = null)
		{
			string path = "/channels/{channelId}/play/{playbackId}";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
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

			var response = Execute<Playback>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
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
		public LiveRecording Record(string channelId, string name, string format, int? maxDurationSeconds = null, int? maxSilenceSeconds = null, string ifExists = null, bool? beep = null, string terminateOn = null)
		{
			string path = "/channels/{channelId}/record";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
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

			var response = Execute<LiveRecording>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("Invalid parameters", (int)response.StatusCode);
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel is not in a Stasis application; the channel is currently bridged with other hcannels; A recording with the same name already exists on the system and can not be overwritten because it is in progress or ifExists=fail", (int)response.StatusCode);
				case 422:
					throw new AriException("The format specified is unknown on this system", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
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
			var request = GetNewRequest(path, HttpMethod.GET);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			if(variable != null)
				request.AddParameter("variable", variable, ParameterType.QueryString);

			var response = Execute<Variable>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("Missing variable parameter.", (int)response.StatusCode);
				case 404:
					throw new AriException("Channel or variable not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Set the value of a channel variable or function.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="variable">The channel variable or function to set</param>
		/// <param name="value">The value to set the variable to</param>
		public void SetChannelVar(string channelId, string variable, string value = null)
		{
			string path = "/channels/{channelId}/variable";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			if(variable != null)
				request.AddParameter("variable", variable, ParameterType.QueryString);
			if(value != null)
				request.AddParameter("value", value, ParameterType.QueryString);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("Missing variable parameter.", (int)response.StatusCode);
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
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
		public Channel SnoopChannel(string channelId, string app, string spy = null, string whisper = null, string appArgs = null, string snoopId = null)
		{
			string path = "/channels/{channelId}/snoop";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			if(spy != null)
				request.AddParameter("spy", spy, ParameterType.QueryString);
			if(whisper != null)
				request.AddParameter("whisper", whisper, ParameterType.QueryString);
			if(app != null)
				request.AddParameter("app", app, ParameterType.QueryString);
			if(appArgs != null)
				request.AddParameter("appArgs", appArgs, ParameterType.QueryString);
			if(snoopId != null)
				request.AddParameter("snoopId", snoopId, ParameterType.QueryString);

			var response = Execute<Channel>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("Invalid parameters", (int)response.StatusCode);
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
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
		public Channel SnoopChannelWithId(string channelId, string snoopId, string app, string spy = null, string whisper = null, string appArgs = null)
		{
			string path = "/channels/{channelId}/snoop/{snoopId}";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			if(snoopId != null)
				request.AddUrlSegment("snoopId", snoopId);
			if(spy != null)
				request.AddParameter("spy", spy, ParameterType.QueryString);
			if(whisper != null)
				request.AddParameter("whisper", whisper, ParameterType.QueryString);
			if(app != null)
				request.AddParameter("app", app, ParameterType.QueryString);
			if(appArgs != null)
				request.AddParameter("appArgs", appArgs, ParameterType.QueryString);

			var response = Execute<Channel>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("Invalid parameters", (int)response.StatusCode);
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}

		/// <summary>
		/// List all active channels in Asterisk.. 
		/// </summary>
		public async Task<List<Channel>> ListAsync()
		{
			string path = "/channels";
			var request = GetNewRequest(path, HttpMethod.GET);

			var response = await ExecuteTask<List<Channel>>(request);

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
		/// Create a new channel (originate).. The new channel is created immediately and a snapshot of it returned. If a Stasis application is provided it will be automatically subscribed to the originated channel for further events and updates.
		/// </summary>
		public async Task<Channel> OriginateAsync(string endpoint, string extension = null, string context = null, long? priority = null, string label = null, string app = null, string appArgs = null, string callerId = null, int? timeout = null, Dictionary<string, string> variables = null, string channelId = null, string otherChannelId = null, string originator = null)
		{
			string path = "/channels";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(endpoint != null)
				request.AddParameter("endpoint", endpoint, ParameterType.QueryString);
			if(extension != null)
				request.AddParameter("extension", extension, ParameterType.QueryString);
			if(context != null)
				request.AddParameter("context", context, ParameterType.QueryString);
			if(priority != null)
				request.AddParameter("priority", priority, ParameterType.QueryString);
			if(label != null)
				request.AddParameter("label", label, ParameterType.QueryString);
			if(app != null)
				request.AddParameter("app", app, ParameterType.QueryString);
			if(appArgs != null)
				request.AddParameter("appArgs", appArgs, ParameterType.QueryString);
			if(callerId != null)
				request.AddParameter("callerId", callerId, ParameterType.QueryString);
			if(timeout != null)
				request.AddParameter("timeout", timeout, ParameterType.QueryString);
			if(variables != null)
			{
				request.AddParameter("application/json", new { variables = variables }, ParameterType.RequestBody);
			}
			if(channelId != null)
				request.AddParameter("channelId", channelId, ParameterType.QueryString);
			if(otherChannelId != null)
				request.AddParameter("otherChannelId", otherChannelId, ParameterType.QueryString);
			if(originator != null)
				request.AddParameter("originator", originator, ParameterType.QueryString);

			var response = await ExecuteTask<Channel>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("Invalid parameters for originating a channel.", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Channel details.. 
		/// </summary>
		public async Task<Channel> GetAsync(string channelId)
		{
			string path = "/channels/{channelId}";
			var request = GetNewRequest(path, HttpMethod.GET);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);

			var response = await ExecuteTask<Channel>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Create a new channel (originate with id).. The new channel is created immediately and a snapshot of it returned. If a Stasis application is provided it will be automatically subscribed to the originated channel for further events and updates.
		/// </summary>
		public async Task<Channel> OriginateWithIdAsync(string channelId, string endpoint, string extension = null, string context = null, long? priority = null, string label = null, string app = null, string appArgs = null, string callerId = null, int? timeout = null, Dictionary<string, string> variables = null, string otherChannelId = null, string originator = null)
		{
			string path = "/channels/{channelId}";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			if(endpoint != null)
				request.AddParameter("endpoint", endpoint, ParameterType.QueryString);
			if(extension != null)
				request.AddParameter("extension", extension, ParameterType.QueryString);
			if(context != null)
				request.AddParameter("context", context, ParameterType.QueryString);
			if(priority != null)
				request.AddParameter("priority", priority, ParameterType.QueryString);
			if(label != null)
				request.AddParameter("label", label, ParameterType.QueryString);
			if(app != null)
				request.AddParameter("app", app, ParameterType.QueryString);
			if(appArgs != null)
				request.AddParameter("appArgs", appArgs, ParameterType.QueryString);
			if(callerId != null)
				request.AddParameter("callerId", callerId, ParameterType.QueryString);
			if(timeout != null)
				request.AddParameter("timeout", timeout, ParameterType.QueryString);
			if(variables != null)
			{
				request.AddParameter("application/json", new { variables = variables }, ParameterType.RequestBody);
			}
			if(otherChannelId != null)
				request.AddParameter("otherChannelId", otherChannelId, ParameterType.QueryString);
			if(originator != null)
				request.AddParameter("originator", originator, ParameterType.QueryString);

			var response = await ExecuteTask<Channel>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("Invalid parameters for originating a channel.", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Delete (i.e. hangup) a channel.. 
		/// </summary>
		public async Task HangupAsync(string channelId, string reason = null)
		{
			string path = "/channels/{channelId}";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			if(reason != null)
				request.AddParameter("reason", reason, ParameterType.QueryString);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("Invalid reason for hangup provided", (int)response.StatusCode);
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Exit application; continue execution in the dialplan.. 
		/// </summary>
		public async Task ContinueInDialplanAsync(string channelId, string context = null, string extension = null, int? priority = null, string label = null)
		{
			string path = "/channels/{channelId}/continue";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			if(context != null)
				request.AddParameter("context", context, ParameterType.QueryString);
			if(extension != null)
				request.AddParameter("extension", extension, ParameterType.QueryString);
			if(priority != null)
				request.AddParameter("priority", priority, ParameterType.QueryString);
			if(label != null)
				request.AddParameter("label", label, ParameterType.QueryString);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Redirect the channel to a different location.. 
		/// </summary>
		public async Task RedirectAsync(string channelId, string endpoint)
		{
			string path = "/channels/{channelId}/redirect";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			if(endpoint != null)
				request.AddParameter("endpoint", endpoint, ParameterType.QueryString);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("Endpoint parameter not provided", (int)response.StatusCode);
				case 404:
					throw new AriException("Channel or endpoint not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				case 422:
					throw new AriException("Endpoint is not the same type as the channel", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Answer a channel.. 
		/// </summary>
		public async Task AnswerAsync(string channelId)
		{
			string path = "/channels/{channelId}/answer";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Indicate ringing to a channel.. 
		/// </summary>
		public async Task RingAsync(string channelId)
		{
			string path = "/channels/{channelId}/ring";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Stop ringing indication on a channel if locally generated.. 
		/// </summary>
		public async Task RingStopAsync(string channelId)
		{
			string path = "/channels/{channelId}/ring";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Send provided DTMF to a given channel.. 
		/// </summary>
		public async Task SendDTMFAsync(string channelId, string dtmf = null, int? before = null, int? between = null, int? duration = null, int? after = null)
		{
			string path = "/channels/{channelId}/dtmf";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			if(dtmf != null)
				request.AddParameter("dtmf", dtmf, ParameterType.QueryString);
			if(before != null)
				request.AddParameter("before", before, ParameterType.QueryString);
			if(between != null)
				request.AddParameter("between", between, ParameterType.QueryString);
			if(duration != null)
				request.AddParameter("duration", duration, ParameterType.QueryString);
			if(after != null)
				request.AddParameter("after", after, ParameterType.QueryString);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("DTMF is required", (int)response.StatusCode);
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Mute a channel.. 
		/// </summary>
		public async Task MuteAsync(string channelId, string direction = null)
		{
			string path = "/channels/{channelId}/mute";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			if(direction != null)
				request.AddParameter("direction", direction, ParameterType.QueryString);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Unmute a channel.. 
		/// </summary>
		public async Task UnmuteAsync(string channelId, string direction = null)
		{
			string path = "/channels/{channelId}/mute";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			if(direction != null)
				request.AddParameter("direction", direction, ParameterType.QueryString);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Hold a channel.. 
		/// </summary>
		public async Task HoldAsync(string channelId)
		{
			string path = "/channels/{channelId}/hold";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Remove a channel from hold.. 
		/// </summary>
		public async Task UnholdAsync(string channelId)
		{
			string path = "/channels/{channelId}/hold";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Play music on hold to a channel.. Using media operations such as /play on a channel playing MOH in this manner will suspend MOH without resuming automatically. If continuing music on hold is desired, the stasis application must reinitiate music on hold.
		/// </summary>
		public async Task StartMohAsync(string channelId, string mohClass = null)
		{
			string path = "/channels/{channelId}/moh";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			if(mohClass != null)
				request.AddParameter("mohClass", mohClass, ParameterType.QueryString);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Stop playing music on hold to a channel.. 
		/// </summary>
		public async Task StopMohAsync(string channelId)
		{
			string path = "/channels/{channelId}/moh";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Play silence to a channel.. Using media operations such as /play on a channel playing silence in this manner will suspend silence without resuming automatically.
		/// </summary>
		public async Task StartSilenceAsync(string channelId)
		{
			string path = "/channels/{channelId}/silence";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Stop playing silence to a channel.. 
		/// </summary>
		public async Task StopSilenceAsync(string channelId)
		{
			string path = "/channels/{channelId}/silence";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Start playback of media.. The media URI may be any of a number of URI's. Currently sound:, recording:, number:, digits:, characters:, and tone: URI's are supported. This operation creates a playback resource that can be used to control the playback of media (pause, rewind, fast forward, etc.)
		/// </summary>
		public async Task<Playback> PlayAsync(string channelId, string media, string lang = null, int? offsetms = null, int? skipms = null, string playbackId = null)
		{
			string path = "/channels/{channelId}/play";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
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
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Start playback of media and specify the playbackId.. The media URI may be any of a number of URI's. Currently sound:, recording:, number:, digits:, characters:, and tone: URI's are supported. This operation creates a playback resource that can be used to control the playback of media (pause, rewind, fast forward, etc.)
		/// </summary>
		public async Task<Playback> PlayWithIdAsync(string channelId, string playbackId, string media, string lang = null, int? offsetms = null, int? skipms = null)
		{
			string path = "/channels/{channelId}/play/{playbackId}";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
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
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Start a recording.. Record audio from a channel. Note that this will not capture audio sent to the channel. The bridge itself has a record feature if that's what you want.
		/// </summary>
		public async Task<LiveRecording> RecordAsync(string channelId, string name, string format, int? maxDurationSeconds = null, int? maxSilenceSeconds = null, string ifExists = null, bool? beep = null, string terminateOn = null)
		{
			string path = "/channels/{channelId}/record";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
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
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel is not in a Stasis application; the channel is currently bridged with other hcannels; A recording with the same name already exists on the system and can not be overwritten because it is in progress or ifExists=fail", (int)response.StatusCode);
				case 422:
					throw new AriException("The format specified is unknown on this system", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Get the value of a channel variable or function.. 
		/// </summary>
		public async Task<Variable> GetChannelVarAsync(string channelId, string variable)
		{
			string path = "/channels/{channelId}/variable";
			var request = GetNewRequest(path, HttpMethod.GET);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			if(variable != null)
				request.AddParameter("variable", variable, ParameterType.QueryString);

			var response = await ExecuteTask<Variable>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("Missing variable parameter.", (int)response.StatusCode);
				case 404:
					throw new AriException("Channel or variable not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Set the value of a channel variable or function.. 
		/// </summary>
		public async Task SetChannelVarAsync(string channelId, string variable, string value = null)
		{
			string path = "/channels/{channelId}/variable";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			if(variable != null)
				request.AddParameter("variable", variable, ParameterType.QueryString);
			if(value != null)
				request.AddParameter("value", value, ParameterType.QueryString);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("Missing variable parameter.", (int)response.StatusCode);
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				case 409:
					throw new AriException("Channel not in a Stasis application", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Start snooping.. Snoop (spy/whisper) on a specific channel.
		/// </summary>
		public async Task<Channel> SnoopChannelAsync(string channelId, string app, string spy = null, string whisper = null, string appArgs = null, string snoopId = null)
		{
			string path = "/channels/{channelId}/snoop";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			if(spy != null)
				request.AddParameter("spy", spy, ParameterType.QueryString);
			if(whisper != null)
				request.AddParameter("whisper", whisper, ParameterType.QueryString);
			if(app != null)
				request.AddParameter("app", app, ParameterType.QueryString);
			if(appArgs != null)
				request.AddParameter("appArgs", appArgs, ParameterType.QueryString);
			if(snoopId != null)
				request.AddParameter("snoopId", snoopId, ParameterType.QueryString);

			var response = await ExecuteTask<Channel>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("Invalid parameters", (int)response.StatusCode);
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Start snooping.. Snoop (spy/whisper) on a specific channel.
		/// </summary>
		public async Task<Channel> SnoopChannelWithIdAsync(string channelId, string snoopId, string app, string spy = null, string whisper = null, string appArgs = null)
		{
			string path = "/channels/{channelId}/snoop/{snoopId}";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(channelId != null)
				request.AddUrlSegment("channelId", channelId);
			if(snoopId != null)
				request.AddUrlSegment("snoopId", snoopId);
			if(spy != null)
				request.AddParameter("spy", spy, ParameterType.QueryString);
			if(whisper != null)
				request.AddParameter("whisper", whisper, ParameterType.QueryString);
			if(app != null)
				request.AddParameter("app", app, ParameterType.QueryString);
			if(appArgs != null)
				request.AddParameter("appArgs", appArgs, ParameterType.QueryString);

			var response = await ExecuteTask<Channel>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("Invalid parameters", (int)response.StatusCode);
				case 404:
					throw new AriException("Channel not found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
	}
}

