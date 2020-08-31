/*
	AsterNET ARI Framework
	Automatically generated file @ 31/08/2020 12:42:41
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Details of a Stasis application
	/// </summary>
	public class Application 
	{


		/// <summary>
		/// Name of this application
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Id's for channels subscribed to.
		/// </summary>
		public List<string> Channel_ids { get; set; }

		/// <summary>
		/// Id's for bridges subscribed to.
		/// </summary>
		public List<string> Bridge_ids { get; set; }

		/// <summary>
		/// {tech}/{resource} for endpoints subscribed to.
		/// </summary>
		public List<string> Endpoint_ids { get; set; }

		/// <summary>
		/// Names of the devices subscribed to.
		/// </summary>
		public List<string> Device_names { get; set; }

		/// <summary>
		/// Event types sent to the application.
		/// </summary>
		public List<object> Events_allowed { get; set; }

		/// <summary>
		/// Event types not sent to the application.
		/// </summary>
		public List<object> Events_disallowed { get; set; }

	}
}
