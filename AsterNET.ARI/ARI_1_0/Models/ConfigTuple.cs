/*
	AsterNET ARI Framework
	Automatically generated file @ 9/22/2016 4:43:49 PM
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;
using Newtonsoft.Json;

namespace AsterNET.ARI.Models
{
    /// <summary>
    /// A key/value pair that makes up part of a configuration object.
    /// </summary>
    public class ConfigTuple
    {
        /// <summary>
        /// A configuration object attribute.
        /// </summary>
        [JsonProperty("attribute")]
        public string Attribute { get; set; }

        /// <summary>
        /// The value for the attribute.
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }

    }
}
