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
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AsterNET.ARI.SimpleConfExample.REST
{
    [EnableCors(origins: "http://localhost:9000", headers: "*", methods: "*")]
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
        public HttpResponseMessage Mute(Guid id)
        {
            var conf = Conference.Conferences.SingleOrDefault(x => x.Id == id);
            if (conf == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            conf.MuteConference();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        public HttpResponseMessage Unmute(Guid id)
        {
            var conf = Conference.Conferences.SingleOrDefault(x => x.Id == id);
            if (conf == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            conf.UnMuteConference();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        public HttpResponseMessage Kick(Guid id, string channelId)
        {
            var conf = Conference.Conferences.SingleOrDefault(x => x.Id == id);
            if (conf == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            conf.RemoveUser(channelId);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        public HttpResponseMessage Play(Guid id, string audioFile)
        {
            var conf = Conference.Conferences.SingleOrDefault(x => x.Id == id);
            if (conf == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            conf.PlayFile(audioFile);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        public HttpResponseMessage StartRecord(Guid id, string audioFile)
        {
            var conf = Conference.Conferences.SingleOrDefault(x => x.Id == id);
            if (conf == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            conf.StartRecording(audioFile);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        public HttpResponseMessage StopRecord(Guid id, string audioFile)
        {
            var conf = Conference.Conferences.SingleOrDefault(x => x.Id == id);
            if (conf == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            conf.StopRecording(audioFile);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        public HttpResponseMessage StartMOH(Guid id, string mohClass)
        {
            var conf = Conference.Conferences.SingleOrDefault(x => x.Id == id);
            if (conf == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            conf.StartMOH(mohClass);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        public HttpResponseMessage StopMOH(Guid id)
        {
            var conf = Conference.Conferences.SingleOrDefault(x => x.Id == id);
            if (conf == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            conf.StopMOH();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        public Conference Post(string name)
        {
            var conf = new Conference(Program.Client, Guid.NewGuid(), name);
            Conference.Conferences.Add(conf);

            return conf;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            var conf = Conference.Conferences.SingleOrDefault(x => x.Id == id);
            if (conf == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            conf.DestroyConference();
            Conference.Conferences.Remove(conf);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
