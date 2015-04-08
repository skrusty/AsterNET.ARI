namespace AsterNET.ARI
{
    public class StasisEndpoint
    {
        /// <summary>
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public StasisEndpoint(string host, int port, string username, string password)
        {
            Host = host;
            Port = port;
            Username = username;
            Password = password;
        }

        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string AriEndPoint
        {
            get { return string.Format("{0}://{1}:{2}/ARI", "http", Host, Port); }
        }
    }
}