using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using WebSocket4Net;

namespace AsterNET.ARI.TestApplication
{
    class Program
    {
        public static ARIClient client;
        public static StasisEndpoint endPoint;
        static void Main(string[] args)
        {
            try
            {
                endPoint = new StasisEndpoint("192.168.1.67", 8088, "username", "test");
                client = endPoint.GetStasisClient("hello");
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
                    endPoint.Channels.Play(e.Channel.Id, "sound:asterisk-friend", "en", 0, 0);
                    break;
                case "#":
                    endPoint.Channels.Play(e.Channel.Id, "sound:goodbye", "en", 0, 0);
                    endPoint.Channels.Hangup(e.Channel.Id, "normal");
                    break;
                default:
                    endPoint.Channels.Play(e.Channel.Id, string.Format("sound:digits/{0}", e.Digit), "en", 0, 0);
                    break;
            }
        }

        static void c_OnStasisStartEvent(object sender, AsterNET.ARI.Models.StasisStartEvent e)
        {
            // Answer the channel
            endPoint.Channels.Answer(e.Channel.Id);
            // Play an announcement
            endPoint.Channels.Play(e.Channel.Id, "sound:hello-world", "en", 0, 0);
        }
    }
}
