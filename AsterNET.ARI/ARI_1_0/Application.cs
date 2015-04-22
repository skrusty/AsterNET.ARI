/*
	AsterNET ARI Framework
	Automatically generated file @ 22/04/2015 09:45:42
*/

using System.Collections.Generic;

namespace AsterNET.ARI.Models
{
	/// <summary>
	///     Details of a Stasis application
	/// </summary>
	public class Application
	{
		/// <summary>
		/// </summary>
		/// <summary>
		///     Name of this application
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		///     Id's for channels subscribed to.
		/// </summary>
		public List<string> Channel_ids { get; set; }

		/// <summary>
		///     Id's for bridges subscribed to.
		/// </summary>
		public List<string> Bridge_ids { get; set; }

		/// <summary>
		///     {tech}/{resource} for endpoints subscribed to.
		/// </summary>
		public List<string> Endpoint_ids { get; set; }

		/// <summary>
		///     Names of the devices subscribed to.
		/// </summary>
		public List<string> Device_names { get; set; }
	}
}