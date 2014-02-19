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

using System.Diagnostics;
using AsterNET.ARI.Models;

namespace AsterNET.ARI.SimpleConfExample
{
    public enum ConferenceUserState
    {
        JoinConf,
        AskForName,
        RecordingName,
        InConf,
        LeaveConf
    }

    public enum ConferenceUserType
    {
        Normal,
        Admin
    }

    public class ConferenceUser
    {
        #region Private Properties

        private readonly StasisEndpoint _endPoint;
        private ConferenceUserState _state;
        private Conference _conference;

        #endregion

        #region Public Properties

        public Channel Channel;

        public ConferenceUserState State
        {
            get { return _state; }
            set
            {
                _state = value;
                Debug.Print("User {0} is now in state: {1}", Channel.Id, State);
            }
        }

        public ConferenceUserType Type { get; set; }

        public string CurrentPlaybackId { get; set; }
        public string CurrentRecodingId { get; set; }

        #endregion

        public ConferenceUser(Conference conf, Channel chan, StasisEndpoint ep, ConferenceUserType type)
        {
            _conference = conf;
            Channel = chan;
            _endPoint = ep;
            Type = type;

            // Initial State
            State = ConferenceUserState.AskForName;
            // Get user to speak name
            CurrentPlaybackId = _endPoint.Channels.Play(Channel.Id, "sound:vm-rec-name", "en", 0, 0).Id;
            RecordName();
        }

        #region Public Methods

        public void RecordName()
        {
            State = ConferenceUserState.RecordingName;
            CurrentRecodingId =
                _endPoint.Channels.Record(Channel.Id, string.Format("conftemp-{0}", Channel.Id), "wav", 6, 1, "overwrite",
                    true, "#").Name;
        }

        public void KeyPress(string digit)
        {
            // User pressed a key
            switch (digit)
            {
                case "1":
                    // Mute
                    _endPoint.Channels.Mute(Channel.Id, "in");
                    _endPoint.Channels.Play(Channel.Id, "sound:conf-muted", "en", 0, 0);
                    break;
                case "2":
                    // Unmute
                    _endPoint.Channels.Unmute(Channel.Id, "in");
                    _endPoint.Channels.Play(Channel.Id, "sound:conf-unmuted", "en", 0, 0);
                    break;
                case "3":
                    // ?
                    break;
            }
        }

        #endregion
    }
}