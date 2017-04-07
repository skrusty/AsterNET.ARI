/*
	AsterNET ARI Framework
	Automatically generated file @ 9/22/2016 4:43:50 PM
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;
using AsterNET.ARI;
using System.Threading.Tasks;

namespace AsterNET.ARI.Actions
{

    public interface ISoundsActions
    {
        /// <summary>
        /// List all sounds.. 
        /// </summary>
        /// <param name="lang">Lookup sound for a specific language.</param>
        /// <param name="format">Lookup sound in a specific format.</param>
        List<Sound> List(string lang = null, string format = null);
        /// <summary>
        /// Get a sound's details.. 
        /// </summary>
        /// <param name="soundId">Sound's id</param>
        Sound Get(string soundId);

        /// <summary>
        /// List all sounds.. 
        /// </summary>
        /// <param name="lang">Lookup sound for a specific language.</param>
        /// <param name="format">Lookup sound in a specific format.</param>
        Task<List<Sound>> ListAsync(string lang = null, string format = null);
        /// <summary>
        /// Get a sound's details.. 
        /// </summary>
        /// <param name="soundId">Sound's id</param>
        Task<Sound> GetAsync(string soundId);
    }
}
