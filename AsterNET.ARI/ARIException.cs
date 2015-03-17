using System;

namespace AsterNET.ARI
{
    /// <summary>
    ///     An excpetion within the ARI framework
    /// </summary>
    public class AriException : Exception
    {
        public AriException(string message)
            : base(message)
        {
        }
    }
}