using AsterNET.ARI.Models;
using System.Threading;
using AsterNET.ARI;

namespace SimpleConfAsync.Helpers
{
    public static class SyncHelper
    {
        public static PlaybackFinishedEvent Wait(this Playback playback, AriClient client)
        {
            AutoResetEvent _playbackFinished = new AutoResetEvent(false);
            PlaybackFinishedEvent rtn = null;
            client.OnPlaybackFinishedEvent += (s, e) =>
            {
                rtn = e;
                _playbackFinished.Set();
            };

            _playbackFinished.WaitOne();
            return rtn;
        }
    }
}
