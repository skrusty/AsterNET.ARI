using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Middleware.Default
{
    public class RESTActionConsumer : IActionConsumer
    {
        public RESTActionConsumer(StasisEndpoint connectionInfo)
        {
            Asterisk = new AsteriskActions(connectionInfo);
            Applications = new ApplicationsActions(connectionInfo);
            Bridges = new BridgesActions(connectionInfo);
            Channels = new ChannelsActions(connectionInfo);
            DeviceStates = new DeviceStatesActions(connectionInfo);
            Endpoints = new EndpointsActions(connectionInfo);
            Events = new EventsActions(connectionInfo);
            Playbacks = new PlaybacksActions(connectionInfo);
            Recordings = new RecordingsActions(connectionInfo);
            Sounds = new SoundsActions(connectionInfo);
        }

        #region Public Properties
        public IAsteriskActions Asterisk { get; set; }
        public IApplicationsActions Applications { get; set; }
        public IBridgesActions Bridges { get; set; }
        public IChannelsActions Channels { get; set; }
        public IDeviceStatesActions DeviceStates { get; set; }
        public IEndpointsActions Endpoints { get; set; }
        public IEventsActions Events { get; set; }
        public IPlaybacksActions Playbacks { get; set; }
        public IRecordingsActions Recordings { get; set; }
        public ISoundsActions Sounds { get; set; } 
        #endregion
    }
}
