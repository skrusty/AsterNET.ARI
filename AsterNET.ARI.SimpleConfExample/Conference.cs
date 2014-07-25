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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AsterNET.ARI.Models;

namespace AsterNET.ARI.SimpleConfExample
{
    public enum ConferenceState
    {
        Destroyed = -1, // Conference no longer valid
        Destroying = 0, // conf not ready, destroying bridge
        Creating = 1, // conf not ready, creating bridge
        Ready = 2, // Conf bridge is ready to accept channels
        ReadyWaiting = 3, // Conf is ready but playing MOH until members join, or admin joins (todo)
        Muted = 4, // no one can speak (check if MOH should be played)
        AdminMuted = 5 // only the admins can speak
    }

    public class Conference
    {
        public static List<Conference> Conferences = new List<Conference>();

        #region Private Properties

        private ARIClient _client;
        private ConferenceState _state;

        #endregion

        #region Public Properties

        public Bridge Confbridge;
        public string ConferenceName;

        public List<ConferenceUser> ConferenceUsers = new List<ConferenceUser>();
        public Guid Id;

        public ConferenceState State
        {
            get { return _state; }
            set
            {
                _state = value;
                Debug.Print("Conference {0} is now in state: {1}", ConferenceName, State);
            }
        }

        #endregion

        public Conference( ARIClient c, Guid id, string name)
        {
            _client = c;
            Id = id;
            ConferenceName = name;
            State = ConferenceState.Destroyed;

            c.OnChannelDtmfReceivedEvent += c_OnChannelDtmfReceivedEvent;
            c.OnBridgeCreatedEvent += c_OnBridgeCreatedEvent;
            c.OnChannelEnteredBridgeEvent += c_OnChannelEnteredBridgeEvent;
            c.OnBridgeDestroyedEvent += c_OnBridgeDestroyedEvent;
            c.OnChannelLeftBridgeEvent += c_OnChannelLeftBridgeEvent;
            c.OnRecordingFinishedEvent += c_OnRecordingFinishedEvent;

            // Added support for talk detection
            c.OnChannelTalkingStartedEvent += c_OnChannelTalkingStartedEvent;
            c.OnChannelTalkingFinishedEvent += c_OnChannelTalkingFinishedEvent;

            Debug.Print("Added Conference {0}", ConferenceName);
        }

        void c_OnChannelTalkingFinishedEvent(object sender, ChannelTalkingFinishedEvent e)
        {
            ConferenceUser confUser = ConferenceUsers.SingleOrDefault(x => x.Channel.Id == e.Channel.Id);
            Console.WriteLine("{0} Finished talking in conference {1}, lasted {2} milliseconds", e.Channel.Id, this.ConferenceName, e.Duration);
        }

        void c_OnChannelTalkingStartedEvent(object sender, ChannelTalkingStartedEvent e)
        {
            ConferenceUser confUser = ConferenceUsers.SingleOrDefault(x => x.Channel.Id == e.Channel.Id);
            Console.WriteLine("{0} Started to talk in conference {1}", e.Channel.Id, this.ConferenceName);
        }

        #region ARI Events

        private void c_OnRecordingFinishedEvent(object sender, RecordingFinishedEvent e)
        {
            // Find out if this recording was for a conf user who's state is currently
            // RecordingName
            var confUser = ConferenceUsers.SingleOrDefault(x => x.CurrentRecodingId == e.Recording.Name);
            if (confUser == null) return;
            if (confUser.State != ConferenceUserState.RecordingName) return;

            confUser.State = ConferenceUserState.JoinConf;
            // Join the chanel to the bridge
            _client.Bridges.AddChannel(Confbridge.Id, confUser.Channel.Id, "ConfUser");
        }

        private void c_OnChannelLeftBridgeEvent(object sender, ChannelLeftBridgeEvent e)
        {
            // left conf
            // play announcement
            _client.Bridges.Play(Confbridge.Id, "recording:" + string.Format("conftemp-{0}", e.Channel.Id), "en", 0, 0, Guid.NewGuid().ToString());
            _client.Bridges.Play(Confbridge.Id, "sound:conf-hasleft", "en", 0, 0, Guid.NewGuid().ToString());

            // If only 1 person left, then play MOH
            // TODO: Make it here so if the admin has left, and admin count = 0, then also play MOH
            if (ConferenceUsers.Count() <= 1)
                _client.Bridges.StartMoh(Confbridge.Id, "default");

            // If empty, destroy the conference
            if (!ConferenceUsers.Any())
                DestroyConference();

            _client.Recordings.DeleteStored(string.Format("conftemp-{0}", e.Channel));
        }

        private void c_OnBridgeDestroyedEvent(object sender, BridgeDestroyedEvent e)
        {
            if (e.Bridge.Id == Id.ToString())
                State = ConferenceState.Destroyed;
        }

        private void c_OnChannelEnteredBridgeEvent(object sender, ChannelEnteredBridgeEvent e)
        {
            ConferenceUser confUser = ConferenceUsers.SingleOrDefault(x => x.Channel.Id == e.Channel.Id);
            if (confUser == null) return;

            confUser.State = ConferenceUserState.InConf;

            if (ConferenceUsers.Count(x => x.State == ConferenceUserState.InConf) > 1) // are we the only ones here
            {
                // stop moh
                _client.Bridges.StopMoh(Confbridge.Id);

                // change state
                State = ConferenceState.Ready;

                // announce new user
                _client.Bridges.Play(Confbridge.Id, "recording:" + confUser.CurrentRecodingId, "en", 0, 0, Guid.NewGuid().ToString());
                _client.Bridges.Play(Confbridge.Id, "sound:conf-hasjoin", "en", 0, 0, Guid.NewGuid().ToString());
            }
            else
            {
                // only caller in conf
                _client.Channels.Play(e.Channel.Id, "sound:conf-onlyperson", "en", 0, 0, Guid.NewGuid().ToString());
            }
        }

        private void c_OnBridgeCreatedEvent(object sender, BridgeCreatedEvent e)
        {
            // Never gets fired!
            if (e.Bridge.Id != Id.ToString()) return;

            State = ConferenceState.Ready;
            Debug.Print("Created bridge {0} for {1}", Id, ConferenceName);
        }

        private void c_OnChannelDtmfReceivedEvent(object sender, ChannelDtmfReceivedEvent e)
        {
            ConferenceUser confUser = ConferenceUsers.SingleOrDefault(x => x.Channel.Id == e.Channel.Id);
            if (confUser == null) return;

            // Pass digit to conference user
            confUser.KeyPress(e.Digit);
        }

        #endregion

        #region Public Methods

        public bool StartConference()
        {
            // TODO: fix this, .Connected returning false all the time
            //if (!client.Connected)
            //    return false;

            // Create the conference bridge
            Debug.Print("Requesting new bridge {0} for {1}", Id, ConferenceName);
            Bridge bridge = _client.Bridges.Create("mixing", Id.ToString(), ConferenceName);

            if (bridge == null)
            {
                return false;
            }


            Debug.Print("Subscribing to events on bridge {0} for {1}", Id, ConferenceName);
            _client.Applications.Subscribe(AppConfig.AppName, "bridge:" + bridge.Id);

            // Start MOH on conf bridge
            _client.Bridges.StartMoh(bridge.Id, "default");

            // Default state is ReadyWaiting until MOH is turned off
            State = ConferenceState.ReadyWaiting;
            Confbridge = bridge;

            // Conference ready to accept calls
            State = ConferenceState.Ready;

            return true;
        }

        public bool AddUser(Channel c)
        {
            if (State == ConferenceState.Destroying)
                return false;
            if (State == ConferenceState.Destroyed)
            {
                // We should initiate a new conference bridge
                if (!StartConference())
                    return false;
            }
            if (State < ConferenceState.Ready) return false;

            // Answer channel
            _client.Channels.Answer(c.Id);

            // Turn on talk detection on this channel
            _client.Channels.SetChannelVar(c.Id, "TALK_DETECT(set)", "");

            // Add conference user to collection
            ConferenceUsers.Add(new ConferenceUser(this, c, _client, ConferenceUserType.Normal));

            return true;
        }

        public void RemoveUser(string channelId)
        {
            // Remove the channel from the bridge
            ConferenceUser confUser = ConferenceUsers.SingleOrDefault(x => x.Channel.Id == channelId);
            if (confUser == null) return;

            _client.Bridges.RemoveChannel(Confbridge.Id, channelId);
            ConferenceUsers.Remove(confUser);
        }

        public void PlayFile(string fileName)
        {
            _client.Bridges.Play(Confbridge.Id, string.Format("sound:{0}", fileName), "en", 0, 0, Guid.NewGuid().ToString());
        }

        public void StartRecording(string fileName)
        {
            _client.Bridges.Record(Confbridge.Id, fileName, "wav", 0, 0, "fail", false, "none");
        }

        public void StopRecording(string fileName)
        {
            _client.Recordings.Stop(fileName);
        }

        public void MuteConference()
        {
            // TODO: Implement filter here to allow mute of non-admins etc
            foreach (ConferenceUser user in ConferenceUsers)
                _client.Channels.Mute(user.Channel.Id, "in");
        }

        public void UnMuteConference()
        {
            foreach (ConferenceUser user in ConferenceUsers)
                _client.Channels.Unmute(user.Channel.Id, "in");
        }

        public void StartMOH(string mohClass)
        {
            _client.Bridges.StartMoh(Confbridge.Id, mohClass);
        }

        public void StopMOH()
        {
            _client.Bridges.StopMoh(Confbridge.Id);
        }

        public void DestroyConference()
        {
            State = ConferenceState.Destroying;

            ConferenceUsers.ForEach(x => RemoveUser(x.Channel.Id));
            if (Confbridge != null)
                _client.Bridges.Destroy(Confbridge.Id);
            Confbridge = null;

            State = ConferenceState.Destroyed;
        }

        #endregion
    }
}