/*
	AsterNET ARI Framework
	Automatically generated file @ 7/5/2016 5:35:10 PM
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
	public delegate void TextMessageReceivedEventHandler(IAriClient sender, TextMessageReceivedEvent e);
	public delegate void ChannelEnteredBridgeEventHandler(IAriClient sender, ChannelEnteredBridgeEvent e);
	public delegate void BridgeDestroyedEventHandler(IAriClient sender, BridgeDestroyedEvent e);
	public delegate void BridgeBlindTransferEventHandler(IAriClient sender, BridgeBlindTransferEvent e);
	public delegate void ChannelUsereventEventHandler(IAriClient sender, ChannelUsereventEvent e);
	public delegate void ChannelDialplanEventHandler(IAriClient sender, ChannelDialplanEvent e);
	public delegate void ChannelHangupRequestEventHandler(IAriClient sender, ChannelHangupRequestEvent e);
	public delegate void ChannelVarsetEventHandler(IAriClient sender, ChannelVarsetEvent e);
	public delegate void ChannelHoldEventHandler(IAriClient sender, ChannelHoldEvent e);
	public delegate void ChannelConnectedLineEventHandler(IAriClient sender, ChannelConnectedLineEvent e);
	public delegate void ChannelUnholdEventHandler(IAriClient sender, ChannelUnholdEvent e);
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
		event TextMessageReceivedEventHandler OnTextMessageReceivedEvent;
		event ChannelEnteredBridgeEventHandler OnChannelEnteredBridgeEvent;
		event BridgeDestroyedEventHandler OnBridgeDestroyedEvent;
		event BridgeBlindTransferEventHandler OnBridgeBlindTransferEvent;
		event ChannelUsereventEventHandler OnChannelUsereventEvent;
		event ChannelDialplanEventHandler OnChannelDialplanEvent;
		event ChannelHangupRequestEventHandler OnChannelHangupRequestEvent;
		event ChannelVarsetEventHandler OnChannelVarsetEvent;
		event ChannelHoldEventHandler OnChannelHoldEvent;
		event ChannelConnectedLineEventHandler OnChannelConnectedLineEvent;
		event ChannelUnholdEventHandler OnChannelUnholdEvent;
		event EndpointStateChangeEventHandler OnEndpointStateChangeEvent;
		event DialEventHandler OnDialEvent;
		event StasisEndEventHandler OnStasisEndEvent;
		event StasisStartEventHandler OnStasisStartEvent;
		event UnhandledEventHandler OnUnhandledEvent;
	}


	/// <summary>
	/// 
	/// </summary>
	public partial class BaseAriClient
	{
		#region Events
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
					public event ChannelTalkingFinishedEventHandler OnChannelTalkingFinishedEvent;
					public event PlaybackStartedEventHandler OnPlaybackStartedEvent;
					public event ChannelTalkingStartedEventHandler OnChannelTalkingStartedEvent;
					public event RecordingFailedEventHandler OnRecordingFailedEvent;
					public event BridgeMergedEventHandler OnBridgeMergedEvent;
					public event RecordingFinishedEventHandler OnRecordingFinishedEvent;
					public event BridgeAttendedTransferEventHandler OnBridgeAttendedTransferEvent;
					public event TextMessageReceivedEventHandler OnTextMessageReceivedEvent;
					public event ChannelEnteredBridgeEventHandler OnChannelEnteredBridgeEvent;
					public event BridgeDestroyedEventHandler OnBridgeDestroyedEvent;
					public event BridgeBlindTransferEventHandler OnBridgeBlindTransferEvent;
					public event ChannelUsereventEventHandler OnChannelUsereventEvent;
					public event ChannelDialplanEventHandler OnChannelDialplanEvent;
					public event ChannelHangupRequestEventHandler OnChannelHangupRequestEvent;
					public event ChannelVarsetEventHandler OnChannelVarsetEvent;
					public event ChannelHoldEventHandler OnChannelHoldEvent;
					public event ChannelConnectedLineEventHandler OnChannelConnectedLineEvent;
					public event ChannelUnholdEventHandler OnChannelUnholdEvent;
					public event EndpointStateChangeEventHandler OnEndpointStateChangeEvent;
					public event DialEventHandler OnDialEvent;
					public event StasisEndEventHandler OnStasisEndEvent;
					public event StasisStartEventHandler OnStasisStartEvent;
				public event UnhandledEventHandler OnUnhandledEvent;
		#endregion

		protected void FireEvent(string eventName, object eventArgs, IAriClient sender)
		{
		
			switch(eventName) 
			{
			
			
				case "ChannelCallerId":
					if(OnChannelCallerIdEvent != null)
						OnChannelCallerIdEvent(sender, (ChannelCallerIdEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "ChannelDtmfReceived":
					if(OnChannelDtmfReceivedEvent != null)
						OnChannelDtmfReceivedEvent(sender, (ChannelDtmfReceivedEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "BridgeCreated":
					if(OnBridgeCreatedEvent != null)
						OnBridgeCreatedEvent(sender, (BridgeCreatedEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "ChannelCreated":
					if(OnChannelCreatedEvent != null)
						OnChannelCreatedEvent(sender, (ChannelCreatedEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "ApplicationReplaced":
					if(OnApplicationReplacedEvent != null)
						OnApplicationReplacedEvent(sender, (ApplicationReplacedEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "ChannelStateChange":
					if(OnChannelStateChangeEvent != null)
						OnChannelStateChangeEvent(sender, (ChannelStateChangeEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "PlaybackFinished":
					if(OnPlaybackFinishedEvent != null)
						OnPlaybackFinishedEvent(sender, (PlaybackFinishedEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "RecordingStarted":
					if(OnRecordingStartedEvent != null)
						OnRecordingStartedEvent(sender, (RecordingStartedEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "ChannelLeftBridge":
					if(OnChannelLeftBridgeEvent != null)
						OnChannelLeftBridgeEvent(sender, (ChannelLeftBridgeEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "ChannelDestroyed":
					if(OnChannelDestroyedEvent != null)
						OnChannelDestroyedEvent(sender, (ChannelDestroyedEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "DeviceStateChanged":
					if(OnDeviceStateChangedEvent != null)
						OnDeviceStateChangedEvent(sender, (DeviceStateChangedEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "ChannelTalkingFinished":
					if(OnChannelTalkingFinishedEvent != null)
						OnChannelTalkingFinishedEvent(sender, (ChannelTalkingFinishedEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "PlaybackStarted":
					if(OnPlaybackStartedEvent != null)
						OnPlaybackStartedEvent(sender, (PlaybackStartedEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "ChannelTalkingStarted":
					if(OnChannelTalkingStartedEvent != null)
						OnChannelTalkingStartedEvent(sender, (ChannelTalkingStartedEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "RecordingFailed":
					if(OnRecordingFailedEvent != null)
						OnRecordingFailedEvent(sender, (RecordingFailedEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "BridgeMerged":
					if(OnBridgeMergedEvent != null)
						OnBridgeMergedEvent(sender, (BridgeMergedEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "RecordingFinished":
					if(OnRecordingFinishedEvent != null)
						OnRecordingFinishedEvent(sender, (RecordingFinishedEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "BridgeAttendedTransfer":
					if(OnBridgeAttendedTransferEvent != null)
						OnBridgeAttendedTransferEvent(sender, (BridgeAttendedTransferEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "TextMessageReceived":
					if(OnTextMessageReceivedEvent != null)
						OnTextMessageReceivedEvent(sender, (TextMessageReceivedEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "ChannelEnteredBridge":
					if(OnChannelEnteredBridgeEvent != null)
						OnChannelEnteredBridgeEvent(sender, (ChannelEnteredBridgeEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "BridgeDestroyed":
					if(OnBridgeDestroyedEvent != null)
						OnBridgeDestroyedEvent(sender, (BridgeDestroyedEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "BridgeBlindTransfer":
					if(OnBridgeBlindTransferEvent != null)
						OnBridgeBlindTransferEvent(sender, (BridgeBlindTransferEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "ChannelUserevent":
					if(OnChannelUsereventEvent != null)
						OnChannelUsereventEvent(sender, (ChannelUsereventEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "ChannelDialplan":
					if(OnChannelDialplanEvent != null)
						OnChannelDialplanEvent(sender, (ChannelDialplanEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "ChannelHangupRequest":
					if(OnChannelHangupRequestEvent != null)
						OnChannelHangupRequestEvent(sender, (ChannelHangupRequestEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "ChannelVarset":
					if(OnChannelVarsetEvent != null)
						OnChannelVarsetEvent(sender, (ChannelVarsetEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "ChannelHold":
					if(OnChannelHoldEvent != null)
						OnChannelHoldEvent(sender, (ChannelHoldEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "ChannelConnectedLine":
					if(OnChannelConnectedLineEvent != null)
						OnChannelConnectedLineEvent(sender, (ChannelConnectedLineEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "ChannelUnhold":
					if(OnChannelUnholdEvent != null)
						OnChannelUnholdEvent(sender, (ChannelUnholdEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "EndpointStateChange":
					if(OnEndpointStateChangeEvent != null)
						OnEndpointStateChangeEvent(sender, (EndpointStateChangeEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "Dial":
					if(OnDialEvent != null)
						OnDialEvent(sender, (DialEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "StasisEnd":
					if(OnStasisEndEvent != null)
						OnStasisEndEvent(sender, (StasisEndEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			
			
				case "StasisStart":
					if(OnStasisStartEvent != null)
						OnStasisStartEvent(sender, (StasisStartEvent)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
				default:
					if(OnUnhandledEvent!=null)
						OnUnhandledEvent(this, (Event)eventArgs);
					else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event) eventArgs);
					break;
			}
		}
	}
}
