/*
	AsterNET ARI Framework
	Automatically generated file @ 9/22/2016 4:43:50 PM
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
    /// <summary>
    /// Represents the state of a mailbox.
    /// </summary>
    public class Mailbox
    {


        /// <summary>
        /// Name of the mailbox.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Count of old messages in the mailbox.
        /// </summary>
        public int Old_messages { get; set; }

        /// <summary>
        /// Count of new messages in the mailbox.
        /// </summary>
        public int New_messages { get; set; }

    }
}
