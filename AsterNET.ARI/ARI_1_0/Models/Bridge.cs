/*
	AsterNET ARI Framework
	Automatically generated file @ 14/08/2016 18:59:17
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// The merging of media from one or more channels.  Everyone on the bridge receives the same audio.
	/// </summary>
	public class Bridge 
	{


		/// <summary>
		/// Unique identifier for this bridge
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Ids of channels participating in this bridge
		/// </summary>
		public List<string> Channels { get; set; }

		/// <summary>
		/// Name the creator gave the bridge
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Name of the current bridging technology
		/// </summary>
		public string Technology { get; set; }

		/// <summary>
		/// Bridging class
		/// </summary>
		public string Bridge_class { get; set; }

		/// <summary>
		/// Entity that created the bridge
		/// </summary>
		public string Creator { get; set; }

		/// <summary>
		/// Type of bridge technology
		/// </summary>
		public string Bridge_type { get; set; }

	}
}
