﻿/*
	AsterNET ARI Framework
	Automatically generated file @ 3/22/2016 11:31:36 AM
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Channel changed location in the dialplan.
	/// </summary>
	public class ChannelDialplanEvent  : Event
	{

		/// <summary>
		///
		/// </summary>
		// public EventsActions Event { get; set; }


		/// <summary>
		/// The channel that changed dialplan location.
		/// </summary>
		public Channel Channel { get; set; }

		/// <summary>
		/// The application about to be executed.
		/// </summary>
		public string Dialplan_app { get; set; }

		/// <summary>
		/// The data to be passed to the application.
		/// </summary>
		public string Dialplan_app_data { get; set; }

	}
}
