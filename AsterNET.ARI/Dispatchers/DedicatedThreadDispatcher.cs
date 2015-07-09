using System;
using System.Collections.Concurrent;
using System.Threading;

namespace AsterNET.ARI.Dispatchers
{
    sealed class DedicatedThreadDispatcher : IDisposable
    {
        readonly BlockingCollection<Action> _eventQueue = new BlockingCollection<Action>();
        readonly CancellationTokenSource _threadCancellation = new CancellationTokenSource();

        public DedicatedThreadDispatcher()
        {
            var thread = new Thread(EventDispatcher);
            thread.Start();
        }

        public void QueueAction(Action action)
        { 
            _eventQueue.Add(action);
        }

        public void Dispose()
        {
            _threadCancellation.Cancel();
            // We can not join the thread here, because we might be called back from it 
            // and don't want to cause a deadlock. The GC will clean everything up 
            // including the CancellationTokenSource and the BlockingCollection.
        }

        void EventDispatcher()
        {
            try
            {
                var cancellationToken = _threadCancellation.Token;
                while (true)
                {
                    var action = _eventQueue.Take(cancellationToken);
                    action();
                }
            }
            catch (OperationCanceledException)
            { }
        }
    }
}