using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using AsterNET.ARI;
using AsterNET.ARI.Actions;
using RestSharp;

namespace ARICodeGen
{

    /*
     *  This project is simply here for testing the output of the codegen. 
     *  Any sample or demo application code will be moved into the AsterNET.ARI.TestApplication project.
     */
    class Program
    {
        public static ARIClient client;
        public static StasisEndpoint endPoint;
        static void Main(string[] args)
        {
            try
            {
                endPoint = new StasisEndpoint("192.168.3.16", 8088, "username", "test");

                // Create a message client to receive events on
                client = endPoint.GetStasisClient("hello");

                client.OnStasisStartEvent += c_OnStasisStartEvent;
                client.OnStasisEndEvent += c_OnStasisEndEvent;
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
            Console.WriteLine("DTMF received from channel: {0}, Digit: {1}, Duration: {2}", e.Channel.Id, e.Digit, e.Duration_ms.ToString());
        }

        static void c_OnStasisEndEvent(object sender, AsterNET.ARI.Models.StasisEndEvent e)
        {
            Console.WriteLine("Stasis End Event: {0}, {1}", e.Application, e.Application);
        }

        static void c_OnStasisStartEvent(object sender, AsterNET.ARI.Models.StasisStartEvent e)
        {
            Console.WriteLine("Stasis Start Event: {0}, {1}", e.Application, e.Application);
            // Answer the channel
            endPoint.Channels.Answer(e.Channel.Id);

            // Play an announcement
            // Non-Blocking, so will instantly fall through into the next command
            // Added Wait method which listens for a Finished event for the returned playback id
            endPoint.Channels.Play(e.Channel.Id, "sound:demo-congrats", "en", 0, 0).Wait((ARIClient)sender);

            // Hangup
            endPoint.Channels.Hangup(e.Channel.Id, "normal");
        }
    }

    public class SwaggerHelper
    {
        public static string TypeConvert(string inputType)
        {
            if (inputType.Contains("["))
                return inputType.Replace("[", "<").Replace("]", ">");
            if (inputType.ToLower() == "date")
                return "DateTime";
            if (inputType.ToLower() == "boolean")
                return "bool";
            return inputType;
        }

        public static string GetSafeName(string name)
        {
            return UppercaseFirst(name);
        }

        private static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }

}
