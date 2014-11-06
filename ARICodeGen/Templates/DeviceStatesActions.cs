/*
	AsterNET ARI Framework
	Automatically generated file @ 06/11/2014 10:21:07
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;
using AsterNET.ARI;
using RestSharp;

namespace AsterNET.ARI.Actions
{
	
	public class DeviceStatesActions : ARIBaseAction
	{

		public DeviceStatesActions(StasisEndpoint endPoint)
			: base(endPoint)
		{}

		/// <summary>
		/// List all ARI controlled device states.. 
		/// </summary>
		public List<DeviceState> List()
		{
			string path = "/deviceStates";
			var request = GetNewRequest(path, Method.GET);

			var response = Client.Execute<List<DeviceState>>(request);

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
		/// Retrieve the current state of a device.. 
		/// </summary>
		/// <param name="deviceName">Name of the device</param>
		public DeviceState Get(string deviceName)
		{
			string path = "/deviceStates/{deviceName}";
			var request = GetNewRequest(path, Method.GET);
			if(deviceName != null)
				request.AddUrlSegment("deviceName", deviceName);

			var response = Client.Execute<DeviceState>(request);

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
		/// Change the state of a device controlled by ARI. (Note - implicitly creates the device state).. 
		/// </summary>
		/// <param name="deviceName">Name of the device</param>
		/// <param name="deviceState">Device state value</param>
		public void Update(string deviceName, string deviceState)
		{
			string path = "/deviceStates/{deviceName}";
			var request = GetNewRequest(path, Method.PUT);
			if(deviceName != null)
				request.AddUrlSegment("deviceName", deviceName);
			if(deviceState != null)
				request.AddParameter("deviceState", deviceState, ParameterType.QueryString);
			var response = Client.Execute(request);
		}
		/// <summary>
		/// Destroy a device-state controlled by ARI.. 
		/// </summary>
		/// <param name="deviceName">Name of the device</param>
		public void Delete(string deviceName)
		{
			string path = "/deviceStates/{deviceName}";
			var request = GetNewRequest(path, Method.DELETE);
			if(deviceName != null)
				request.AddUrlSegment("deviceName", deviceName);
			var response = Client.Execute(request);
		}
	}
}

