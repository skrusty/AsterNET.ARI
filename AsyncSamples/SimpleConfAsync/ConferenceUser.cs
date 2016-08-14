using System;
using System.Diagnostics;
using AsterNET.ARI;
using AsterNET.ARI.Models;
using System.Threading.Tasks;

namespace SimpleConfAsync
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

        private readonly AriClient _client;
        private Conference _conference;
        private ConferenceUserState _state;

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

        public ConferenceUser(Conference conf, Channel chan, AriClient client, ConferenceUserType type)
        {
            _conference = conf;
            Channel = chan;
            _client = client;
            Type = type;

            // Initial State
            State = ConferenceUserState.AskForName;
            // Get user to speak name
            var playback = _client.Channels.PlayAsync(Channel.Id, "sound:vm-rec-name", "en", 0, 0,
                Guid.NewGuid().ToString());
            playback.Wait();
            CurrentPlaybackId = 
                playback.Result.Id;
            RecordName().Wait();
        }

        #region Public Methods

        public async Task RecordName()
        {
            State = ConferenceUserState.RecordingName;
            CurrentRecodingId =
                (await _client.Channels.RecordAsync(Channel.Id, string.Format("conftemp-{0}", Channel.Id), "wav", 6, 1,
                    "overwrite",
                    true, "#")).Name;
        }

        public async Task KeyPress(string digit)
        {
            // User pressed a key
            switch (digit)
            {
                case "1":
                    // Mute
                    await _client.Channels.MuteAsync(Channel.Id, "in");
                    await _client.Channels.PlayAsync(Channel.Id, "sound:conf-muted", "en", 0, 0, Guid.NewGuid().ToString());
                    break;
                case "2":
                    // Unmute
                    await _client.Channels.UnmuteAsync(Channel.Id, "in");
                    await _client.Channels.PlayAsync(Channel.Id, "sound:conf-unmuted", "en", 0, 0, Guid.NewGuid().ToString());
                    break;
                case "3":
                    // ?
                    break;
            }
        }

        #endregion
    }
}
