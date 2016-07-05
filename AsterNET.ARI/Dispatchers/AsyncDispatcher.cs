using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.ARI.Dispatchers
{
    sealed class AsyncDispatcher : IAriDispatcher
    {
        public void Dispose()
        {

        }

        public async void QueueAction(Action action)
        {
            await Task.Run(action);
        }
    }
}
