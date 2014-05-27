//using AsterNET.ARI;
//using AsterNET.ARI.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ARICodeGen
//{
//    public static class SyncHelper
//    {
//        public static PlaybackFinishedEvent Wait(this Playback playback, ARIClient client)
//        {
//            AutoResetEvent _playbackFinished = new AutoResetEvent(false);
//            PlaybackFinishedEvent rtn = null;
//            client.OnPlaybackFinishedEvent += (s, e) =>
//            {
//                rtn = e;
//                _playbackFinished.Set();
//            };

//            _playbackFinished.WaitOne();
//            return rtn;
//        }
//    }
//}
