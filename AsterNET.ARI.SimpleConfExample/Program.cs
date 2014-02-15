/*
 * MiniConf AsterNET.ARI Conference Sample
 * Copyright Ben Merrills (ben at mersontech co uk), all rights reserved.
 * https://asternetari.codeplex.com/
 * https://asternetari.codeplex.com/license
 * 
 * No Warranty. The Software is provided "as is" without warranty of any kind, either express or implied, 
 * including without limitation any implied warranties of condition, uninterrupted use, merchantability, 
 * fitness for a particular purpose, or non-infringement.
 * 
 * Extensions.conf exmaple setup
 * 
 *   exten => 7001,1,Noop()
 *   same => n,Stasis(miniconf,test)
 *   same => n,hangup()
 *   
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AsterNET.ARI.Models;

namespace AsterNET.ARI.SimpleConfExample
{
    public class AppConfig
    {
        public const string AppName = "miniconf";
    }

    internal class Program
    {
        public static ARIClient Client;
        public static StasisEndpoint EndPoint;
        public static List<Conference> Conferences;


        private static void Main(string[] args)
        {
            try
            {
                EndPoint = new StasisEndpoint("192.168.3.16", 8088, "username", "test");

                // Create a message client to receive events on
                Client = EndPoint.GetStasisClient(AppConfig.AppName);

                Conferences = new List<Conference>
                {
                    new Conference(EndPoint, Client, Guid.NewGuid(), "test")
                };

                Client.OnStasisStartEvent += c_OnStasisStartEvent;
                Client.OnStasisEndEvent += c_OnStasisEndEvent;

                Client.Connect();

                Conferences.ForEach(x =>
                {
                    if (!x.StartConference())
                        Debug.Print("Failed to start {0}.", x.ConferenceName);
                });

                Console.ReadKey();

                // TODO: Destroy all the conferences and their bridges!
                // 
                Conferences.ForEach(x => x.DestroyConference());
                Conferences = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }

        #region ARI Events

        private static void c_OnStasisEndEvent(object sender, StasisEndEvent e)
        {
            if (e.Application != AppConfig.AppName) return;

            var conf = Conferences.SingleOrDefault(x => x.ConferenceUsers.Any(c => c.Channel.Id == e.Channel.Id));
            if (conf == null) return;

            conf.RemoveUser(e.Channel);
        }

        private static void c_OnStasisStartEvent(object sender, StasisStartEvent e)
        {
            if (e.Application != AppConfig.AppName) return;
            if (e.Args.Count == 0) return;

            var confId = e.Args[0];
            var conf = Conferences.SingleOrDefault(x => x.ConferenceName == confId);
            if (conf == null) return;

            if (!conf.AddUser(e.Channel))
                EndPoint.Channels.ContinueInDialplan(e.Channel.Id, e.Channel.Dialplan.Context, e.Channel.Dialplan.Exten,
                    (int) e.Channel.Dialplan.Priority++);

            Debug.Print("Added channel {0} to {1}", e.Channel.Id, confId);
        }

        #endregion
    }

}