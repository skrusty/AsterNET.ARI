using Arke.ARI;
using System;
using System.IO;
using System.Linq;

namespace RecordingSample
{
    class Program
    {
        public static AriClient ActionClient;

        private static void Main(string[] args)
        {
            try
            {
                // Create a new Ari Connection
                ActionClient = new AriClient(
                    new StasisEndpoint("127.0.0.1", 8088, "username", "test"),
                    "HelloWorld");

                ActionClient.Connect();
                
                // List Recordings
                var recordings = ActionClient.Recordings.ListStored();
                recordings.ForEach(x => Console.WriteLine($"Recording Name: {x.Name}, {x.Format}"));

                // Download the first Recording
                var recording = recordings.First();
                Console.WriteLine($"Downloading recording {recording.Name}");
                using (var file = File.Create(Path.GetTempFileName()))
                {
                    var buffer = ActionClient.Recordings.GetStoredFile(recording.Name);
                    file.Write(buffer,0, buffer.Length);

                    file.Flush();
                }

                Console.WriteLine("Press any key to close...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }
    }
}
