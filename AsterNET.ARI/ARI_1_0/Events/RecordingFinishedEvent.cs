﻿/*
	AsterNET ARI Framework
	Automatically generated file @ 10.10.2019 19:36:54
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// Event showing the completion of a recording operation.
	/// </summary>
	public class RecordingFinishedEvent  : Event
	{


		/// <summary>
		/// Recording control object
		/// </summary>
		public LiveRecording Recording { get; set; }

	}
}
