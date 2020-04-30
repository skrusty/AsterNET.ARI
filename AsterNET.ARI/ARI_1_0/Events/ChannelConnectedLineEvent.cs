/*
	AsterNET ARI Framework
	Automatically generated file @ 10.10.2019 19:36:54
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Channel changed Connected Line.
	/// </summary>
	public class ChannelConnectedLineEvent  : Event
	{


		/// <summary>
		/// The channel whose connected line has changed.
		/// </summary>
		public Channel Channel { get; set; }

	}
}
