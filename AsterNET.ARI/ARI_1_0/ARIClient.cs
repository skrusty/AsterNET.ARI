/*
	AsterNET ARI Framework
	Automatically generated file @ 9/22/2016 4:43:50 PM
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;

namespace AsterNET.ARI
{
    public delegate void DeviceStateChangedEventHandler(IAriClient sender, DeviceStateChangedEvent e);
    public delegate void PlaybackStartedEventHandler(IAriClient sender, PlaybackStartedEvent e);
    public delegate void PlaybackContinuingEventHandler(IAriClient sender, PlaybackContinuingEvent e);
    public delegate void PlaybackFinishedEventHandler(IAriClient sender, PlaybackFinishedEvent e);
    public delegate void RecordingStartedEventHandler(IAriClient sender, RecordingStartedEvent e);
    public delegate void RecordingFinishedEventHandler(IAriClient sender, RecordingFinishedEvent e);
    public delegate void RecordingFailedEventHandler(IAriClient sender, RecordingFailedEvent e);
    public delegate void ApplicationReplacedEventHandler(IAriClient sender, ApplicationReplacedEvent e);
    public delegate void BridgeCreatedEventHandler(IAriClient sender, BridgeCreatedEvent e);
    public delegate void BridgeDestroyedEventHandler(IAriClient sender, BridgeDestroyedEvent e);
    public delegate void BridgeMergedEventHandler(IAriClient sender, BridgeMergedEvent e);
    public delegate void BridgeBlindTransferEventHandler(IAriClient sender, BridgeBlindTransferEvent e);
    public delegate void BridgeAttendedTransferEventHandler(IAriClient sender, BridgeAttendedTransferEvent e);
    public delegate void ChannelCreatedEventHandler(IAriClient sender, ChannelCreatedEvent e);
    public delegate void ChannelDestroyedEventHandler(IAriClient sender, ChannelDestroyedEvent e);
    public delegate void ChannelEnteredBridgeEventHandler(IAriClient sender, ChannelEnteredBridgeEvent e);
    public delegate void ChannelLeftBridgeEventHandler(IAriClient sender, ChannelLeftBridgeEvent e);
    public delegate void ChannelStateChangeEventHandler(IAriClient sender, ChannelStateChangeEvent e);
    public delegate void ChannelDtmfReceivedEventHandler(IAriClient sender, ChannelDtmfReceivedEvent e);
    public delegate void ChannelDialplanEventHandler(IAriClient sender, ChannelDialplanEvent e);
    public delegate void ChannelCallerIdEventHandler(IAriClient sender, ChannelCallerIdEvent e);
    public delegate void ChannelUsereventEventHandler(IAriClient sender, ChannelUsereventEvent e);
    public delegate void ChannelHangupRequestEventHandler(IAriClient sender, ChannelHangupRequestEvent e);
    public delegate void ChannelVarsetEventHandler(IAriClient sender, ChannelVarsetEvent e);
    public delegate void ChannelHoldEventHandler(IAriClient sender, ChannelHoldEvent e);
    public delegate void ChannelUnholdEventHandler(IAriClient sender, ChannelUnholdEvent e);
    public delegate void ChannelTalkingStartedEventHandler(IAriClient sender, ChannelTalkingStartedEvent e);
    public delegate void ChannelTalkingFinishedEventHandler(IAriClient sender, ChannelTalkingFinishedEvent e);
    public delegate void ContactStatusChangeEventHandler(IAriClient sender, ContactStatusChangeEvent e);
    public delegate void PeerStatusChangeEventHandler(IAriClient sender, PeerStatusChangeEvent e);
    public delegate void EndpointStateChangeEventHandler(IAriClient sender, EndpointStateChangeEvent e);
    public delegate void DialEventHandler(IAriClient sender, DialEvent e);
    public delegate void StasisEndEventHandler(IAriClient sender, StasisEndEvent e);
    public delegate void StasisStartEventHandler(IAriClient sender, StasisStartEvent e);
    public delegate void TextMessageReceivedEventHandler(IAriClient sender, TextMessageReceivedEvent e);
    public delegate void ChannelConnectedLineEventHandler(IAriClient sender, ChannelConnectedLineEvent e);
    public delegate void UnhandledEventHandler(object sender, AsterNET.ARI.Models.Event eventMessage);
    public delegate void UnhandledExceptionEventHandler(object sender, Exception exception);

    public interface IAriEventClient
    {
        event DeviceStateChangedEventHandler OnDeviceStateChangedEvent;
        event PlaybackStartedEventHandler OnPlaybackStartedEvent;
        event PlaybackContinuingEventHandler OnPlaybackContinuingEvent;
        event PlaybackFinishedEventHandler OnPlaybackFinishedEvent;
        event RecordingStartedEventHandler OnRecordingStartedEvent;
        event RecordingFinishedEventHandler OnRecordingFinishedEvent;
        event RecordingFailedEventHandler OnRecordingFailedEvent;
        event ApplicationReplacedEventHandler OnApplicationReplacedEvent;
        event BridgeCreatedEventHandler OnBridgeCreatedEvent;
        event BridgeDestroyedEventHandler OnBridgeDestroyedEvent;
        event BridgeMergedEventHandler OnBridgeMergedEvent;
        event BridgeBlindTransferEventHandler OnBridgeBlindTransferEvent;
        event BridgeAttendedTransferEventHandler OnBridgeAttendedTransferEvent;
        event ChannelCreatedEventHandler OnChannelCreatedEvent;
        event ChannelDestroyedEventHandler OnChannelDestroyedEvent;
        event ChannelEnteredBridgeEventHandler OnChannelEnteredBridgeEvent;
        event ChannelLeftBridgeEventHandler OnChannelLeftBridgeEvent;
        event ChannelStateChangeEventHandler OnChannelStateChangeEvent;
        event ChannelDtmfReceivedEventHandler OnChannelDtmfReceivedEvent;
        event ChannelDialplanEventHandler OnChannelDialplanEvent;
        event ChannelCallerIdEventHandler OnChannelCallerIdEvent;
        event ChannelUsereventEventHandler OnChannelUsereventEvent;
        event ChannelHangupRequestEventHandler OnChannelHangupRequestEvent;
        event ChannelVarsetEventHandler OnChannelVarsetEvent;
        event ChannelHoldEventHandler OnChannelHoldEvent;
        event ChannelUnholdEventHandler OnChannelUnholdEvent;
        event ChannelTalkingStartedEventHandler OnChannelTalkingStartedEvent;
        event ChannelTalkingFinishedEventHandler OnChannelTalkingFinishedEvent;
        event ContactStatusChangeEventHandler OnContactStatusChangeEvent;
        event PeerStatusChangeEventHandler OnPeerStatusChangeEvent;
        event EndpointStateChangeEventHandler OnEndpointStateChangeEvent;
        event DialEventHandler OnDialEvent;
        event StasisEndEventHandler OnStasisEndEvent;
        event StasisStartEventHandler OnStasisStartEvent;
        event TextMessageReceivedEventHandler OnTextMessageReceivedEvent;
        event ChannelConnectedLineEventHandler OnChannelConnectedLineEvent;
        event UnhandledEventHandler OnUnhandledEvent;
        event UnhandledExceptionEventHandler OnUnhandledException;
    }


    /// <summary>
    /// 
    /// </summary>
    public class BaseAriClient : IAriEventClient
    {

        #region Events
        public event DeviceStateChangedEventHandler OnDeviceStateChangedEvent;
        public event PlaybackStartedEventHandler OnPlaybackStartedEvent;
        public event PlaybackContinuingEventHandler OnPlaybackContinuingEvent;
        public event PlaybackFinishedEventHandler OnPlaybackFinishedEvent;
        public event RecordingStartedEventHandler OnRecordingStartedEvent;
        public event RecordingFinishedEventHandler OnRecordingFinishedEvent;
        public event RecordingFailedEventHandler OnRecordingFailedEvent;
        public event ApplicationReplacedEventHandler OnApplicationReplacedEvent;
        public event BridgeCreatedEventHandler OnBridgeCreatedEvent;
        public event BridgeDestroyedEventHandler OnBridgeDestroyedEvent;
        public event BridgeMergedEventHandler OnBridgeMergedEvent;
        public event BridgeBlindTransferEventHandler OnBridgeBlindTransferEvent;
        public event BridgeAttendedTransferEventHandler OnBridgeAttendedTransferEvent;
        public event ChannelCreatedEventHandler OnChannelCreatedEvent;
        public event ChannelDestroyedEventHandler OnChannelDestroyedEvent;
        public event ChannelEnteredBridgeEventHandler OnChannelEnteredBridgeEvent;
        public event ChannelLeftBridgeEventHandler OnChannelLeftBridgeEvent;
        public event ChannelStateChangeEventHandler OnChannelStateChangeEvent;
        public event ChannelDtmfReceivedEventHandler OnChannelDtmfReceivedEvent;
        public event ChannelDialplanEventHandler OnChannelDialplanEvent;
        public event ChannelCallerIdEventHandler OnChannelCallerIdEvent;
        public event ChannelUsereventEventHandler OnChannelUsereventEvent;
        public event ChannelHangupRequestEventHandler OnChannelHangupRequestEvent;
        public event ChannelVarsetEventHandler OnChannelVarsetEvent;
        public event ChannelHoldEventHandler OnChannelHoldEvent;
        public event ChannelUnholdEventHandler OnChannelUnholdEvent;
        public event ChannelTalkingStartedEventHandler OnChannelTalkingStartedEvent;
        public event ChannelTalkingFinishedEventHandler OnChannelTalkingFinishedEvent;
        public event ContactStatusChangeEventHandler OnContactStatusChangeEvent;
        public event PeerStatusChangeEventHandler OnPeerStatusChangeEvent;
        public event EndpointStateChangeEventHandler OnEndpointStateChangeEvent;
        public event DialEventHandler OnDialEvent;
        public event StasisEndEventHandler OnStasisEndEvent;
        public event StasisStartEventHandler OnStasisStartEvent;
        public event TextMessageReceivedEventHandler OnTextMessageReceivedEvent;
        public event ChannelConnectedLineEventHandler OnChannelConnectedLineEvent;
        public event UnhandledEventHandler OnUnhandledEvent;
        public event UnhandledExceptionEventHandler OnUnhandledException;
        #endregion

        protected bool UnhandledException(object sender, Exception exception)
        {
            if (OnUnhandledException != null)
            {
                OnUnhandledException(sender, exception);
                return true;
            }

            return false;
        }

        protected void FireEvent(string eventName, object eventArgs, IAriClient sender)
        {

            switch (eventName)
            {


                case "DeviceStateChanged":
                    if (OnDeviceStateChangedEvent != null)
                        OnDeviceStateChangedEvent(sender, (DeviceStateChangedEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "PlaybackStarted":
                    if (OnPlaybackStartedEvent != null)
                        OnPlaybackStartedEvent(sender, (PlaybackStartedEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "PlaybackContinuing":
                    if (OnPlaybackContinuingEvent != null)
                        OnPlaybackContinuingEvent(sender, (PlaybackContinuingEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "PlaybackFinished":
                    if (OnPlaybackFinishedEvent != null)
                        OnPlaybackFinishedEvent(sender, (PlaybackFinishedEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "RecordingStarted":
                    if (OnRecordingStartedEvent != null)
                        OnRecordingStartedEvent(sender, (RecordingStartedEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "RecordingFinished":
                    if (OnRecordingFinishedEvent != null)
                        OnRecordingFinishedEvent(sender, (RecordingFinishedEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "RecordingFailed":
                    if (OnRecordingFailedEvent != null)
                        OnRecordingFailedEvent(sender, (RecordingFailedEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ApplicationReplaced":
                    if (OnApplicationReplacedEvent != null)
                        OnApplicationReplacedEvent(sender, (ApplicationReplacedEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "BridgeCreated":
                    if (OnBridgeCreatedEvent != null)
                        OnBridgeCreatedEvent(sender, (BridgeCreatedEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "BridgeDestroyed":
                    if (OnBridgeDestroyedEvent != null)
                        OnBridgeDestroyedEvent(sender, (BridgeDestroyedEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "BridgeMerged":
                    if (OnBridgeMergedEvent != null)
                        OnBridgeMergedEvent(sender, (BridgeMergedEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "BridgeBlindTransfer":
                    if (OnBridgeBlindTransferEvent != null)
                        OnBridgeBlindTransferEvent(sender, (BridgeBlindTransferEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "BridgeAttendedTransfer":
                    if (OnBridgeAttendedTransferEvent != null)
                        OnBridgeAttendedTransferEvent(sender, (BridgeAttendedTransferEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ChannelCreated":
                    if (OnChannelCreatedEvent != null)
                        OnChannelCreatedEvent(sender, (ChannelCreatedEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ChannelDestroyed":
                    if (OnChannelDestroyedEvent != null)
                        OnChannelDestroyedEvent(sender, (ChannelDestroyedEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ChannelEnteredBridge":
                    if (OnChannelEnteredBridgeEvent != null)
                        OnChannelEnteredBridgeEvent(sender, (ChannelEnteredBridgeEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ChannelLeftBridge":
                    if (OnChannelLeftBridgeEvent != null)
                        OnChannelLeftBridgeEvent(sender, (ChannelLeftBridgeEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ChannelStateChange":
                    if (OnChannelStateChangeEvent != null)
                        OnChannelStateChangeEvent(sender, (ChannelStateChangeEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ChannelDtmfReceived":
                    if (OnChannelDtmfReceivedEvent != null)
                        OnChannelDtmfReceivedEvent(sender, (ChannelDtmfReceivedEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ChannelDialplan":
                    if (OnChannelDialplanEvent != null)
                        OnChannelDialplanEvent(sender, (ChannelDialplanEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ChannelCallerId":
                    if (OnChannelCallerIdEvent != null)
                        OnChannelCallerIdEvent(sender, (ChannelCallerIdEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ChannelUserevent":
                    if (OnChannelUsereventEvent != null)
                        OnChannelUsereventEvent(sender, (ChannelUsereventEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ChannelHangupRequest":
                    if (OnChannelHangupRequestEvent != null)
                        OnChannelHangupRequestEvent(sender, (ChannelHangupRequestEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ChannelVarset":
                    if (OnChannelVarsetEvent != null)
                        OnChannelVarsetEvent(sender, (ChannelVarsetEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ChannelHold":
                    if (OnChannelHoldEvent != null)
                        OnChannelHoldEvent(sender, (ChannelHoldEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ChannelUnhold":
                    if (OnChannelUnholdEvent != null)
                        OnChannelUnholdEvent(sender, (ChannelUnholdEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ChannelTalkingStarted":
                    if (OnChannelTalkingStartedEvent != null)
                        OnChannelTalkingStartedEvent(sender, (ChannelTalkingStartedEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ChannelTalkingFinished":
                    if (OnChannelTalkingFinishedEvent != null)
                        OnChannelTalkingFinishedEvent(sender, (ChannelTalkingFinishedEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ContactStatusChange":
                    if (OnContactStatusChangeEvent != null)
                        OnContactStatusChangeEvent(sender, (ContactStatusChangeEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "PeerStatusChange":
                    if (OnPeerStatusChangeEvent != null)
                        OnPeerStatusChangeEvent(sender, (PeerStatusChangeEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "EndpointStateChange":
                    if (OnEndpointStateChangeEvent != null)
                        OnEndpointStateChangeEvent(sender, (EndpointStateChangeEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "Dial":
                    if (OnDialEvent != null)
                        OnDialEvent(sender, (DialEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "StasisEnd":
                    if (OnStasisEndEvent != null)
                        OnStasisEndEvent(sender, (StasisEndEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "StasisStart":
                    if (OnStasisStartEvent != null)
                        OnStasisStartEvent(sender, (StasisStartEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "TextMessageReceived":
                    if (OnTextMessageReceivedEvent != null)
                        OnTextMessageReceivedEvent(sender, (TextMessageReceivedEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;


                case "ChannelConnectedLine":
                    if (OnChannelConnectedLineEvent != null)
                        OnChannelConnectedLineEvent(sender, (ChannelConnectedLineEvent)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;
                default:
                    if (OnUnhandledEvent != null)
                        OnUnhandledEvent(this, (Event)eventArgs);
                    else if (OnUnhandledEvent != null) OnUnhandledEvent(sender, (Event)eventArgs);
                    break;
            }
        }
    }
}
