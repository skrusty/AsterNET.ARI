/*
 * RecordPlayback AsterNET.ARI Audio Sample
 * Copyright Ben Merrills (ben at mersontech co uk), all rights reserved.
 * https://asternetari.codeplex.com/
 * https://asternetari.codeplex.com/license
 * 
 * No Warranty. The Software is provided "as is" without warranty of any kind, either express or implied, 
 * including without limitation any implied warranties of condition, uninterrupted use, merchantability, 
 * fitness for a particular purpose, or non-infringement.
 * 
 * Extensions.conf exmaple setup
 *   exten => 7003,1,Noop()
 *   same => n,Stasis(playrec_test)
 *   same => n,hangup()
 */

using AsterNET.ARI;
using AsterNET.ARI.Models;
using System;

namespace Sample_RecordAndPlayback
{

    /*
     * This simple example shows how to queue a playback, initiate a recording
     * and then play back that recording when it's been completed.
     *  
     * This example doesn't allow multiple calls, and is pretty much useless for
     * anything else than showing how to use Play and Record.
     * 
     * Once the recording has been played back, the process starts again.
     * 
     * The recording will wait for a '#' digit, 1 second of silence or cut off 
     * after 6 seconds of recording.
     */

    class Program
    {
        public static ARIClient client;
        public static StasisEndpoint endPoint;

        public static RecordingToChannel recording;

        public class RecordingToChannel
        {
            public LiveRecording Recording { get; set; }
            public Channel Channel { get; set; }
        }

        static void Main(string[] args)
        {
            try
            {
                endPoint = new StasisEndpoint("ipaddress", 8088, "username", "password");

                // Create a message client to receive events on
                client = endPoint.GetStasisClient("playrec_test");

                client.OnStasisStartEvent += c_OnStasisStartEvent;
                client.OnStasisEndEvent += c_OnStasisEndEvent;
                client.OnRecordingFinishedEvent += client_OnRecordingFinishedEvent;

                client.Connect();

                bool done = false;
                while (!done)
                {
                    var lastKey = Console.ReadKey();
                    switch (lastKey.KeyChar.ToString())
                    {
                        case "*":
                            done = true;
                            break;
                    }
                }

                client.Disconnect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }

        static void GetRecording(Channel c)
        {
            var playback = endPoint.Channels.Play(c.Id, "sound:vm-rec-name", "en", 0, 0).Id;
            recording = new RecordingToChannel()
            {
                Recording = endPoint.Channels.Record(c.Id, "temp-recording", "wav", 6, 1, "overwrite", true, "#"),
                Channel = c
            };
        }

        static void PlaybackRecording(Channel c)
        {
            var repeat = endPoint.Channels.Play(c.Id, "recording:temp-recording", "en", 0, 0).Id;
        }

        static void client_OnRecordingFinishedEvent(object sender, AsterNET.ARI.Models.RecordingFinishedEvent e)
        {
            if (e.Recording.Name != recording.Recording.Name) return;

            PlaybackRecording(recording.Channel);

            GetRecording(recording.Channel);
        }

        static void c_OnStasisEndEvent(object sender, AsterNET.ARI.Models.StasisEndEvent e)
        {
            // Delete recording
            endPoint.Recordings.DeleteStored("temp-recording");

            // hangup
            endPoint.Channels.Hangup(e.Channel.Id, "normal");
        }

        static void c_OnStasisStartEvent(object sender, AsterNET.ARI.Models.StasisStartEvent e)
        {
            // answer channel
            endPoint.Channels.Answer(e.Channel.Id);

            GetRecording(e.Channel);
        }
    }
}
