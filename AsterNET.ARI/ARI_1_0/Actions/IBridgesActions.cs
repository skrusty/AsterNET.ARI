/*
	AsterNET ARI Framework
	Automatically generated file @ 31/08/2020 12:42:41
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;
using AsterNET.ARI;
using System.Threading.Tasks;

namespace AsterNET.ARI.Actions
{
	
	public interface IBridgesActions
	{
		/// <summary>
		/// List all active bridges in Asterisk.. 
		/// </summary>
		List<Bridge> List();
		/// <summary>
		/// Create a new bridge.. This bridge persists until it has been shut down, or Asterisk has been shut down.
		/// </summary>
		/// <param name="type">Comma separated list of bridge type attributes (mixing, holding, dtmf_events, proxy_media, video_sfu).</param>
		/// <param name="bridgeId">Unique ID to give to the bridge being created.</param>
		/// <param name="name">Name to give to the bridge being created.</param>
		Bridge Create(string type = null, string bridgeId = null, string name = null);
		/// <summary>
		/// Create a new bridge or updates an existing one.. This bridge persists until it has been shut down, or Asterisk has been shut down.
		/// </summary>
		/// <param name="type">Comma separated list of bridge type attributes (mixing, holding, dtmf_events, proxy_media, video_sfu) to set.</param>
		/// <param name="bridgeId">Unique ID to give to the bridge being created.</param>
		/// <param name="name">Set the name of the bridge.</param>
		Bridge CreateWithId(string bridgeId, string type = null, string name = null);
		/// <summary>
		/// Get bridge details.. 
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		Bridge Get(string bridgeId);
		/// <summary>
		/// Shut down a bridge.. If any channels are in this bridge, they will be removed and resume whatever they were doing beforehand.
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		void Destroy(string bridgeId);
		/// <summary>
		/// Add a channel to a bridge.. 
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="channel">Ids of channels to add to bridge</param>
		/// <param name="role">Channel's role in the bridge</param>
		/// <param name="absorbDTMF">Absorb DTMF coming from this channel, preventing it to pass through to the bridge</param>
		/// <param name="mute">Mute audio from this channel, preventing it to pass through to the bridge</param>
		/// <param name="inhibitConnectedLineUpdates">Do not present the identity of the newly connected channel to other bridge members</param>
		void AddChannel(string bridgeId, string channel, string role = null, bool? absorbDTMF = null, bool? mute = null, bool? inhibitConnectedLineUpdates = null);
		/// <summary>
		/// Remove a channel from a bridge.. 
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="channel">Ids of channels to remove from bridge</param>
		void RemoveChannel(string bridgeId, string channel);
		/// <summary>
		/// Set a channel as the video source in a multi-party mixing bridge. This operation has no effect on bridges with two or fewer participants.. 
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="channelId">Channel's id</param>
		void SetVideoSource(string bridgeId, string channelId);
		/// <summary>
		/// Removes any explicit video source in a multi-party mixing bridge. This operation has no effect on bridges with two or fewer participants. When no explicit video source is set, talk detection will be used to determine the active video stream.. 
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		void ClearVideoSource(string bridgeId);
		/// <summary>
		/// Play music on hold to a bridge or change the MOH class that is playing.. 
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="mohClass">Channel's id</param>
		void StartMoh(string bridgeId, string mohClass = null);
		/// <summary>
		/// Stop playing music on hold to a bridge.. This will only stop music on hold being played via POST bridges/{bridgeId}/moh.
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		void StopMoh(string bridgeId);
		/// <summary>
		/// Start playback of media on a bridge.. The media URI may be any of a number of URI's. Currently sound:, recording:, number:, digits:, characters:, and tone: URI's are supported. This operation creates a playback resource that can be used to control the playback of media (pause, rewind, fast forward, etc.)
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="media">Media URIs to play.</param>
		/// <param name="lang">For sounds, selects language for sound.</param>
		/// <param name="offsetms">Number of milliseconds to skip before playing. Only applies to the first URI if multiple media URIs are specified.</param>
		/// <param name="skipms">Number of milliseconds to skip for forward/reverse operations.</param>
		/// <param name="playbackId">Playback Id.</param>
		Playback Play(string bridgeId, string media, string lang = null, int? offsetms = null, int? skipms = null, string playbackId = null);
		/// <summary>
		/// Start playback of media on a bridge.. The media URI may be any of a number of URI's. Currently sound:, recording:, number:, digits:, characters:, and tone: URI's are supported. This operation creates a playback resource that can be used to control the playback of media (pause, rewind, fast forward, etc.)
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="playbackId">Playback ID.</param>
		/// <param name="media">Media URIs to play.</param>
		/// <param name="lang">For sounds, selects language for sound.</param>
		/// <param name="offsetms">Number of milliseconds to skip before playing. Only applies to the first URI if multiple media URIs are specified.</param>
		/// <param name="skipms">Number of milliseconds to skip for forward/reverse operations.</param>
		Playback PlayWithId(string bridgeId, string playbackId, string media, string lang = null, int? offsetms = null, int? skipms = null);
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
		LiveRecording Record(string bridgeId, string name, string format, int? maxDurationSeconds = null, int? maxSilenceSeconds = null, string ifExists = null, bool? beep = null, string terminateOn = null);

		/// <summary>
		/// List all active bridges in Asterisk.. 
		/// </summary>
		Task<List<Bridge>> ListAsync();
		/// <summary>
		/// Create a new bridge.. This bridge persists until it has been shut down, or Asterisk has been shut down.
		/// </summary>
		/// <param name="type">Comma separated list of bridge type attributes (mixing, holding, dtmf_events, proxy_media, video_sfu).</param>
		/// <param name="bridgeId">Unique ID to give to the bridge being created.</param>
		/// <param name="name">Name to give to the bridge being created.</param>
		Task<Bridge> CreateAsync(string type = null, string bridgeId = null, string name = null);
		/// <summary>
		/// Create a new bridge or updates an existing one.. This bridge persists until it has been shut down, or Asterisk has been shut down.
		/// </summary>
		/// <param name="type">Comma separated list of bridge type attributes (mixing, holding, dtmf_events, proxy_media, video_sfu) to set.</param>
		/// <param name="bridgeId">Unique ID to give to the bridge being created.</param>
		/// <param name="name">Set the name of the bridge.</param>
		Task<Bridge> CreateWithIdAsync(string bridgeId, string type = null, string name = null);
		/// <summary>
		/// Get bridge details.. 
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		Task<Bridge> GetAsync(string bridgeId);
		/// <summary>
		/// Shut down a bridge.. If any channels are in this bridge, they will be removed and resume whatever they were doing beforehand.
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		Task DestroyAsync(string bridgeId);
		/// <summary>
		/// Add a channel to a bridge.. 
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="channel">Ids of channels to add to bridge</param>
		/// <param name="role">Channel's role in the bridge</param>
		/// <param name="absorbDTMF">Absorb DTMF coming from this channel, preventing it to pass through to the bridge</param>
		/// <param name="mute">Mute audio from this channel, preventing it to pass through to the bridge</param>
		/// <param name="inhibitConnectedLineUpdates">Do not present the identity of the newly connected channel to other bridge members</param>
		Task AddChannelAsync(string bridgeId, string channel, string role = null, bool? absorbDTMF = null, bool? mute = null, bool? inhibitConnectedLineUpdates = null);
		/// <summary>
		/// Remove a channel from a bridge.. 
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="channel">Ids of channels to remove from bridge</param>
		Task RemoveChannelAsync(string bridgeId, string channel);
		/// <summary>
		/// Set a channel as the video source in a multi-party mixing bridge. This operation has no effect on bridges with two or fewer participants.. 
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="channelId">Channel's id</param>
		Task SetVideoSourceAsync(string bridgeId, string channelId);
		/// <summary>
		/// Removes any explicit video source in a multi-party mixing bridge. This operation has no effect on bridges with two or fewer participants. When no explicit video source is set, talk detection will be used to determine the active video stream.. 
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		Task ClearVideoSourceAsync(string bridgeId);
		/// <summary>
		/// Play music on hold to a bridge or change the MOH class that is playing.. 
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="mohClass">Channel's id</param>
		Task StartMohAsync(string bridgeId, string mohClass = null);
		/// <summary>
		/// Stop playing music on hold to a bridge.. This will only stop music on hold being played via POST bridges/{bridgeId}/moh.
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		Task StopMohAsync(string bridgeId);
		/// <summary>
		/// Start playback of media on a bridge.. The media URI may be any of a number of URI's. Currently sound:, recording:, number:, digits:, characters:, and tone: URI's are supported. This operation creates a playback resource that can be used to control the playback of media (pause, rewind, fast forward, etc.)
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="media">Media URIs to play.</param>
		/// <param name="lang">For sounds, selects language for sound.</param>
		/// <param name="offsetms">Number of milliseconds to skip before playing. Only applies to the first URI if multiple media URIs are specified.</param>
		/// <param name="skipms">Number of milliseconds to skip for forward/reverse operations.</param>
		/// <param name="playbackId">Playback Id.</param>
		Task<Playback> PlayAsync(string bridgeId, string media, string lang = null, int? offsetms = null, int? skipms = null, string playbackId = null);
		/// <summary>
		/// Start playback of media on a bridge.. The media URI may be any of a number of URI's. Currently sound:, recording:, number:, digits:, characters:, and tone: URI's are supported. This operation creates a playback resource that can be used to control the playback of media (pause, rewind, fast forward, etc.)
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="playbackId">Playback ID.</param>
		/// <param name="media">Media URIs to play.</param>
		/// <param name="lang">For sounds, selects language for sound.</param>
		/// <param name="offsetms">Number of milliseconds to skip before playing. Only applies to the first URI if multiple media URIs are specified.</param>
		/// <param name="skipms">Number of milliseconds to skip for forward/reverse operations.</param>
		Task<Playback> PlayWithIdAsync(string bridgeId, string playbackId, string media, string lang = null, int? offsetms = null, int? skipms = null);
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
		Task<LiveRecording> RecordAsync(string bridgeId, string name, string format, int? maxDurationSeconds = null, int? maxSilenceSeconds = null, string ifExists = null, bool? beep = null, string terminateOn = null);
	}
}
