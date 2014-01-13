
using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;

namespace AsterNET.ARI
{
	public delegate void DeviceStateChangedEventHandler(object sender, DeviceStateChangedEvent e);
	public delegate void PlaybackStartedEventHandler(object sender, PlaybackStartedEvent e);
	public delegate void PlaybackFinishedEventHandler(object sender, PlaybackFinishedEvent e);
	public delegate void RecordingStartedEventHandler(object sender, RecordingStartedEvent e);
	public delegate void RecordingFinishedEventHandler(object sender, RecordingFinishedEvent e);
	public delegate void RecordingFailedEventHandler(object sender, RecordingFailedEvent e);
	public delegate void ApplicationReplacedEventHandler(object sender, ApplicationReplacedEvent e);
	public delegate void BridgeCreatedEventHandler(object sender, BridgeCreatedEvent e);
	public delegate void BridgeDestroyedEventHandler(object sender, BridgeDestroyedEvent e);
	public delegate void BridgeMergedEventHandler(object sender, BridgeMergedEvent e);
	public delegate void ChannelCreatedEventHandler(object sender, ChannelCreatedEvent e);
	public delegate void ChannelDestroyedEventHandler(object sender, ChannelDestroyedEvent e);
	public delegate void ChannelEnteredBridgeEventHandler(object sender, ChannelEnteredBridgeEvent e);
	public delegate void ChannelLeftBridgeEventHandler(object sender, ChannelLeftBridgeEvent e);
	public delegate void ChannelStateChangeEventHandler(object sender, ChannelStateChangeEvent e);
	public delegate void ChannelDtmfReceivedEventHandler(object sender, ChannelDtmfReceivedEvent e);
	public delegate void ChannelDialplanEventHandler(object sender, ChannelDialplanEvent e);
	public delegate void ChannelCallerIdEventHandler(object sender, ChannelCallerIdEvent e);
	public delegate void ChannelUsereventEventHandler(object sender, ChannelUsereventEvent e);
	public delegate void ChannelHangupRequestEventHandler(object sender, ChannelHangupRequestEvent e);
	public delegate void ChannelVarsetEventHandler(object sender, ChannelVarsetEvent e);
	public delegate void EndpointStateChangeEventHandler(object sender, EndpointStateChangeEvent e);
	public delegate void DialEventHandler(object sender, DialEvent e);
	public delegate void StasisEndEventHandler(object sender, StasisEndEvent e);
	public delegate void StasisStartEventHandler(object sender, StasisStartEvent e);

	/// <summary>
	/// 
	/// </summary>
	public partial class ARIClient
	{
		public event DeviceStateChangedEventHandler OnDeviceStateChangedEvent;
		public event PlaybackStartedEventHandler OnPlaybackStartedEvent;
		public event PlaybackFinishedEventHandler OnPlaybackFinishedEvent;
		public event RecordingStartedEventHandler OnRecordingStartedEvent;
		public event RecordingFinishedEventHandler OnRecordingFinishedEvent;
		public event RecordingFailedEventHandler OnRecordingFailedEvent;
		public event ApplicationReplacedEventHandler OnApplicationReplacedEvent;
		public event BridgeCreatedEventHandler OnBridgeCreatedEvent;
		public event BridgeDestroyedEventHandler OnBridgeDestroyedEvent;
		public event BridgeMergedEventHandler OnBridgeMergedEvent;
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
		public event EndpointStateChangeEventHandler OnEndpointStateChangeEvent;
		public event DialEventHandler OnDialEvent;
		public event StasisEndEventHandler OnStasisEndEvent;
		public event StasisStartEventHandler OnStasisStartEvent;
		private Dictionary<string, MessageHandler> _messageHandlers = new Dictionary<string, MessageHandler>();
		
		private void FireEvent(string eventName, object eventArgs)
		{
		
			switch(eventName) 
			{
			
			
				case "DeviceStateChanged":
					if(OnDeviceStateChangedEvent != null)
						OnDeviceStateChangedEvent.Method.Invoke(this, new object[] {this, eventArgs});
					break;
			
			
				case "PlaybackStarted":
					if(OnPlaybackStartedEvent != null)
						OnPlaybackStartedEvent.Method.Invoke(this, new object[] {this, eventArgs});
					break;
			
			
				case "PlaybackFinished":
					if(OnPlaybackFinishedEvent != null)
						OnPlaybackFinishedEvent.Method.Invoke(this, new object[] {this, eventArgs});
					break;
			
			
				case "RecordingStarted":
					if(OnRecordingStartedEvent != null)
						OnRecordingStartedEvent.Method.Invoke(this, new object[] {this, eventArgs});
					break;
			
			
				case "RecordingFinished":
					if(OnRecordingFinishedEvent != null)
						OnRecordingFinishedEvent.Method.Invoke(this, new object[] {this, eventArgs});
					break;
			
			
				case "RecordingFailed":
					if(OnRecordingFailedEvent != null)
						OnRecordingFailedEvent.Method.Invoke(this, new object[] {this, eventArgs});
					break;
			
			
				case "ApplicationReplaced":
					if(OnApplicationReplacedEvent != null)
						OnApplicationReplacedEvent.Method.Invoke(this, new object[] {this, eventArgs});
					break;
			
			
				case "BridgeCreated":
					if(OnBridgeCreatedEvent != null)
						OnBridgeCreatedEvent.Method.Invoke(this, new object[] {this, eventArgs});
					break;
			
			
				case "BridgeDestroyed":
					if(OnBridgeDestroyedEvent != null)
						OnBridgeDestroyedEvent.Method.Invoke(this, new object[] {this, eventArgs});
					break;
			
			
				case "BridgeMerged":
					if(OnBridgeMergedEvent != null)
						OnBridgeMergedEvent.Method.Invoke(this, new object[] {this, eventArgs});
					break;
			
			
				case "ChannelCreated":
					if(OnChannelCreatedEvent != null)
						OnChannelCreatedEvent.Method.Invoke(this, new object[] {this, eventArgs});
					break;
			
			
				case "ChannelDestroyed":
					if(OnChannelDestroyedEvent != null)
						OnChannelDestroyedEvent.Method.Invoke(this, new object[] {this, eventArgs});
					break;
			
			
				case "ChannelEnteredBridge":
					if(OnChannelEnteredBridgeEvent != null)
						OnChannelEnteredBridgeEvent.Method.Invoke(this, new object[] {this, eventArgs});
					break;
			
			
				case "ChannelLeftBridge":
					if(OnChannelLeftBridgeEvent != null)
						OnChannelLeftBridgeEvent.Method.Invoke(this, new object[] {this, eventArgs});
					break;
			
			
				case "ChannelStateChange":
					if(OnChannelStateChangeEvent != null)
						OnChannelStateChangeEvent.Method.Invoke(this, new object[] {this, eventArgs});
					break;
			
			
				case "ChannelDtmfReceived":
					if(OnChannelDtmfReceivedEvent != null)
						OnChannelDtmfReceivedEvent.Method.Invoke(this, new object[] {this, eventArgs});
					break;
			
			
				case "ChannelDialplan":
					if(OnChannelDialplanEvent != null)
						OnChannelDialplanEvent.Method.Invoke(this, new object[] {this, eventArgs});
					break;
			
			
				case "ChannelCallerId":
					if(OnChannelCallerIdEvent != null)
						OnChannelCallerIdEvent.Method.Invoke(this, new object[] {this, eventArgs});
					break;
			
			
				case "ChannelUserevent":
					if(OnChannelUsereventEvent != null)
						OnChannelUsereventEvent.Method.Invoke(this, new object[] {this, eventArgs});
					break;
			
			
				case "ChannelHangupRequest":
					if(OnChannelHangupRequestEvent != null)
						OnChannelHangupRequestEvent.Method.Invoke(this, new object[] {this, eventArgs});
					break;
			
			
				case "ChannelVarset":
					if(OnChannelVarsetEvent != null)
						OnChannelVarsetEvent.Method.Invoke(this, new object[] {this, eventArgs});
					break;
			
			
				case "EndpointStateChange":
					if(OnEndpointStateChangeEvent != null)
						OnEndpointStateChangeEvent.Method.Invoke(this, new object[] {this, eventArgs});
					break;
			
			
				case "Dial":
					if(OnDialEvent != null)
						OnDialEvent.Method.Invoke(this, new object[] {this, eventArgs});
					break;
			
			
				case "StasisEnd":
					if(OnStasisEndEvent != null)
						OnStasisEndEvent.Method.Invoke(this, new object[] {this, eventArgs});
					break;
			
			
				case "StasisStart":
					if(OnStasisStartEvent != null)
						OnStasisStartEvent.Method.Invoke(this, new object[] {this, eventArgs});
					break;
			}
		}
	}
}
