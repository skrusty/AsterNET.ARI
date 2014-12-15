/*
	AsterNET ARI Framework
	Automatically generated file @ 08/12/2014 20:34:10
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;
using AsterNET.ARI;

namespace AsterNET.ARI.Actions
{
	
	public interface IPlaybacksActions
	{
		/// <summary>
		/// Get a playback's details.. 
		/// </summary>
		/// <param name="playbackId">Playback's id</param>
		Playback Get(string playbackId);
		/// <summary>
		/// Stop a playback.. 
		/// </summary>
		/// <param name="playbackId">Playback's id</param>
		void Stop(string playbackId);
		/// <summary>
		/// Control a playback.. 
		/// </summary>
		/// <param name="playbackId">Playback's id</param>
		/// <param name="operation">Operation to perform on the playback.</param>
		void Control(string playbackId, string operation);
	}
}
