using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;

namespace AsterNET.ARI.Actions
{
	
	public class DeviceStatesActions
	{

		/// <summary>
		/// List all ARI controlled device states.
		/// </summary>
		public List<DeviceState> list()
		{
			string httpMethod = "GET";
			string path = "/deviceStates";

			var client = new RestClient
		}

		/// <summary>
		/// Retrieve the current state of a device.
		/// </summary>
		public DeviceState get()
		{
			string httpMethod = "GET";
			string path = "/deviceStates/{deviceName}";

			var client = new RestClient
		}

	}
}

