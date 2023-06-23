using System;
using Arke.ARI.Models;


namespace Arke.ARI.SimpleTestApplicationAsync
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

        private async static void ActionClientOnChannelDtmfReceivedEvent(IAriClient sender, ChannelDtmfReceivedEvent e)
        {
            // When DTMF received
            switch (e.Digit)
            {
                case "*":
                    await sender.Channels.PlayAsync(e.Channel.Id, "sound:asterisk-friend");
                    break;
                case "#":
                    await sender.Channels.PlayAsync(e.Channel.Id, "sound:goodbye");
                    await sender.Channels.HangupAsync(e.Channel.Id, "normal");
                    break;
                default:
                    await sender.Channels.PlayAsync(e.Channel.Id, string.Format("sound:digits/{0}", e.Digit));
                    break;
            }
        }

        private async static void c_OnStasisStartEvent(IAriClient sender, StasisStartEvent e)
        {
            // Answer the channel
            await sender.Channels.AnswerAsync(e.Channel.Id);

            // Play an announcement
            await sender.Channels.PlayAsync(e.Channel.Id, "sound:hello-world");
        }
    }
}
