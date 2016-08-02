using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{
    class LimitedQueue <T>
    {
        private Queue<T> queue = new Queue<T>();
        private SemaphoreSlim writersSemaphoreSlim;
        private SemaphoreSlim readersSemaphoreSlim;
        private object lockObj;

        public LimitedQueue(int limit)
        {
            writersSemaphoreSlim = new SemaphoreSlim(limit, limit);
            readersSemaphoreSlim = new SemaphoreSlim(0, limit);
            lockObj = new object();
        }

        public void Enque(T item)
        {
            writersSemaphoreSlim.Wait();
            lock (lockObj)
            {
                queue.Enqueue(item);
            }

            readersSemaphoreSlim.Release();
        }

        public T Deque()
        {
            T node = default(T);
            readersSemaphoreSlim.Wait();
            if (queue.Any())
            {
                lock (lockObj)
                {
                    node = queue.Dequeue();
                }
            }

            writersSemaphoreSlim.Release();
            return node;
        }
    }
}
