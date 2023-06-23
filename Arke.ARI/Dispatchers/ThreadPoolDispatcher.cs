using System;
using System.Threading;

namespace Arke.ARI.Dispatchers
{
    sealed class ThreadPoolDispatcher : IAriDispatcher
    {
        public void Dispose()
        {
        }

        public void QueueAction(Action action)
        {
            ThreadPool.QueueUserWorkItem(_ => action());
        }
    }
}
