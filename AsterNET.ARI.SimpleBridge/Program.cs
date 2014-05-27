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
        public static ARIClient Client;
        public static Bridge SimpleBridge;

        private const string AppName = "bridge_test";

        static void Main(string[] args)
        {
            try
            {
                // Create a message client to receive events on
                Client = new ARIClient(new StasisEndpoint("192.168.3.16", 8088, "username", "test"), AppName);

                Client.OnStasisStartEvent += c_OnStasisStartEvent;
                Client.OnStasisEndEvent += c_OnStasisEndEvent;

                Client.Connect();

                // Create simple bridge
                SimpleBridge = Client.Bridges.Create("mixing", Guid.NewGuid().ToString(), AppName);

                // subscribe to bridge events
                Client.Applications.Subscribe(AppName, "bridge:" + SimpleBridge.Id);

                // start MOH on bridge
                Client.Bridges.StartMoh(SimpleBridge.Id, "default");

                var done = false;
                while (!done)
                {
                    var lastKey = Console.ReadKey();
                    switch(lastKey.KeyChar.ToString())
                    {
                        case "*":
                            done = true;
                            break;
                        case "1":
                            Client.Bridges.StopMoh(SimpleBridge.Id);
                            break;
                        case "2":
                            Client.Bridges.StartMoh(SimpleBridge.Id, "default");
                            break;
                        case "3":
                            // Mute all channels on bridge
                            var bridgeMute = Client.Bridges.Get(SimpleBridge.Id);
                            foreach (var chan in bridgeMute.Channels)
                                Client.Channels.Mute(chan, "in");
                            break;
                        case "4":
                            // Unmute all channels on bridge
                            var bridgeUnmute = Client.Bridges.Get(SimpleBridge.Id);
                            foreach (var chan in bridgeUnmute.Channels)
                                Client.Channels.Unmute(chan, "in");
                            break;
                    }
                }

                Client.Bridges.Destroy(SimpleBridge.Id);
                Client.Disconnect();
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
            Client.Bridges.RemoveChannel(SimpleBridge.Id, e.Channel.Id);

            // hangup
            Client.Channels.Hangup(e.Channel.Id, "normal");
        }

        static void c_OnStasisStartEvent(object sender, AsterNET.ARI.Models.StasisStartEvent e)
        {
            // answer channel
            Client.Channels.Answer(e.Channel.Id);

            // add to bridge
            Client.Bridges.AddChannel(SimpleBridge.Id, e.Channel.Id, "member");
        }
    }
}
