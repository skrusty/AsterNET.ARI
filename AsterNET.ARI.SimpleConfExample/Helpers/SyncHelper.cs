/*
 * SimpleConf AsterNET.ARI Conference Sample
 * Copyright Ben Merrills (ben at mersontech co uk), all rights reserved.
 * https://asternetari.codeplex.com/
 * https://asternetari.codeplex.com/license
 * 
 * No Warranty. The Software is provided "as is" without warranty of any kind, either express or implied, 
 * including without limitation any implied warranties of condition, uninterrupted use, merchantability, 
 * fitness for a particular purpose, or non-infringement.
 *   
 */

using AsterNET.ARI.Models;
using System.Threading;

namespace AsterNET.ARI.SimpleConfExample.Helpers
{
    public static class SyncHelper
    {
        public static PlaybackFinishedEvent Wait(this Playback playback, ARIClient client)
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
