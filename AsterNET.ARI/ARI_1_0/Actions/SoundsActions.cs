/*
	AsterNET ARI Framework
	Automatically generated file @ 22/04/2015 09:45:42
*/

using System.Collections.Generic;
using AsterNET.ARI.Middleware;
using AsterNET.ARI.Models;

namespace AsterNET.ARI.Actions
{
	public class SoundsActions : ARIBaseAction, ISoundsActions
	{
		public SoundsActions(IActionConsumer consumer)
			: base(consumer)
		{
		}

		/// <summary>
		///     List all sounds..
		/// </summary>
		/// <param name="lang">Lookup sound for a specific language.</param>
		/// <param name="format">Lookup sound in a specific format.</param>
		public List<Sound> List(string lang = null, string format = null)
		{
			var path = "/sounds";
			var request = GetNewRequest(path, HttpMethod.GET);
			if (lang != null)
				request.AddParameter("lang", lang, ParameterType.QueryString);
			if (format != null)
				request.AddParameter("format", format, ParameterType.QueryString);

			var response = Execute<List<Sound>>(request);

			if ((int) response.StatusCode >= 200 && (int) response.StatusCode < 300)
				return response.Data;

			switch ((int) response.StatusCode)
			{
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode));
			}
		}

		/// <summary>
		///     Get a sound's details..
		/// </summary>
		/// <param name="soundId">Sound's id</param>
		public Sound Get(string soundId)
		{
			var path = "/sounds/{soundId}";
			var request = GetNewRequest(path, HttpMethod.GET);
			if (soundId != null)
				request.AddUrlSegment("soundId", soundId);

			var response = Execute<Sound>(request);

			if ((int) response.StatusCode >= 200 && (int) response.StatusCode < 300)
				return response.Data;

			switch ((int) response.StatusCode)
			{
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode));
			}
		}
	}
}