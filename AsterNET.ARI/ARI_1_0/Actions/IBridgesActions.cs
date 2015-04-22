/*
	AsterNET ARI Framework
	Automatically generated file @ 22/04/2015 09:45:42
*/

using System.Collections.Generic;
using AsterNET.ARI.Models;

namespace AsterNET.ARI.Actions
{
	public interface IBridgesActions
	{
		/// <summary>
		///     List all active bridges in Asterisk..
		/// </summary>
		List<Bridge> List();

		/// <summary>
		///     Create a new bridge.. This bridge persists until it has been shut down, or Asterisk has been shut down.
		/// </summary>
		/// <param name="type">Comma separated list of bridge type attributes (mixing, holding, dtmf_events, proxy_media).</param>
		/// <param name="bridgeId">Unique ID to give to the bridge being created.</param>
		/// <param name="name">Name to give to the bridge being created.</param>
		Bridge Create(string type = null, string bridgeId = null, string name = null);

		/// <summary>
		///     Create a new bridge or updates an existing one.. This bridge persists until it has been shut down, or Asterisk has
		///     been shut down.
		/// </summary>
		/// <param name="type">Comma separated list of bridge type attributes (mixing, holding, dtmf_events, proxy_media) to set.</param>
		/// <param name="bridgeId">Unique ID to give to the bridge being created.</param>
		/// <param name="name">Set the name of the bridge.</param>
		Bridge CreateWithId(string bridgeId, string type = null, string name = null);

		/// <summary>
		///     Get bridge details..
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		Bridge Get(string bridgeId);

		/// <summary>
		///     Shut down a bridge.. If any channels are in this bridge, they will be removed and resume whatever they were doing
		///     beforehand.
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		void Destroy(string bridgeId);

		/// <summary>
		///     Add a channel to a bridge..
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="channel">Ids of channels to add to bridge</param>
		/// <param name="role">Channel's role in the bridge</param>
		void AddChannel(string bridgeId, string channel, string role = null);

		/// <summary>
		///     Remove a channel from a bridge..
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="channel">Ids of channels to remove from bridge</param>
		void RemoveChannel(string bridgeId, string channel);

		/// <summary>
		///     Play music on hold to a bridge or change the MOH class that is playing..
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="mohClass">Channel's id</param>
		void StartMoh(string bridgeId, string mohClass = null);

		/// <summary>
		///     Stop playing music on hold to a bridge.. This will only stop music on hold being played via POST
		///     bridges/{bridgeId}/moh.
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		void StopMoh(string bridgeId);

		/// <summary>
		///     Start playback of media on a bridge.. The media URI may be any of a number of URI's. Currently sound:, recording:,
		///     number:, digits:, characters:, and tone: URI's are supported. This operation creates a playback resource that can
		///     be used to control the playback of media (pause, rewind, fast forward, etc.)
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="media">Media's URI to play.</param>
		/// <param name="lang">For sounds, selects language for sound.</param>
		/// <param name="offsetms">Number of media to skip before playing.</param>
		/// <param name="skipms">Number of milliseconds to skip for forward/reverse operations.</param>
		/// <param name="playbackId">Playback Id.</param>
		Playback Play(string bridgeId, string media, string lang = null, int? offsetms = null, int? skipms = null,
			string playbackId = null);

		/// <summary>
		///     Start playback of media on a bridge.. The media URI may be any of a number of URI's. Currently sound:, recording:,
		///     number:, digits:, characters:, and tone: URI's are supported. This operation creates a playback resource that can
		///     be used to control the playback of media (pause, rewind, fast forward, etc.)
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="playbackId">Playback ID.</param>
		/// <param name="media">Media's URI to play.</param>
		/// <param name="lang">For sounds, selects language for sound.</param>
		/// <param name="offsetms">Number of media to skip before playing.</param>
		/// <param name="skipms">Number of milliseconds to skip for forward/reverse operations.</param>
		Playback PlayWithId(string bridgeId, string playbackId, string media, string lang = null, int? offsetms = null,
			int? skipms = null);

		/// <summary>
		///     Start a recording.. This records the mixed audio from all channels participating in this bridge.
		/// </summary>
		/// <param name="bridgeId">Bridge's id</param>
		/// <param name="name">Recording's filename</param>
		/// <param name="format">Format to encode audio in</param>
		/// <param name="maxDurationSeconds">Maximum duration of the recording, in seconds. 0 for no limit.</param>
		/// <param name="maxSilenceSeconds">Maximum duration of silence, in seconds. 0 for no limit.</param>
		/// <param name="ifExists">Action to take if a recording with the same name already exists.</param>
		/// <param name="beep">Play beep when recording begins</param>
		/// <param name="terminateOn">DTMF input to terminate recording.</param>
		LiveRecording Record(string bridgeId, string name, string format, int? maxDurationSeconds = null,
			int? maxSilenceSeconds = null, string ifExists = null, bool? beep = null, string terminateOn = null);
	}
}