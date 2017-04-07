﻿/*
	AsterNET ARI Framework
	Automatically generated file @ 9/22/2016 4:43:50 PM
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

    }
}
