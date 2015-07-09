using System;

namespace AsterNET.ARI
{
    interface IAriDispatcher : IDisposable
    {
        void QueueAction(Action action);
    }
}
