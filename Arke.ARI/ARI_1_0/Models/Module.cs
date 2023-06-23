/*
   Arke ARI Framework
   Automatically generated file @ 6/23/2023 11:34:36 AM
*/
using System;
using System.Collections.Generic;
using Arke.ARI.Actions;

namespace Arke.ARI.Models
{
    /// <summary>
    /// Details of an Asterisk module
    /// </summary>
    public class Module
    {


        /// <summary>
        /// The name of this module
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of this module
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The number of times this module is being used
        /// </summary>
        public int Use_count { get; set; }

        /// <summary>
        /// The running status of this module
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The support state of this module
        /// </summary>
        public string Support_level { get; set; }

    }
}
