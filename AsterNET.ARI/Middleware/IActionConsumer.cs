using AsterNET.ARI.Actions;

namespace AsterNET.ARI.Middleware
{
    public interface IActionConsumer
    {
        IAsteriskActions Asterisk { get; set; }
        IApplicationsActions Applications { get; set; }
        IBridgesActions Bridges { get; set; }
        IChannelsActions Channels { get; set; }
        IDeviceStatesActions DeviceStates { get; set; }
        IEndpointsActions Endpoints { get; set; }
        IEventsActions Events { get; set; }
        IPlaybacksActions Playbacks { get; set; }
        IRecordingsActions Recordings { get; set; }
        ISoundsActions Sounds { get; set; }
    }
}
