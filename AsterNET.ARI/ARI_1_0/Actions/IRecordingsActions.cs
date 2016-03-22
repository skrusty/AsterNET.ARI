/*
	AsterNET ARI Framework
	Automatically generated file @ 3/22/2016 11:41:14 AM
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;
using AsterNET.ARI;
using System.Threading.Tasks;

namespace AsterNET.ARI.Actions
{
	
	public interface IRecordingsActions
	{
		/// <summary>
		/// List recordings that are complete.. 
		/// </summary>
		Task<List<StoredRecording>> ListStored();
		/// <summary>
		/// Get a stored recording's details.. 
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		Task<StoredRecording> GetStored(string recordingName);
		/// <summary>
		/// Delete a stored recording.. 
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		Task DeleteStored(string recordingName);
		/// <summary>
		/// Copy a stored recording.. 
		/// </summary>
		/// <param name="recordingName">The name of the recording to copy</param>
		/// <param name="destinationRecordingName">The destination name of the recording</param>
		Task<StoredRecording> CopyStored(string recordingName, string destinationRecordingName);
		/// <summary>
		/// List live recordings.. 
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		Task<LiveRecording> GetLive(string recordingName);
		/// <summary>
		/// Stop a live recording and discard it.. 
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		Task Cancel(string recordingName);
		/// <summary>
		/// Stop a live recording and store it.. 
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		Task Stop(string recordingName);
		/// <summary>
		/// Pause a live recording.. Pausing a recording suspends silence detection, which will be restarted when the recording is unpaused. Paused time is not included in the accounting for maxDurationSeconds.
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		Task Pause(string recordingName);
		/// <summary>
		/// Unpause a live recording.. 
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		Task Unpause(string recordingName);
		/// <summary>
		/// Mute a live recording.. Muting a recording suspends silence detection, which will be restarted when the recording is unmuted.
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		Task Mute(string recordingName);
		/// <summary>
		/// Unmute a live recording.. 
		/// </summary>
		/// <param name="recordingName">The name of the recording</param>
		Task Unmute(string recordingName);
	}
}
