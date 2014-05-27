/*
	AsterNET ARI Framework
	Automatically generated file @ 26/05/2014 13:34:17
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;

namespace AsterNET.ARI
{
	public delegate void ChannelCallerIdEventHandler(object sender, ChannelCallerIdEvent e);
	public delegate void ChannelDtmfReceivedEventHandler(object sender, ChannelDtmfReceivedEvent e);
	public delegate void BridgeCreatedEventHandler(object sender, BridgeCreatedEvent e);
	public delegate void ChannelCreatedEventHandler(object sender, ChannelCreatedEvent e);
	public delegate void ApplicationReplacedEventHandler(object sender, ApplicationReplacedEvent e);
	public delegate void ChannelStateChangeEventHandler(object sender, ChannelStateChangeEvent e);
	public delegate void PlaybackFinishedEventHandler(object sender, PlaybackFinishedEvent e);
	public delegate void RecordingStartedEventHandler(object sender, RecordingStartedEvent e);
	public delegate void ChannelLeftBridgeEventHandler(object sender, ChannelLeftBridgeEvent e);
	public delegate void ChannelDestroyedEventHandler(object sender, ChannelDestroyedEvent e);
	public delegate void DeviceStateChangedEventHandler(object sender, DeviceStateChangedEvent e);
	public delegate void PlaybackStartedEventHandler(object sender, PlaybackStartedEvent e);
	public delegate void RecordingFailedEventHandler(object sender, RecordingFailedEvent e);
	public delegate void BridgeMergedEventHandler(object sender, BridgeMergedEvent e);
	public delegate void RecordingFinishedEventHandler(object sender, RecordingFinishedEvent e);
	public delegate void BridgeAttendedTransferEventHandler(object sender, BridgeAttendedTransferEvent e);
	public delegate void ChannelEnteredBridgeEventHandler(object sender, ChannelEnteredBridgeEvent e);
	public delegate void BridgeDestroyedEventHandler(object sender, BridgeDestroyedEvent e);
	public delegate void BridgeBlindTransferEventHandler(object sender, BridgeBlindTransferEvent e);
	public delegate void ChannelUsereventEventHandler(object sender, ChannelUsereventEvent e);
	public delegate void ChannelDialplanEventHandler(object sender, ChannelDialplanEvent e);
	public delegate void ChannelHangupRequestEventHandler(object sender, ChannelHangupRequestEvent e);
	public delegate void ChannelVarsetEventHandler(object sender, ChannelVarsetEvent e);
	public delegate void EndpointStateChangeEventHandler(object sender, EndpointStateChangeEvent e);
	public delegate void DialEventHandler(object sender, DialEvent e);
	public delegate void StasisEndEventHandler(object sender, StasisEndEvent e);
	public delegate void StasisStartEventHandler(object sender, StasisStartEvent e);
	public delegate void UnhandledEventHandler(object sender, AsterNET.ARI.Models.Event eventMessage);

	/// <summary>
	/// 
	/// </summary>
	public partial class BaseARIClient_1_0_0
	{
		public event ChannelCallerIdEventHandler OnChannelCallerIdEvent;
		public event ChannelDtmfReceivedEventHandler OnChannelDtmfReceivedEvent;
		public event BridgeCreatedEventHandler OnBridgeCreatedEvent;
		public event ChannelCreatedEventHandler OnChannelCreatedEvent;
		public event ApplicationReplacedEventHandler OnApplicationReplacedEvent;
		public event ChannelStateChangeEventHandler OnChannelStateChangeEvent;
		public event PlaybackFinishedEventHandler OnPlaybackFinishedEvent;
		public event RecordingStartedEventHandler OnRecordingStartedEvent;
		public event ChannelLeftBridgeEventHandler OnChannelLeftBridgeEvent;
		public event ChannelDestroyedEventHandler OnChannelDestroyedEvent;
		public event DeviceStateChangedEventHandler OnDeviceStateChangedEvent;
		public event PlaybackStartedEventHandler OnPlaybackStartedEvent;
		public event RecordingFailedEventHandler OnRecordingFailedEvent;
		public event BridgeMergedEventHandler OnBridgeMergedEvent;
		public event RecordingFinishedEventHandler OnRecordingFinishedEvent;
		public event BridgeAttendedTransferEventHandler OnBridgeAttendedTransferEvent;
		public event ChannelEnteredBridgeEventHandler OnChannelEnteredBridgeEvent;
		public event BridgeDestroyedEventHandler OnBridgeDestroyedEvent;
		public event BridgeBlindTransferEventHandler OnBridgeBlindTransferEvent;
		public event ChannelUsereventEventHandler OnChannelUsereventEvent;
		public event ChannelDialplanEventHandler OnChannelDialplanEvent;
		public event ChannelHangupRequestEventHandler OnChannelHangupRequestEvent;
		public event ChannelVarsetEventHandler OnChannelVarsetEvent;
		public event EndpointStateChangeEventHandler OnEndpointStateChangeEvent;
		public event DialEventHandler OnDialEvent;
		public event StasisEndEventHandler OnStasisEndEvent;
		public event StasisStartEventHandler OnStasisStartEvent;
		public event UnhandledEventHandler OnUnhandledEvent;		
		
		protected void FireEvent(string eventName, object eventArgs)
		{
		
			switch(eventName) 
			{
			
			
				case "ChannelCallerId":
					if(OnChannelCallerIdEvent != null)
						OnChannelCallerIdEvent(this, (ChannelCallerIdEvent)eventArgs);
					break;
			
			
				case "ChannelDtmfReceived":
					if(OnChannelDtmfReceivedEvent != null)
						OnChannelDtmfReceivedEvent(this, (ChannelDtmfReceivedEvent)eventArgs);
					break;
			
			
				case "BridgeCreated":
					if(OnBridgeCreatedEvent != null)
						OnBridgeCreatedEvent(this, (BridgeCreatedEvent)eventArgs);
					break;
			
			
				case "ChannelCreated":
					if(OnChannelCreatedEvent != null)
						OnChannelCreatedEvent(this, (ChannelCreatedEvent)eventArgs);
					break;
			
			
				case "ApplicationReplaced":
					if(OnApplicationReplacedEvent != null)
						OnApplicationReplacedEvent(this, (ApplicationReplacedEvent)eventArgs);
					break;
			
			
				case "ChannelStateChange":
					if(OnChannelStateChangeEvent != null)
						OnChannelStateChangeEvent(this, (ChannelStateChangeEvent)eventArgs);
					break;
			
			
				case "PlaybackFinished":
					if(OnPlaybackFinishedEvent != null)
						OnPlaybackFinishedEvent(this, (PlaybackFinishedEvent)eventArgs);
					break;
			
			
				case "RecordingStarted":
					if(OnRecordingStartedEvent != null)
						OnRecordingStartedEvent(this, (RecordingStartedEvent)eventArgs);
					break;
			
			
				case "ChannelLeftBridge":
					if(OnChannelLeftBridgeEvent != null)
						OnChannelLeftBridgeEvent(this, (ChannelLeftBridgeEvent)eventArgs);
					break;
			
			
				case "ChannelDestroyed":
					if(OnChannelDestroyedEvent != null)
						OnChannelDestroyedEvent(this, (ChannelDestroyedEvent)eventArgs);
					break;
			
			
				case "DeviceStateChanged":
					if(OnDeviceStateChangedEvent != null)
						OnDeviceStateChangedEvent(this, (DeviceStateChangedEvent)eventArgs);
					break;
			
			
				case "PlaybackStarted":
					if(OnPlaybackStartedEvent != null)
						OnPlaybackStartedEvent(this, (PlaybackStartedEvent)eventArgs);
					break;
			
			
				case "RecordingFailed":
					if(OnRecordingFailedEvent != null)
						OnRecordingFailedEvent(this, (RecordingFailedEvent)eventArgs);
					break;
			
			
				case "BridgeMerged":
					if(OnBridgeMergedEvent != null)
						OnBridgeMergedEvent(this, (BridgeMergedEvent)eventArgs);
					break;
			
			
				case "RecordingFinished":
					if(OnRecordingFinishedEvent != null)
						OnRecordingFinishedEvent(this, (RecordingFinishedEvent)eventArgs);
					break;
			
			
				case "BridgeAttendedTransfer":
					if(OnBridgeAttendedTransferEvent != null)
						OnBridgeAttendedTransferEvent(this, (BridgeAttendedTransferEvent)eventArgs);
					break;
			
			
				case "ChannelEnteredBridge":
					if(OnChannelEnteredBridgeEvent != null)
						OnChannelEnteredBridgeEvent(this, (ChannelEnteredBridgeEvent)eventArgs);
					break;
			
			
				case "BridgeDestroyed":
					if(OnBridgeDestroyedEvent != null)
						OnBridgeDestroyedEvent(this, (BridgeDestroyedEvent)eventArgs);
					break;
			
			
				case "BridgeBlindTransfer":
					if(OnBridgeBlindTransferEvent != null)
						OnBridgeBlindTransferEvent(this, (BridgeBlindTransferEvent)eventArgs);
					break;
			
			
				case "ChannelUserevent":
					if(OnChannelUsereventEvent != null)
						OnChannelUsereventEvent(this, (ChannelUsereventEvent)eventArgs);
					break;
			
			
				case "ChannelDialplan":
					if(OnChannelDialplanEvent != null)
						OnChannelDialplanEvent(this, (ChannelDialplanEvent)eventArgs);
					break;
			
			
				case "ChannelHangupRequest":
					if(OnChannelHangupRequestEvent != null)
						OnChannelHangupRequestEvent(this, (ChannelHangupRequestEvent)eventArgs);
					break;
			
			
				case "ChannelVarset":
					if(OnChannelVarsetEvent != null)
						OnChannelVarsetEvent(this, (ChannelVarsetEvent)eventArgs);
					break;
			
			
				case "EndpointStateChange":
					if(OnEndpointStateChangeEvent != null)
						OnEndpointStateChangeEvent(this, (EndpointStateChangeEvent)eventArgs);
					break;
			
			
				case "Dial":
					if(OnDialEvent != null)
						OnDialEvent(this, (DialEvent)eventArgs);
					break;
			
			
				case "StasisEnd":
					if(OnStasisEndEvent != null)
						OnStasisEndEvent(this, (StasisEndEvent)eventArgs);
					break;
			
			
				case "StasisStart":
					if(OnStasisStartEvent != null)
						OnStasisStartEvent(this, (StasisStartEvent)eventArgs);
					break;
				default:
					if(OnUnhandledEvent!=null)
						OnUnhandledEvent(this, (Event)eventArgs);
					break;
			}
		}
	}
}
