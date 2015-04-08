using System;
using AsterNET.ARI.Models;

namespace AsterNET.ARI.TestApplication
{
    internal class Program
    {
        public static AriClient ActionClient;

        private static void Main(string[] args)
        {
            try
            {
                // Create a new Ari Connection
                ActionClient = new AriClient(
                    new StasisEndpoint("192.168.3.201", 8088, "test", "test"),
                    "HelloWorld");

                // Hook into required events
                ActionClient.OnStasisStartEvent += c_OnStasisStartEvent;
                ActionClient.OnChannelDtmfReceivedEvent += ActionClientOnChannelDtmfReceivedEvent;
                ActionClient.OnConnectionStateChanged += ActionClientOnConnectionStateChanged;

                ActionClient.Connect();

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }

        private static void ActionClientOnConnectionStateChanged(object sender)
        {
            Console.WriteLine("Connection state is now {0}", ActionClient.Connected);
        }

        private static void ActionClientOnChannelDtmfReceivedEvent(object sender, ChannelDtmfReceivedEvent e)
        {
            // When DTMF received
            switch (e.Digit)
            {
                case "*":
                    ActionClient.Channels.Play(e.Channel.Id, "sound:asterisk-friend");
                    break;
                case "#":
                    ActionClient.Channels.Play(e.Channel.Id, "sound:goodbye");
                    ActionClient.Channels.Hangup(e.Channel.Id, "normal");
                    break;
                default:
                    ActionClient.Channels.Play(e.Channel.Id, string.Format("sound:digits/{0}", e.Digit));
                    break;
            }
        }

        private static void c_OnStasisStartEvent(object sender, StasisStartEvent e)
        {
            // Answer the channel
            ActionClient.Channels.Answer(e.Channel.Id);

            // Play an announcement
            ActionClient.Channels.Play(e.Channel.Id, "sound:hello-world");
        }
    }
}