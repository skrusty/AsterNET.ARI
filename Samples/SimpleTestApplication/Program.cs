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
                    new StasisEndpoint("10.50.10.15", 8088, "asterisk", "asterisk"),
                    "artemis");
                ActionClient.EventDispatchingStrategy = EventDispatchingStrategy.AsyncTask;

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

        private static async void ActionClientOnChannelDtmfReceivedEvent(IAriClient sender, ChannelDtmfReceivedEvent e)
        {
            // When DTMF received
            switch (e.Digit)
            {
                case "*":
                    await sender.Channels.Play(e.Channel.Id, "sound:asterisk-friend");
                    break;
                case "#":
					//await sender.Channels.PlayTask(e.Channel.Id, "sound:goodbye");
					await sender.Channels.Hangup(e.Channel.Id, "normal");
                    break;
                default:
					await sender.Channels.Play(e.Channel.Id, string.Format("sound:digits/{0}", e.Digit));
                    break;
            }
        }

        private static async void c_OnStasisStartEvent(IAriClient sender, StasisStartEvent e)
        {
			// Answer the channel
			await sender.Channels.Answer(e.Channel.Id);

			// Play an announcement
			await sender.Channels.Play(e.Channel.Id, "sound:hello-world");
        }
    }
}