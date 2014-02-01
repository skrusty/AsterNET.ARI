using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsterNET.ARI.Actions;

namespace AsterNET.ARI
{
    public class StasisEndpoint
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public AsteriskActions Asterisk {get;set;}
        public ApplicationsActions Applications {get;set;}
        public BridgesActions Bridges {get;set;}
        public ChannelsActions Channels {get;set;}
        public DeviceStatesActions DeviceStates {get;set;}
        public EndpointsActions Endpoints {get;set;}
        public EventsActions Events {get;set;}
        public PlaybacksActions Playbacks {get;set;}
        public RecordingsActions Recordings {get;set;}
        public SoundsActions Sounds {get;set;}

        public string ARIEndPoint
        {
            get
            {
                return string.Format("{0}://{1}:{2}/ARI", "http", Host, Port.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public StasisEndpoint(string host, int port, string username, string password)
        {
            this.Host = host;
            this.Port = port;
            this.Username = username;
            this.Password = password;

            Asterisk = new AsteriskActions(this);
            Applications = new ApplicationsActions(this);
            Bridges = new BridgesActions(this);
            Channels = new ChannelsActions(this);
            Endpoints = new EndpointsActions(this);
            Events = new EventsActions(this);
            Playbacks = new PlaybacksActions(this);
            Recordings = new RecordingsActions(this);
            Sounds = new SoundsActions(this);
        }

        public ARIClient GetStasisClient(string application)
        {
            return new ARIClient(this, application);
        }

    }
}
