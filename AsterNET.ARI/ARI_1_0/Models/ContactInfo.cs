/*
   AsterNET ARI Framework
   Automatically generated file @ 6/21/2023 1:51:25 PM
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
    /// <summary>
    /// Detailed information about a contact on an endpoint.
    /// </summary>
    public class ContactInfo
    {


        /// <summary>
        /// The location of the contact.
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// The current status of the contact.
        /// </summary>
        public string Contact_status { get; set; }

        /// <summary>
        /// The Address of Record this contact belongs to.
        /// </summary>
        public string Aor { get; set; }

        /// <summary>
        /// Current round trip time, in microseconds, for the contact.
        /// </summary>
        public string Roundtrip_usec { get; set; }

    }
}
