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
 *   same => n,Stasis(simpleconf,test)
 *   same => n,hangup()
 *   
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AsterNET.ARI.Models;
using AsterNET.ARI.SimpleConfExample.REST;
using Microsoft.Owin.Hosting;

namespace AsterNET.ARI.SimpleConfExample
{
    public class AppConfig
    {
        public const string AppName = "simpleconf";
        public const string RestAddress = "http://localhost:9000/"; 
    }

    internal class Program
    {
        public static ARIClient Client;
        public static StasisEndpoint EndPoint;

        private static void Main(string[] args)
        {
            try
            {
                EndPoint = new StasisEndpoint("192.168.1.75", 8088, "username", "test");

                // Create a message client to receive events on
                Client = EndPoint.GetStasisClient(AppConfig.AppName);


                Conference.Conferences.Add(new Conference(EndPoint, Client, Guid.NewGuid(), "test"));
                
                Client.OnStasisStartEvent += c_OnStasisStartEvent;
                Client.OnStasisEndEvent += c_OnStasisEndEvent;

                Client.Connect();

                // Start REST
                WebApp.Start<Startup>(url: AppConfig.RestAddress);

                // Wait
                Console.ReadKey();

                // TODO: Destroy all the conferences and their bridges!
                // 
                Conference.Conferences.ForEach(x => x.DestroyConference());
                Conference.Conferences = null;
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

            var conf = Conference.Conferences.SingleOrDefault(x => x.ConferenceUsers.Any(c => c.Channel.Id == e.Channel.Id));
            if (conf == null) return;

            conf.RemoveUser(e.Channel.Id);
        }

        private static void c_OnStasisStartEvent(object sender, StasisStartEvent e)
        {
            if (e.Application != AppConfig.AppName) return;
            var failed = true;
            if (e.Args.Count == 0)
                EndPoint.Channels.SetChannelVar(e.Channel.Id, "CONFEXIT", "NOTFOUND");

            var confId = e.Args[0];
            var conf = Conference.Conferences.SingleOrDefault(x => x.ConferenceName == confId);
            if (conf == null)
                EndPoint.Channels.SetChannelVar(e.Channel.Id, "CONFEXIT", "NOTFOUND");
            else
                if (!conf.AddUser(e.Channel))
                    EndPoint.Channels.SetChannelVar(e.Channel.Id, "CONFEXIT", "CANTJOIN");
                else
                {
                    Debug.Print("Added channel {0} to {1}", e.Channel.Id, confId);
                    failed = false;
                }

            if(failed)
                EndPoint.Channels.ContinueInDialplan(e.Channel.Id,
                    e.Channel.Dialplan.Context,
                    e.Channel.Dialplan.Exten,
                    (int)e.Channel.Dialplan.Priority++);
        }

        #endregion
    }

}