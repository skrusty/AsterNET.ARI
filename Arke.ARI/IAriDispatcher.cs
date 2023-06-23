using System;

namespace Arke.ARI
{
    interface IAriDispatcher : IDisposable
    {
        void QueueAction(Action action);
    }
}
