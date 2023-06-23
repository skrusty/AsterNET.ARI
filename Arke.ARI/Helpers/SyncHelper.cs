using System.Threading;
using Arke.ARI.Models;

namespace Arke.ARI.Helpers
{
    public static class SyncHelper
    {
        public static PlaybackFinishedEvent Wait(this Playback playback, IAriEventClient client)
        {
            var playbackFinished = new AutoResetEvent(false);
            PlaybackFinishedEvent rtn = null;
            client.OnPlaybackFinishedEvent += (s, e) =>
            {
                rtn = e;
                playbackFinished.Set();
            };

            playbackFinished.WaitOne();
            return rtn;
        }
    }
}