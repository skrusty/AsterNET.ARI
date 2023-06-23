using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SimpleConfAsync.REST
{
    public class ConferenceController : ControllerBase
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
        public async Task<HttpResponseMessage> Mute(Guid id)
        {
            var conf = Conference.Conferences.SingleOrDefault(x => x.Id == id);
            if (conf == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            await conf.MuteConference();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Unmute(Guid id)
        {
            var conf = Conference.Conferences.SingleOrDefault(x => x.Id == id);
            if (conf == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            await conf.UnMuteConference();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Kick(Guid id, string channelId)
        {
            var conf = Conference.Conferences.SingleOrDefault(x => x.Id == id);
            if (conf == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            await conf.RemoveUser(channelId);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Play(Guid id, string audioFile)
        {
            var conf = Conference.Conferences.SingleOrDefault(x => x.Id == id);
            if (conf == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            await conf.PlayFile(audioFile);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> StartRecord(Guid id, string audioFile)
        {
            var conf = Conference.Conferences.SingleOrDefault(x => x.Id == id);
            if (conf == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            await conf.StartRecording(audioFile);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> StopRecord(Guid id, string audioFile)
        {
            var conf = Conference.Conferences.SingleOrDefault(x => x.Id == id);
            if (conf == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            await conf.StopRecording(audioFile);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> StartMOH(Guid id, string mohClass)
        {
            var conf = Conference.Conferences.SingleOrDefault(x => x.Id == id);
            if (conf == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            await conf.StartMOH(mohClass);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> StopMOH(Guid id)
        {
            var conf = Conference.Conferences.SingleOrDefault(x => x.Id == id);
            if (conf == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            await conf.StopMOH();
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
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            var conf = Conference.Conferences.SingleOrDefault(x => x.Id == id);
            if (conf == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            await conf.DestroyConference();
            Conference.Conferences.Remove(conf);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
