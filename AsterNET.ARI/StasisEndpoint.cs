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
        /// <param name="ssl">Use SSL/TLS for ARI connection</param>
        public StasisEndpoint(string host, int port, string username, string password, bool ssl = false)
        {
            Host = host;
            Port = port;
            Username = username;
            Password = password;
            Ssl = ssl;
        }

        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Ssl { get; set; }

        public string AriEndPoint
        {
            get {
                if (Ssl) {
                    return string.Format("{0}://{1}:{2}/ari", "https", Host, Port);
                } else {
                    return string.Format("{0}://{1}:{2}/ari", "http", Host, Port);
                }
            }
        }
    }
}