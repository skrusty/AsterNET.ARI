using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;

namespace AsterNET.ARI.Actions
{
	
	public class SoundsActions
	{

		/// <summary>
		/// List all sounds.
		/// </summary>
		public List<Sound> list()
		{
			string httpMethod = "GET";
			string path = "/sounds";

			var client = new RestClient
		}

		/// <summary>
		/// Get a sound's details.
		/// </summary>
		public Sound get()
		{
			string httpMethod = "GET";
			string path = "/sounds/{soundId}";

			var client = new RestClient
		}

	}
}

