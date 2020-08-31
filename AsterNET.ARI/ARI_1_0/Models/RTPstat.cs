/*
	AsterNET ARI Framework
	Automatically generated file @ 31/08/2020 12:42:41
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Models
{
	/// <summary>
	/// A statistics of a RTP.
	/// </summary>
	public class RTPstat 
	{


		/// <summary>
		/// Number of packets transmitted.
		/// </summary>
		public int Txcount { get; set; }

		/// <summary>
		/// Number of packets received.
		/// </summary>
		public int Rxcount { get; set; }

		/// <summary>
		/// Jitter on transmitted packets.
		/// </summary>
		public double Txjitter { get; set; }

		/// <summary>
		/// Jitter on received packets.
		/// </summary>
		public double Rxjitter { get; set; }

		/// <summary>
		/// Maximum jitter on remote side.
		/// </summary>
		public double Remote_maxjitter { get; set; }

		/// <summary>
		/// Minimum jitter on remote side.
		/// </summary>
		public double Remote_minjitter { get; set; }

		/// <summary>
		/// Average jitter on remote side.
		/// </summary>
		public double Remote_normdevjitter { get; set; }

		/// <summary>
		/// Standard deviation jitter on remote side.
		/// </summary>
		public double Remote_stdevjitter { get; set; }

		/// <summary>
		/// Maximum jitter on local side.
		/// </summary>
		public double Local_maxjitter { get; set; }

		/// <summary>
		/// Minimum jitter on local side.
		/// </summary>
		public double Local_minjitter { get; set; }

		/// <summary>
		/// Average jitter on local side.
		/// </summary>
		public double Local_normdevjitter { get; set; }

		/// <summary>
		/// Standard deviation jitter on local side.
		/// </summary>
		public double Local_stdevjitter { get; set; }

		/// <summary>
		/// Number of transmitted packets lost.
		/// </summary>
		public int Txploss { get; set; }

		/// <summary>
		/// Number of received packets lost.
		/// </summary>
		public int Rxploss { get; set; }

		/// <summary>
		/// Maximum number of packets lost on remote side.
		/// </summary>
		public double Remote_maxrxploss { get; set; }

		/// <summary>
		/// Minimum number of packets lost on remote side.
		/// </summary>
		public double Remote_minrxploss { get; set; }

		/// <summary>
		/// Average number of packets lost on remote side.
		/// </summary>
		public double Remote_normdevrxploss { get; set; }

		/// <summary>
		/// Standard deviation packets lost on remote side.
		/// </summary>
		public double Remote_stdevrxploss { get; set; }

		/// <summary>
		/// Maximum number of packets lost on local side.
		/// </summary>
		public double Local_maxrxploss { get; set; }

		/// <summary>
		/// Minimum number of packets lost on local side.
		/// </summary>
		public double Local_minrxploss { get; set; }

		/// <summary>
		/// Average number of packets lost on local side.
		/// </summary>
		public double Local_normdevrxploss { get; set; }

		/// <summary>
		/// Standard deviation packets lost on local side.
		/// </summary>
		public double Local_stdevrxploss { get; set; }

		/// <summary>
		/// Total round trip time.
		/// </summary>
		public double Rtt { get; set; }

		/// <summary>
		/// Maximum round trip time.
		/// </summary>
		public double Maxrtt { get; set; }

		/// <summary>
		/// Minimum round trip time.
		/// </summary>
		public double Minrtt { get; set; }

		/// <summary>
		/// Average round trip time.
		/// </summary>
		public double Normdevrtt { get; set; }

		/// <summary>
		/// Standard deviation round trip time.
		/// </summary>
		public double Stdevrtt { get; set; }

		/// <summary>
		/// Our SSRC.
		/// </summary>
		public int Local_ssrc { get; set; }

		/// <summary>
		/// Their SSRC.
		/// </summary>
		public int Remote_ssrc { get; set; }

		/// <summary>
		/// Number of octets transmitted.
		/// </summary>
		public int Txoctetcount { get; set; }

		/// <summary>
		/// Number of octets received.
		/// </summary>
		public int Rxoctetcount { get; set; }

		/// <summary>
		/// The Asterisk channel's unique ID that owns this instance.
		/// </summary>
		public string Channel_uniqueid { get; set; }

	}
}
