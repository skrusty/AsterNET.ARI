/*
	AsterNET ARI Framework
	Automatically generated file @ 9/22/2016 4:43:49 PM
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
    /// <summary>
    /// A specific communication connection between Asterisk and an Endpoint.
    /// </summary>
    public class Channel
    {


        /// <summary>
        /// Unique identifier of the channel.  This is the same as the Uniqueid field in AMI.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name of the channel (i.e. SIP/foo-0000a7e3)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// no description provided
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// no description provided
        /// </summary>
        public CallerID Caller { get; set; }

        /// <summary>
        /// no description provided
        /// </summary>
        public CallerID Connected { get; set; }

        /// <summary>
        /// no description provided
        /// </summary>
        public string Accountcode { get; set; }

        /// <summary>
        /// Current location in the dialplan
        /// </summary>
        public DialplanCEP Dialplan { get; set; }

        /// <summary>
        /// Timestamp when channel was created
        /// </summary>
        public DateTime Creationtime { get; set; }

        /// <summary>
        /// The default spoken language
        /// </summary>
        public string Language { get; set; }

    }
}
