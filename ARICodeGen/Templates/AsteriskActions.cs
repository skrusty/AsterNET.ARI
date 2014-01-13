using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;

namespace AsterNET.ARI.Actions
{
	
	public class AsteriskActions
	{

		/// <summary>
		/// Gets Asterisk system information.
		/// </summary>
		public AsteriskInfo getInfo()
		{
			string httpMethod = "GET";
			string path = "/asterisk/info";

			var client = new RestClient
		}

		/// <summary>
		/// Get the value of a global variable.
		/// </summary>
		public Variable getGlobalVar()
		{
			string httpMethod = "GET";
			string path = "/asterisk/variable";

			var client = new RestClient
		}

	}
}

