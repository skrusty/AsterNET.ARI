/*
    
    exten => 7002,1,Noop()
    same => n,Stasis(bridge_test)
    same => n,hangup()
 
 */

using AsterNET.ARI.Models;
using AsterNET.ARI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.ARI.SimpleBridge
{
    class Program
    {
        public static ARIClient client;
        public static StasisEndpoint endPoint;

        public static Bridge SimpleBridge;

        static void Main(string[] args)
        {
            try
            {
                endPoint = new StasisEndpoint("192.168.1.83", 8088, "username", "test");

                // Create a message client to receive events on
                client = endPoint.GetStasisClient("bridge_test");

                client.OnStasisStartEvent += c_OnStasisStartEvent;
                client.OnStasisEndEvent += c_OnStasisEndEvent;

                client.Connect();

                // Create simple bridge
                SimpleBridge = endPoint.Bridges.Create("mixing", Guid.NewGuid().ToString());

                // subscribe to bridge events
                endPoint.Applications.Subscribe("bridge_test", "bridge:" + SimpleBridge.Id);

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
