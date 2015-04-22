/*
	AsterNET ARI Framework
	Automatically generated file @ 22/04/2015 09:45:42
*/

using AsterNET.ARI.Models;

namespace AsterNET.ARI
{
	public delegate void DeviceStateChangedEventHandler(IAriClient sender, DeviceStateChangedEvent e);

	public delegate void PlaybackStartedEventHandler(IAriClient sender, PlaybackStartedEvent e);

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

	public delegate void ChannelTalkingStartedEventHandler(IAriClient sender, ChannelTalkingStartedEvent e);

	public delegate void ChannelTalkingFinishedEventHandler(IAriClient sender, ChannelTalkingFinishedEvent e);

	public delegate void EndpointStateChangeEventHandler(IAriClient sender, EndpointStateChangeEvent e);

	public delegate void DialEventHandler(IAriClient sender, DialEvent e);

	public delegate void StasisEndEventHandler(IAriClient sender, StasisEndEvent e);

	public delegate void StasisStartEventHandler(IAriClient sender, StasisStartEvent e);

	public delegate void TextMessageReceivedEventHandler(IAriClient sender, TextMessageReceivedEvent e);

	public delegate void ChannelConnectedLineEventHandler(IAriClient sender, ChannelConnectedLineEvent e);

	public delegate void UnhandledEventHandler(object sender, Event eventMessage);


	public interface IAriEventClient
	{
		event DeviceStateChangedEventHandler OnDeviceStateChangedEvent;
		event PlaybackStartedEventHandler OnPlaybackStartedEvent;
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
		event ChannelTalkingStartedEventHandler OnChannelTalkingStartedEvent;
		event ChannelTalkingFinishedEventHandler OnChannelTalkingFinishedEvent;
		event EndpointStateChangeEventHandler OnEndpointStateChangeEvent;
		event DialEventHandler OnDialEvent;
		event StasisEndEventHandler OnStasisEndEvent;
		event StasisStartEventHandler OnStasisStartEvent;
		event TextMessageReceivedEventHandler OnTextMessageReceivedEvent;
		event ChannelConnectedLineEventHandler OnChannelConnectedLineEvent;
		event UnhandledEventHandler OnUnhandledEvent;
	}
}