using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace ARICodeGen
{
    public class ARIBaseAction
    {
        protected RestClient Client;

        public ARIBaseAction(StasisEndpoint endPoint)
        {
            this.Client = new RestClient(endPoint.URI);
        }

    }
}
