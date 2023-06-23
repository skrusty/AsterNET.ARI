using System;
using System.Diagnostics;
using Arke.ARI;
using Arke.ARI.Models;
using SimpleConfAsync.REST;
using System.Linq;
using Microsoft.Owin.Hosting;

namespace SimpleConfAsync
{
    public class AppConfig
    {
        public const string AppName = "simpleconf";
        public const string RestAddress = "http://localhost:9000/";
    }

    internal class Program
    {
        public static AriClient Client;

        static void Main(string[] args)
        {
            RunDemo();
        }

        private static void RunDemo()
        {
            try
            {
                Client = new AriClient(
                    new StasisEndpoint("127.0.0.1", 8088, "username", "test"), 
                    AppConfig.AppName);

                Conference.Conferences.Add(new Conference(Client, Guid.NewGuid(), "test"));

                Client.OnStasisStartEvent += c_OnStasisStartEvent;
                Client.OnStasisEndEvent += c_OnStasisEndEvent;

                Client.Connect();

                // Start REST
                WebApp.Start<Startup>(url: AppConfig.RestAddress);
                Console.WriteLine("Loaded...waiting for connections.");

                // Wait
                Console.ReadKey();

                // Destroy all the conferences and their bridges
                Conference.Conferences.ForEach(async x => await x.DestroyConference());
                Conference.Conferences = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }

        private static async void c_OnStasisEndEvent(object sender, StasisEndEvent e)
        {
            if (e.Application != AppConfig.AppName) return;

            var conf = Conference.Conferences.SingleOrDefault(x => x.ConferenceUsers.Any(c => c.Channel.Id == e.Channel.Id));
            if (conf == null) return;

            await conf.RemoveUser(e.Channel.Id);
        }

        private static async void c_OnStasisStartEvent(object sender, StasisStartEvent e)
        {
            if (e.Application != AppConfig.AppName) return;
            var failed = true;
            if (e.Args.Count == 0)
                await Client.Channels.SetChannelVarAsync(e.Channel.Id, "CONFEXIT", "NOTFOUND");

            var confId = e.Args[0];
            var conf = Conference.Conferences.SingleOrDefault(x => x.ConferenceName == confId);
            if (conf == null)
                await Client.Channels.SetChannelVarAsync(e.Channel.Id, "CONFEXIT", "NOTFOUND");
            else
                if (!await conf.AddUser(e.Channel))
                await Client.Channels.SetChannelVarAsync(e.Channel.Id, "CONFEXIT", "CANTJOIN");
            else
            {
                Debug.Print("Added channel {0} to {1}", e.Channel.Id, confId);
                failed = false;
            }

            if (failed)
                await Client.Channels.ContinueInDialplanAsync(e.Channel.Id,
                    e.Channel.Dialplan.Context,
                    e.Channel.Dialplan.Exten,
                    (int)e.Channel.Dialplan.Priority++);
        }
    }
}
