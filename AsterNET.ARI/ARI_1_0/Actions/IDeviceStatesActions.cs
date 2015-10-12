/*
	AsterNET ARI Framework
	Automatically generated file @ 12/10/2015 11:53:28
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;
using AsterNET.ARI;

namespace AsterNET.ARI.Actions
{
	
	public interface IDeviceStatesActions
	{
		/// <summary>
		/// List all ARI controlled device states.. 
		/// </summary>
		List<DeviceState> List();
		/// <summary>
		/// Retrieve the current state of a device.. 
		/// </summary>
		/// <param name="deviceName">Name of the device</param>
		DeviceState Get(string deviceName);
		/// <summary>
		/// Change the state of a device controlled by ARI. (Note - implicitly creates the device state).. 
		/// </summary>
		/// <param name="deviceName">Name of the device</param>
		/// <param name="deviceState">Device state value</param>
		void Update(string deviceName, string deviceState);
		/// <summary>
		/// Destroy a device-state controlled by ARI.. 
		/// </summary>
		/// <param name="deviceName">Name of the device</param>
		void Delete(string deviceName);
	}
}
