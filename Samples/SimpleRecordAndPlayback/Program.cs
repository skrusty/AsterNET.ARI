﻿/*
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
        public static AriClient actionClient;
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

                // Create a message actionClient to receive events on
                actionClient = new AriClient(endPoint, "playrec_test");

                actionClient.OnStasisStartEvent += c_OnStasisStartEvent;
                actionClient.OnStasisEndEvent += c_OnStasisEndEvent;
                actionClient.OnRecordingFinishedEvent += ActionClientOnRecordingFinishedEvent;

                actionClient.Connect();

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

                actionClient.Disconnect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }

        static async void GetRecording(Channel c)
        {
            var playback = await actionClient.Channels.Play(c.Id, "sound:vm-rec-name", "en", 0, 0, Guid.NewGuid().ToString());
            recording = new RecordingToChannel()
            {
                Recording = await actionClient.Channels.Record(c.Id, "temp-recording", "wav", 6, 1, "overwrite", true, "#"),
                Channel = c
            };
        }

        static void PlaybackRecording(Channel c)
        {
            var repeat = actionClient.Channels.Play(c.Id, "recording:temp-recording", "en", 0, 0, Guid.NewGuid().ToString()).Id;
        }

        static void ActionClientOnRecordingFinishedEvent(object sender, AsterNET.ARI.Models.RecordingFinishedEvent e)
        {
            if (e.Recording.Name != recording.Recording.Name) return;

            PlaybackRecording(recording.Channel);

            GetRecording(recording.Channel);
        }

        static async void c_OnStasisEndEvent(object sender, AsterNET.ARI.Models.StasisEndEvent e)
        {
            // Delete recording
            await actionClient.Recordings.DeleteStored("temp-recording");

            // hangup
            await actionClient.Channels.Hangup(e.Channel.Id, "normal");
        }

        static async void c_OnStasisStartEvent(object sender, AsterNET.ARI.Models.StasisStartEvent e)
        {
            // answer channel
            await actionClient.Channels.Answer(e.Channel.Id);

            GetRecording(e.Channel);
        }
    }
}
