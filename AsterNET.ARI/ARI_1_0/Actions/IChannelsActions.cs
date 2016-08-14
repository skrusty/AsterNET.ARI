/*
	AsterNET ARI Framework
	Automatically generated file @ 02/08/2016 20:28:17
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;
using AsterNET.ARI;

namespace AsterNET.ARI.Actions
{
	
	public interface IChannelsActions
	{
		/// <summary>
		/// List all active channels in Asterisk.. 
		/// </summary>
		List<Channel> List();
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
		Channel Originate(string endpoint, string extension = null, string context = null, long? priority = null, string label = null, string app = null, string appArgs = null, string callerId = null, int? timeout = null, Dictionary<string, string> variables = null, string channelId = null, string otherChannelId = null, string originator = null);
		/// <summary>
		/// Channel details.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		Channel Get(string channelId);
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
		Channel OriginateWithId(string channelId, string endpoint, string extension = null, string context = null, long? priority = null, string label = null, string app = null, string appArgs = null, string callerId = null, int? timeout = null, Dictionary<string, string> variables = null, string otherChannelId = null, string originator = null);
		/// <summary>
		/// Delete (i.e. hangup) a channel.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="reason">Reason for hanging up the channel</param>
		void Hangup(string channelId, string reason = null);
		/// <summary>
		/// Exit application; continue execution in the dialplan.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="context">The context to continue to.</param>
		/// <param name="extension">The extension to continue to.</param>
		/// <param name="priority">The priority to continue to.</param>
		/// <param name="label">The label to continue to - will supersede 'priority' if both are provided.</param>
		void ContinueInDialplan(string channelId, string context = null, string extension = null, int? priority = null, string label = null);
		/// <summary>
		/// Redirect the channel to a different location.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="endpoint">The endpoint to redirect the channel to</param>
		void Redirect(string channelId, string endpoint);
		/// <summary>
		/// Answer a channel.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		void Answer(string channelId);
		/// <summary>
		/// Indicate ringing to a channel.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		void Ring(string channelId);
		/// <summary>
		/// Stop ringing indication on a channel if locally generated.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		void RingStop(string channelId);
		/// <summary>
		/// Send provided DTMF to a given channel.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="dtmf">DTMF To send.</param>
		/// <param name="before">Amount of time to wait before DTMF digits (specified in milliseconds) start.</param>
		/// <param name="between">Amount of time in between DTMF digits (specified in milliseconds).</param>
		/// <param name="duration">Length of each DTMF digit (specified in milliseconds).</param>
		/// <param name="after">Amount of time to wait after DTMF digits (specified in milliseconds) end.</param>
		void SendDTMF(string channelId, string dtmf = null, int? before = null, int? between = null, int? duration = null, int? after = null);
		/// <summary>
		/// Mute a channel.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="direction">Direction in which to mute audio</param>
		void Mute(string channelId, string direction = null);
		/// <summary>
		/// Unmute a channel.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="direction">Direction in which to unmute audio</param>
		void Unmute(string channelId, string direction = null);
		/// <summary>
		/// Hold a channel.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		void Hold(string channelId);
		/// <summary>
		/// Remove a channel from hold.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		void Unhold(string channelId);
		/// <summary>
		/// Play music on hold to a channel.. Using media operations such as /play on a channel playing MOH in this manner will suspend MOH without resuming automatically. If continuing music on hold is desired, the stasis application must reinitiate music on hold.
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="mohClass">Music on hold class to use</param>
		void StartMoh(string channelId, string mohClass = null);
		/// <summary>
		/// Stop playing music on hold to a channel.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		void StopMoh(string channelId);
		/// <summary>
		/// Play silence to a channel.. Using media operations such as /play on a channel playing silence in this manner will suspend silence without resuming automatically.
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		void StartSilence(string channelId);
		/// <summary>
		/// Stop playing silence to a channel.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		void StopSilence(string channelId);
		/// <summary>
		/// Start playback of media.. The media URI may be any of a number of URI's. Currently sound:, recording:, number:, digits:, characters:, and tone: URI's are supported. This operation creates a playback resource that can be used to control the playback of media (pause, rewind, fast forward, etc.)
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="media">Media's URI to play.</param>
		/// <param name="lang">For sounds, selects language for sound.</param>
		/// <param name="offsetms">Number of media to skip before playing.</param>
		/// <param name="skipms">Number of milliseconds to skip for forward/reverse operations.</param>
		/// <param name="playbackId">Playback ID.</param>
		Playback Play(string channelId, string media, string lang = null, int? offsetms = null, int? skipms = null, string playbackId = null);
		/// <summary>
		/// Start playback of media and specify the playbackId.. The media URI may be any of a number of URI's. Currently sound:, recording:, number:, digits:, characters:, and tone: URI's are supported. This operation creates a playback resource that can be used to control the playback of media (pause, rewind, fast forward, etc.)
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="playbackId">Playback ID.</param>
		/// <param name="media">Media's URI to play.</param>
		/// <param name="lang">For sounds, selects language for sound.</param>
		/// <param name="offsetms">Number of media to skip before playing.</param>
		/// <param name="skipms">Number of milliseconds to skip for forward/reverse operations.</param>
		Playback PlayWithId(string channelId, string playbackId, string media, string lang = null, int? offsetms = null, int? skipms = null);
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
		LiveRecording Record(string channelId, string name, string format, int? maxDurationSeconds = null, int? maxSilenceSeconds = null, string ifExists = null, bool? beep = null, string terminateOn = null);
		/// <summary>
		/// Get the value of a channel variable or function.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="variable">The channel variable or function to get</param>
		Variable GetChannelVar(string channelId, string variable);
		/// <summary>
		/// Set the value of a channel variable or function.. 
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="variable">The channel variable or function to set</param>
		/// <param name="value">The value to set the variable to</param>
		void SetChannelVar(string channelId, string variable, string value = null);
		/// <summary>
		/// Start snooping.. Snoop (spy/whisper) on a specific channel.
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="spy">Direction of audio to spy on</param>
		/// <param name="whisper">Direction of audio to whisper into</param>
		/// <param name="app">Application the snooping channel is placed into</param>
		/// <param name="appArgs">The application arguments to pass to the Stasis application</param>
		/// <param name="snoopId">Unique ID to assign to snooping channel</param>
		Channel SnoopChannel(string channelId, string app, string spy = null, string whisper = null, string appArgs = null, string snoopId = null);
		/// <summary>
		/// Start snooping.. Snoop (spy/whisper) on a specific channel.
		/// </summary>
		/// <param name="channelId">Channel's id</param>
		/// <param name="snoopId">Unique ID to assign to snooping channel</param>
		/// <param name="spy">Direction of audio to spy on</param>
		/// <param name="whisper">Direction of audio to whisper into</param>
		/// <param name="app">Application the snooping channel is placed into</param>
		/// <param name="appArgs">The application arguments to pass to the Stasis application</param>
		Channel SnoopChannelWithId(string channelId, string snoopId, string app, string spy = null, string whisper = null, string appArgs = null);
	}
}
