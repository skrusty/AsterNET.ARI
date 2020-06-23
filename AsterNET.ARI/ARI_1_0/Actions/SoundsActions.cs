/*
   AsterNET ARI Framework
   Automatically generated file @ 6/23/2020 3:09:38 PM
*/
using System.Collections.Generic;
using System.Linq;
using AsterNET.ARI.Middleware;
using AsterNET.ARI.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AsterNET.ARI.Actions
{

    public class SoundsActions : ARIBaseAction, ISoundsActions
    {

        public SoundsActions(IActionConsumer consumer)
            : base(consumer)
        { }

        /// <summary>
        /// List all sounds.. 
        /// </summary>
        /// <param name="lang">Lookup sound for a specific language.</param>
        /// <param name="format">Lookup sound in a specific format.</param>
        public List<Sound> List(string lang = null, string format = null)
        {
            string path = "sounds";
            var request = GetNewRequest(path, HttpMethod.GET);
            if (lang != null)
                request.AddParameter("lang", lang, ParameterType.QueryString);
            if (format != null)
                request.AddParameter("format", format, ParameterType.QueryString);

            var response = Execute<List<Sound>>(request);

            if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
                return response.Data;
            switch ((int)response.StatusCode)
            {
                default:
                    // Unknown server response
                    throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
        }
        /// <summary>
        /// Get a sound's details.. 
        /// </summary>
        /// <param name="soundId">Sound's id</param>
        public Sound Get(string soundId)
        {
            string path = "sounds/{soundId}";
            var request = GetNewRequest(path, HttpMethod.GET);
            if (soundId != null)
                request.AddUrlSegment("soundId", soundId);

            var response = Execute<Sound>(request);

            if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
                return response.Data;
            switch ((int)response.StatusCode)
            {
                default:
                    // Unknown server response
                    throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
        }

        /// <summary>
        /// List all sounds.. 
        /// </summary>
        public async Task<List<Sound>> ListAsync(string lang = null, string format = null)
        {
            string path = "sounds";
            var request = GetNewRequest(path, HttpMethod.GET);
            if (lang != null)
                request.AddParameter("lang", lang, ParameterType.QueryString);
            if (format != null)
                request.AddParameter("format", format, ParameterType.QueryString);

            var response = await ExecuteTask<List<Sound>>(request);

            if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
                return response.Data;
            switch ((int)response.StatusCode)
            {
                default:
                    // Unknown server response
                    throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
        }
        /// <summary>
        /// Get a sound's details.. 
        /// </summary>
        public async Task<Sound> GetAsync(string soundId)
        {
            string path = "sounds/{soundId}";
            var request = GetNewRequest(path, HttpMethod.GET);
            if (soundId != null)
                request.AddUrlSegment("soundId", soundId);

            var response = await ExecuteTask<Sound>(request);

            if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
                return response.Data;
            switch ((int)response.StatusCode)
            {
                default:
                    // Unknown server response
                    throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
        }
    }
}

