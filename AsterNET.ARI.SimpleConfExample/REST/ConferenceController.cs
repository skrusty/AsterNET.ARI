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
using System.Linq;
using System.Web.Http;

namespace AsterNET.ARI.SimpleConfExample.REST
{

    /*
     * Rest API
     * 
     * 
     */

    public class ConferenceController : ApiController
    {
        [HttpGet]
        public IEnumerable<Conference> Get()
        {
            return Conference.Conferences.ToList();
        }

        [HttpGet]
        public Conference Get(Guid id)
        {
            return Conference.Conferences.SingleOrDefault(x => x.Id == id);
        }

        [HttpGet]
        public void Mute(Guid id)
        {
            var conf = Conference.Conferences.SingleOrDefault(x => x.Id == id);
            if (conf == null)
                return;

            conf.MuteConference();
        }

        [HttpGet]
        public void Unmute(Guid id)
        {
            var conf = Conference.Conferences.SingleOrDefault(x => x.Id == id);
            if (conf == null)
                return;

            conf.UnMuteConference();
        }

        [HttpGet]
        public void Kick(Guid id, string channelId)
        {
            var conf = Conference.Conferences.SingleOrDefault(x => x.Id == id);
            if (conf == null)
                return;

            conf.RemoveUser(channelId);
        }

        [HttpGet]
        public void Play(Guid id, string audioFile)
        {
            var conf = Conference.Conferences.SingleOrDefault(x => x.Id == id);
            if (conf == null)
                return;

            conf.PlayFile(audioFile);
        }

        [HttpGet]
        public void StartRecord(Guid id, string audioFile)
        {
            var conf = Conference.Conferences.SingleOrDefault(x => x.Id == id);
            if (conf == null)
                return;

            conf.StartRecording(audioFile);
        }

        [HttpGet]
        public void StopRecord(Guid id, string audioFile)
        {
            var conf = Conference.Conferences.SingleOrDefault(x => x.Id == id);
            if (conf == null)
                return;

            conf.StopRecording(audioFile);
        }

        [HttpGet]
        public void StartMOH(Guid id, string mohClass)
        {
            var conf = Conference.Conferences.SingleOrDefault(x => x.Id == id);
            if (conf == null)
                return;

            conf.StartMOH(mohClass);
        }

        [HttpGet]
        public void StopMOH(Guid id)
        {
            var conf = Conference.Conferences.SingleOrDefault(x => x.Id == id);
            if (conf == null)
                return;

            conf.StopMOH();
        }

        [HttpPost]
        public Conference Post(string name)
        {
            var conf = new Conference(Program.EndPoint, Program.Client, Guid.NewGuid(), name);
            Conference.Conferences.Add(conf);

            return conf;
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            var conf = Conference.Conferences.SingleOrDefault(x => x.Id == id);
            if (conf == null)
                return;

            conf.DestroyConference();
            Conference.Conferences.Remove(conf);
        }
    }
}
