/*
   AsterNET ARI Framework
   Automatically generated file @ 6/21/2023 1:51:40 PM
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
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
