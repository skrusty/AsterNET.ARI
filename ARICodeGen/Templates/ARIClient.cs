/*
	AsterNET ARI Framework
	Automatically generated file @ 17/03/2015 15:48:04
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;

namespace AsterNET.ARI
{
	public delegate void ChannelCallerIdEventHandler(IAriClient sender, ChannelCallerIdEvent e);
	public delegate void ChannelDtmfReceivedEventHandler(IAriClient sender, ChannelDtmfReceivedEvent e);
	public delegate void BridgeCreatedEventHandler(IAriClient sender, BridgeCreatedEvent e);
	public delegate void ChannelCreatedEventHandler(IAriClient sender, ChannelCreatedEvent e);
	public delegate void ApplicationReplacedEventHandler(IAriClient sender, ApplicationReplacedEvent e);
	public delegate void ChannelStateChangeEventHandler(IAriClient sender, ChannelStateChangeEvent e);
	public delegate void PlaybackFinishedEventHandler(IAriClient sender, PlaybackFinishedEvent e);
	public delegate void RecordingStartedEventHandler(IAriClient sender, RecordingStartedEvent e);
	public delegate void ChannelLeftBridgeEventHandler(IAriClient sender, ChannelLeftBridgeEvent e);
	public delegate void ChannelDestroyedEventHandler(IAriClient sender, ChannelDestroyedEvent e);
	public delegate void DeviceStateChangedEventHandler(IAriClient sender, DeviceStateChangedEvent e);
	public delegate void ChannelTalkingFinishedEventHandler(IAriClient sender, ChannelTalkingFinishedEvent e);
	public delegate void PlaybackStartedEventHandler(IAriClient sender, PlaybackStartedEvent e);
	public delegate void ChannelTalkingStartedEventHandler(IAriClient sender, ChannelTalkingStartedEvent e);
	public delegate void RecordingFailedEventHandler(IAriClient sender, RecordingFailedEvent e);
	public delegate void BridgeMergedEventHandler(IAriClient sender, BridgeMergedEvent e);
	public delegate void RecordingFinishedEventHandler(IAriClient sender, RecordingFinishedEvent e);
	public delegate void BridgeAttendedTransferEventHandler(IAriClient sender, BridgeAttendedTransferEvent e);
	public delegate void ChannelEnteredBridgeEventHandler(IAriClient sender, ChannelEnteredBridgeEvent e);
	public delegate void BridgeDestroyedEventHandler(IAriClient sender, BridgeDestroyedEvent e);
	public delegate void BridgeBlindTransferEventHandler(IAriClient sender, BridgeBlindTransferEvent e);
	public delegate void ChannelUsereventEventHandler(IAriClient sender, ChannelUsereventEvent e);
	public delegate void ChannelDialplanEventHandler(IAriClient sender, ChannelDialplanEvent e);
	public delegate void ChannelHangupRequestEventHandler(IAriClient sender, ChannelHangupRequestEvent e);
	public delegate void ChannelVarsetEventHandler(IAriClient sender, ChannelVarsetEvent e);
	public delegate void EndpointStateChangeEventHandler(IAriClient sender, EndpointStateChangeEvent e);
	public delegate void DialEventHandler(IAriClient sender, DialEvent e);
	public delegate void StasisEndEventHandler(IAriClient sender, StasisEndEvent e);
	public delegate void StasisStartEventHandler(IAriClient sender, StasisStartEvent e);
	public delegate void UnhandledEventHandler(object sender, AsterNET.ARI.Models.Event eventMessage);


	public interface IAriEventClient
	{
		event ChannelCallerIdEventHandler OnChannelCallerIdEvent;
		event ChannelDtmfReceivedEventHandler OnChannelDtmfReceivedEvent;
		event BridgeCreatedEventHandler OnBridgeCreatedEvent;
		event ChannelCreatedEventHandler OnChannelCreatedEvent;
		event ApplicationReplacedEventHandler OnApplicationReplacedEvent;
		event ChannelStateChangeEventHandler OnChannelStateChangeEvent;
		event PlaybackFinishedEventHandler OnPlaybackFinishedEvent;
		event RecordingStartedEventHandler OnRecordingStartedEvent;
		event ChannelLeftBridgeEventHandler OnChannelLeftBridgeEvent;
		event ChannelDestroyedEventHandler OnChannelDestroyedEvent;
		event DeviceStateChangedEventHandler OnDeviceStateChangedEvent;
		event ChannelTalkingFinishedEventHandler OnChannelTalkingFinishedEvent;
		event PlaybackStartedEventHandler OnPlaybackStartedEvent;
		event ChannelTalkingStartedEventHandler OnChannelTalkingStartedEvent;
		event RecordingFailedEventHandler OnRecordingFailedEvent;
		event BridgeMergedEventHandler OnBridgeMergedEvent;
		event RecordingFinishedEventHandler OnRecordingFinishedEvent;
		event BridgeAttendedTransferEventHandler OnBridgeAttendedTransferEvent;
		event ChannelEnteredBridgeEventHandler OnChannelEnteredBridgeEvent;
		event BridgeDestroyedEventHandler OnBridgeDestroyedEvent;
		event BridgeBlindTransferEventHandler OnBridgeBlindTransferEvent;
		event ChannelUsereventEventHandler OnChannelUsereventEvent;
		event ChannelDialplanEventHandler OnChannelDialplanEvent;
		event ChannelHangupRequestEventHandler OnChannelHangupRequestEvent;
		event ChannelVarsetEventHandler OnChannelVarsetEvent;
		event EndpointStateChangeEventHandler OnEndpointStateChangeEvent;
		event DialEventHandler OnDialEvent;
		event StasisEndEventHandler OnStasisEndEvent;
		event StasisStartEventHandler OnStasisStartEvent;
		event UnhandledEventHandler OnUnhandledEvent;
	}


	/// <summary>
	/// 
	/// </summary>
	public partial class BaseARIClient
	{
		
		protected void FireEvent(string eventName, object eventArgs, object sender)
		{
		
			switch(eventName) 
			{
			
			
				case "ChannelCallerId":
					if(OnChannelCallerIdEvent != null)
						OnChannelCallerIdEvent(sender, (ChannelCallerIdEvent)eventArgs);
					break;
			
			
				case "ChannelDtmfReceived":
					if(OnChannelDtmfReceivedEvent != null)
						OnChannelDtmfReceivedEvent(sender, (ChannelDtmfReceivedEvent)eventArgs);
					break;
			
			
				case "BridgeCreated":
					if(OnBridgeCreatedEvent != null)
						OnBridgeCreatedEvent(sender, (BridgeCreatedEvent)eventArgs);
					break;
			
			
				case "ChannelCreated":
					if(OnChannelCreatedEvent != null)
						OnChannelCreatedEvent(sender, (ChannelCreatedEvent)eventArgs);
					break;
			
			
				case "ApplicationReplaced":
					if(OnApplicationReplacedEvent != null)
						OnApplicationReplacedEvent(sender, (ApplicationReplacedEvent)eventArgs);
					break;
			
			
				case "ChannelStateChange":
					if(OnChannelStateChangeEvent != null)
						OnChannelStateChangeEvent(sender, (ChannelStateChangeEvent)eventArgs);
					break;
			
			
				case "PlaybackFinished":
					if(OnPlaybackFinishedEvent != null)
						OnPlaybackFinishedEvent(sender, (PlaybackFinishedEvent)eventArgs);
					break;
			
			
				case "RecordingStarted":
					if(OnRecordingStartedEvent != null)
						OnRecordingStartedEvent(sender, (RecordingStartedEvent)eventArgs);
					break;
			
			
				case "ChannelLeftBridge":
					if(OnChannelLeftBridgeEvent != null)
						OnChannelLeftBridgeEvent(sender, (ChannelLeftBridgeEvent)eventArgs);
					break;
			
			
				case "ChannelDestroyed":
					if(OnChannelDestroyedEvent != null)
						OnChannelDestroyedEvent(sender, (ChannelDestroyedEvent)eventArgs);
					break;
			
			
				case "DeviceStateChanged":
					if(OnDeviceStateChangedEvent != null)
						OnDeviceStateChangedEvent(sender, (DeviceStateChangedEvent)eventArgs);
					break;
			
			
				case "ChannelTalkingFinished":
					if(OnChannelTalkingFinishedEvent != null)
						OnChannelTalkingFinishedEvent(sender, (ChannelTalkingFinishedEvent)eventArgs);
					break;
			
			
				case "PlaybackStarted":
					if(OnPlaybackStartedEvent != null)
						OnPlaybackStartedEvent(sender, (PlaybackStartedEvent)eventArgs);
					break;
			
			
				case "ChannelTalkingStarted":
					if(OnChannelTalkingStartedEvent != null)
						OnChannelTalkingStartedEvent(sender, (ChannelTalkingStartedEvent)eventArgs);
					break;
			
			
				case "RecordingFailed":
					if(OnRecordingFailedEvent != null)
						OnRecordingFailedEvent(sender, (RecordingFailedEvent)eventArgs);
					break;
			
			
				case "BridgeMerged":
					if(OnBridgeMergedEvent != null)
						OnBridgeMergedEvent(sender, (BridgeMergedEvent)eventArgs);
					break;
			
			
				case "RecordingFinished":
					if(OnRecordingFinishedEvent != null)
						OnRecordingFinishedEvent(sender, (RecordingFinishedEvent)eventArgs);
					break;
			
			
				case "BridgeAttendedTransfer":
					if(OnBridgeAttendedTransferEvent != null)
						OnBridgeAttendedTransferEvent(sender, (BridgeAttendedTransferEvent)eventArgs);
					break;
			
			
				case "ChannelEnteredBridge":
					if(OnChannelEnteredBridgeEvent != null)
						OnChannelEnteredBridgeEvent(sender, (ChannelEnteredBridgeEvent)eventArgs);
					break;
			
			
				case "BridgeDestroyed":
					if(OnBridgeDestroyedEvent != null)
						OnBridgeDestroyedEvent(sender, (BridgeDestroyedEvent)eventArgs);
					break;
			
			
				case "BridgeBlindTransfer":
					if(OnBridgeBlindTransferEvent != null)
						OnBridgeBlindTransferEvent(sender, (BridgeBlindTransferEvent)eventArgs);
					break;
			
			
				case "ChannelUserevent":
					if(OnChannelUsereventEvent != null)
						OnChannelUsereventEvent(sender, (ChannelUsereventEvent)eventArgs);
					break;
			
			
				case "ChannelDialplan":
					if(OnChannelDialplanEvent != null)
						OnChannelDialplanEvent(sender, (ChannelDialplanEvent)eventArgs);
					break;
			
			
				case "ChannelHangupRequest":
					if(OnChannelHangupRequestEvent != null)
						OnChannelHangupRequestEvent(sender, (ChannelHangupRequestEvent)eventArgs);
					break;
			
			
				case "ChannelVarset":
					if(OnChannelVarsetEvent != null)
						OnChannelVarsetEvent(sender, (ChannelVarsetEvent)eventArgs);
					break;
			
			
				case "EndpointStateChange":
					if(OnEndpointStateChangeEvent != null)
						OnEndpointStateChangeEvent(sender, (EndpointStateChangeEvent)eventArgs);
					break;
			
			
				case "Dial":
					if(OnDialEvent != null)
						OnDialEvent(sender, (DialEvent)eventArgs);
					break;
			
			
				case "StasisEnd":
					if(OnStasisEndEvent != null)
						OnStasisEndEvent(sender, (StasisEndEvent)eventArgs);
					break;
			
			
				case "StasisStart":
					if(OnStasisStartEvent != null)
						OnStasisStartEvent(sender, (StasisStartEvent)eventArgs);
					break;
				default:
					if(OnUnhandledEvent!=null)
						OnUnhandledEvent(this, (Event)eventArgs);
					break;
			}
		}
	}
}
