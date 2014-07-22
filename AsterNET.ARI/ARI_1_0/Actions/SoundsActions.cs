/*
	AsterNET ARI Framework
	Automatically generated file @ 22/07/2014 19:01:02
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;
using AsterNET.ARI;
using RestSharp;

namespace AsterNET.ARI.Actions
{
	
	public class SoundsActions : ARIBaseAction
	{

		public SoundsActions(StasisEndpoint endPoint)
			: base(endPoint)
		{}

		/// <summary>
		/// List all sounds.. 
		/// </summary>
		/// <param name="lang">Lookup sound for a specific language.</param>
		/// <param name="format">Lookup sound in a specific format.</param>
		public List<Sound> List(string lang, string format)
		{
			string path = "/sounds";
			var request = GetNewRequest(path, Method.GET);
			request.AddParameter("lang", lang, ParameterType.QueryString);
			request.AddParameter("format", format, ParameterType.QueryString);

			var response = Client.Execute<List<Sound>>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;

			switch((int)response.StatusCode)
            {
				default:
					// Unknown server response
					throw new ARIException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
		/// <summary>
		/// Get a sound's details.. 
		/// </summary>
		/// <param name="soundId">Sound's id</param>
		public Sound Get(string soundId)
		{
			string path = "/sounds/{soundId}";
			var request = GetNewRequest(path, Method.GET);
			request.AddUrlSegment("soundId", soundId);

			var response = Client.Execute<Sound>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;

			switch((int)response.StatusCode)
            {
				default:
					// Unknown server response
					throw new ARIException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
	}
}

