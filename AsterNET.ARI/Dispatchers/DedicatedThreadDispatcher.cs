using System;
using System.Collections.Concurrent;
using System.Threading;

namespace AsterNET.ARI.Dispatchers
{
    // This dispatcher uses a dedicated thread to dispatch ARI events, so that their order is preserved and
    // the event handlers are not called from different threads at the same time.

    sealed class DedicatedThreadDispatcher : IAriDispatcher
    {
        readonly BlockingCollection<Action> _eventQueue = new BlockingCollection<Action>();
        readonly CancellationTokenSource _threadCancellation = new CancellationTokenSource();

        public DedicatedThreadDispatcher()
        {
            // copy the variables the thread needs on the stack, so we don't capture 'this'
            // into the thread and so would prevent the finalizer from running.
            var cancellationToken = _threadCancellation.Token;
            var queue = _eventQueue;

            var thread = new Thread(() => EventDispatcherThread(cancellationToken, queue));
            thread.Start();
        }

        ~DedicatedThreadDispatcher()
        {
            _threadCancellation.Cancel();
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

        static void EventDispatcherThread(CancellationToken cancellationToken, BlockingCollection<Action> queue)
        {
            try
            {
                while (true)
                {
                    var action = queue.Take(cancellationToken);
                    action();
                }
            }
            catch (OperationCanceledException)
            {}
        }
    }
}
