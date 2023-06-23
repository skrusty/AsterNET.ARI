/*
   AsterNET ARI Framework
   Automatically generated file @ 6/21/2023 2:39:08 PM
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
