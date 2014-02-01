using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.ARI
{

    /// <summary>
    /// An excpetion within the ARI framework
    /// </summary>
    public class ARIException : Exception
    {
        public ARIException(string message)
            : base(message) { }
    }
}
