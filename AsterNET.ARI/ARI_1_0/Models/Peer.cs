﻿/*
	AsterNET ARI Framework
	Automatically generated file @ 9/22/2016 4:43:49 PM
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
    /// <summary>
    /// Detailed information about a remote peer that communicates with Asterisk.
    /// </summary>
    public class Peer
    {


        /// <summary>
        /// The current state of the peer. Note that the values of the status are dependent on the underlying peer technology.
        /// </summary>
        public string Peer_status { get; set; }

        /// <summary>
        /// An optional reason associated with the change in peer_status.
        /// </summary>
        public string Cause { get; set; }

        /// <summary>
        /// The IP address of the peer.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The port of the peer.
        /// </summary>
        public string Port { get; set; }

        /// <summary>
        /// The last known time the peer was contacted.
        /// </summary>
        public string Time { get; set; }

    }
}
