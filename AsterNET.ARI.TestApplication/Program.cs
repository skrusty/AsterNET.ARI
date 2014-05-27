using System;

namespace AsterNET.ARI.TestApplication
{
    class Program
    {
        public static ARIClient client;
        static void Main(string[] args)
        {
            try
            {
                client = new ARIClient(
                    new StasisEndpoint("192.168.1.67", 8088, "username", "test"), 
                    "HelloWorld");
                client.OnStasisStartEvent += c_OnStasisStartEvent;
                client.OnChannelDtmfReceivedEvent += client_OnChannelDtmfReceivedEvent;

                client.Connect();

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }

        static void client_OnChannelDtmfReceivedEvent(object sender, AsterNET.ARI.Models.ChannelDtmfReceivedEvent e)
        {
            switch (e.Digit)
            {
                case "*":
                    client.Channels.Play(e.Channel.Id, "sound:asterisk-friend", "en", 0, 0, Guid.NewGuid().ToString());
                    break;
                case "#":
                    client.Channels.Play(e.Channel.Id, "sound:goodbye", "en", 0, 0, Guid.NewGuid().ToString());
                    client.Channels.Hangup(e.Channel.Id, "normal");
                    break;
                default:
                    client.Channels.Play(e.Channel.Id, string.Format("sound:digits/{0}", e.Digit), "en", 0, 0, Guid.NewGuid().ToString());
                    break;
            }
        }

        static void c_OnStasisStartEvent(object sender, AsterNET.ARI.Models.StasisStartEvent e)
        {
            // Answer the channel
            client.Channels.Answer(e.Channel.Id);
            // Play an announcement
            client.Channels.Play(e.Channel.Id, "sound:hello-world", "en", 0, 0, Guid.NewGuid().ToString());
        }
    }
}
