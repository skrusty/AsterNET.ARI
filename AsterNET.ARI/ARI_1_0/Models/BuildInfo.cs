﻿/*
	AsterNET ARI Framework
	Automatically generated file @ 9/22/2016 4:43:49 PM
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
    /// <summary>
    /// Info about how Asterisk was built
    /// </summary>
    public class BuildInfo
    {


        /// <summary>
        /// OS Asterisk was built on.
        /// </summary>
        public string Os { get; set; }

        /// <summary>
        /// Kernel version Asterisk was built on.
        /// </summary>
        public string Kernel { get; set; }

        /// <summary>
        /// Compile time options, or empty string if default.
        /// </summary>
        public string Options { get; set; }

        /// <summary>
        /// Machine architecture (x86_64, i686, ppc, etc.)
        /// </summary>
        public string Machine { get; set; }

        /// <summary>
        /// Date and time when Asterisk was built.
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Username that build Asterisk
        /// </summary>
        public string User { get; set; }

    }
}
