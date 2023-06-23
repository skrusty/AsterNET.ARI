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
    /// The state of a contact on an endpoint has changed.
    /// </summary>
    public class ContactStatusChangeEvent : Event
    {


        /// <summary>
        /// no description provided
        /// </summary>
        public Endpoint Endpoint { get; set; }

        /// <summary>
        /// no description provided
        /// </summary>
        public ContactInfo Contact_info { get; set; }

    }
}
