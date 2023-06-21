/*
   AsterNET ARI Framework
   Automatically generated file @ 6/21/2023 1:51:24 PM
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
    /// <summary>
    /// Error event sent when required params are missing.
    /// </summary>
    public class MissingParams : Message
    {


        /// <summary>
        /// A list of the missing parameters
        /// </summary>
        public List<string> Params { get; set; }

    }
}
