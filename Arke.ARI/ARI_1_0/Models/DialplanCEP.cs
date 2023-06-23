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
    /// Dialplan location (context/extension/priority)
    /// </summary>
    public class DialplanCEP
    {


        /// <summary>
        /// Context in the dialplan
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        /// Extension in the dialplan
        /// </summary>
        public string Exten { get; set; }

        /// <summary>
        /// Priority in the dialplan
        /// </summary>
        public long Priority { get; set; }

        /// <summary>
        /// Name of current dialplan application
        /// </summary>
        public string App_name { get; set; }

        /// <summary>
        /// Parameter of current dialplan application
        /// </summary>
        public string App_data { get; set; }

    }
}
