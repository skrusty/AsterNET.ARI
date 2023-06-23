/*
   AsterNET ARI Framework
   Automatically generated file @ 6/21/2023 2:39:12 PM
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
    /// <summary>
    /// Details of an Asterisk log channel
    /// </summary>
    public class LogChannel
    {


        /// <summary>
        /// The log channel path
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// Types of logs for the log channel
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Whether or not a log type is enabled
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The various log levels
        /// </summary>
        public string Configuration { get; set; }

    }
}
