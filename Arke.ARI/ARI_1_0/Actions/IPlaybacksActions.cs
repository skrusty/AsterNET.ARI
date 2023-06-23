/*
   Arke ARI Framework
   Automatically generated file @ 6/23/2023 11:34:36 AM
*/
using System;
using System.Collections.Generic;
using Arke.ARI.Models;
using Arke.ARI;
using System.Threading.Tasks;

namespace Arke.ARI.Actions
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

        /// <summary>
        /// Get a playback's details.. 
        /// </summary>
        /// <param name="playbackId">Playback's id</param>
        Task<Playback> GetAsync(string playbackId);
        /// <summary>
        /// Stop a playback.. 
        /// </summary>
        /// <param name="playbackId">Playback's id</param>
        Task StopAsync(string playbackId);
        /// <summary>
        /// Control a playback.. 
        /// </summary>
        /// <param name="playbackId">Playback's id</param>
        /// <param name="operation">Operation to perform on the playback.</param>
        Task ControlAsync(string playbackId, string operation);
    }
}
