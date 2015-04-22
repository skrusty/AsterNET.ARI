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
        public static AriClient ActionClient;
        public static Bridge SimpleBridge;

        private const string AppName = "bridge_test";

        static void Main(string[] args)
        {
            try
            {
                // Create a message actionClient to receive events on
                ActionClient = new AriClient(new StasisEndpoint("192.168.3.16", 8088, "username", "test"), AppName);

                ActionClient.OnStasisStartEvent += c_OnStasisStartEvent;
                ActionClient.OnStasisEndEvent += c_OnStasisEndEvent;

                ActionClient.Connect();

                // Create simple bridge
                SimpleBridge = ActionClient.Bridges.Create("mixing", Guid.NewGuid().ToString(), AppName);

                // subscribe to bridge events
                ActionClient.Applications.Subscribe(AppName, "bridge:" + SimpleBridge.Id);

                // start MOH on bridge
                ActionClient.Bridges.StartMoh(SimpleBridge.Id, "default");

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
                            ActionClient.Bridges.StopMoh(SimpleBridge.Id);
                            break;
                        case "2":
                            ActionClient.Bridges.StartMoh(SimpleBridge.Id, "default");
                            break;
                        case "3":
                            // Mute all channels on bridge
                            var bridgeMute = ActionClient.Bridges.Get(SimpleBridge.Id);
                            foreach (var chan in bridgeMute.Channels)
                                ActionClient.Channels.Mute(chan, "in");
                            break;
                        case "4":
                            // Unmute all channels on bridge
                            var bridgeUnmute = ActionClient.Bridges.Get(SimpleBridge.Id);
                            foreach (var chan in bridgeUnmute.Channels)
                                ActionClient.Channels.Unmute(chan, "in");
                            break;
                    }
                }

                ActionClient.Bridges.Destroy(SimpleBridge.Id);
                ActionClient.Disconnect();
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
            ActionClient.Bridges.RemoveChannel(SimpleBridge.Id, e.Channel.Id);

            // hangup
            ActionClient.Channels.Hangup(e.Channel.Id, "normal");
        }

        static void c_OnStasisStartEvent(object sender, AsterNET.ARI.Models.StasisStartEvent e)
        {
            // answer channel
            ActionClient.Channels.Answer(e.Channel.Id);

            // add to bridge
            ActionClient.Bridges.AddChannel(SimpleBridge.Id, e.Channel.Id, "member");
        }
    }
}
