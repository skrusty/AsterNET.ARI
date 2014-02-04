/*
 * SimpleBridge AsterNET.ARI Bridge Sample
 * Copyright Ben Merrills (ben at mersontech co uk), all rights reserved.
 * https://asternetari.codeplex.com/
 * https://asternetari.codeplex.com/license
 * 
 * No Warranty. The Software is provided "as is" without warranty of any kind, either express or implied, 
 * including without limitation any implied warranties of condition, uninterrupted use, merchantability, 
 * fitness for a particular purpose, or non-infringement.
 * 
 * Extensions.conf exmaple setup
 *   exten => 7002,1,Noop()
 *   same => n,Stasis(bridge_test)
 *   same => n,hangup()
 *
 */

using AsterNET.ARI.Models;
using System;

namespace AsterNET.ARI.SimpleBridge
{
    class Program
    {
        public static ARIClient client;
        public static StasisEndpoint endPoint;
        public static Bridge SimpleBridge;

        private const string AppName = "bridge_test";

        static void Main(string[] args)
        {
            try
            {
                endPoint = new StasisEndpoint("192.168.3.16", 8088, "username", "test");

                // Create a message client to receive events on
                client = endPoint.GetStasisClient(AppName);

                client.OnStasisStartEvent += c_OnStasisStartEvent;
                client.OnStasisEndEvent += c_OnStasisEndEvent;

                client.Connect();

                // Create simple bridge
                SimpleBridge = endPoint.Bridges.Create("mixing", Guid.NewGuid().ToString());

                // subscribe to bridge events
                endPoint.Applications.Subscribe(AppName, "bridge:" + SimpleBridge.Id);

                // start MOH on bridge
                endPoint.Bridges.StartMoh(SimpleBridge.Id, "default");

                bool done = false;
                while (!done)
                {
                    var lastKey = Console.ReadKey();
                    switch(lastKey.KeyChar.ToString())
                    {
                        case "*":
                            done = true;
                            break;
                        case "1":
                            endPoint.Bridges.StopMoh(SimpleBridge.Id);
                            break;
                        case "2":
                            endPoint.Bridges.StartMoh(SimpleBridge.Id, "default");
                            break;
                        case "3":
                            // Mute all channels on bridge
                            var bridgeMute = endPoint.Bridges.Get(SimpleBridge.Id);
                            foreach (var chan in bridgeMute.Channels)
                                endPoint.Channels.Mute(chan, "in");
                            break;
                        case "4":
                            // Unmute all channels on bridge
                            var bridgeUnmute = endPoint.Bridges.Get(SimpleBridge.Id);
                            foreach (var chan in bridgeUnmute.Channels)
                                endPoint.Channels.Unmute(chan, "in");
                            break;
                    }
                }

                endPoint.Bridges.Destroy(SimpleBridge.Id);
                client.Disconnect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }

        static void c_OnStasisEndEvent(object sender, AsterNET.ARI.Models.StasisEndEvent e)
        {
            // remove from bridge
            endPoint.Bridges.RemoveChannel(SimpleBridge.Id, e.Channel.Id);

            // hangup
            endPoint.Channels.Hangup(e.Channel.Id, "normal");
        }

        static void c_OnStasisStartEvent(object sender, AsterNET.ARI.Models.StasisStartEvent e)
        {
            // answer channel
            endPoint.Channels.Answer(e.Channel.Id);

            // add to bridge
            endPoint.Bridges.AddChannel(SimpleBridge.Id, e.Channel.Id, "member");
        }
    }
}
