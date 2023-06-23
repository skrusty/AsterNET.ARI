using System;

namespace Arke.ARI
{
    /// <summary>
    ///     An excpetion within the ARI framework
    /// </summary>
    public class AriException : Exception
    {

        public int StatusCode { get; set; }

        public AriException(string message)
            : base(message)
        {
        }

        public AriException(string message, int statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}