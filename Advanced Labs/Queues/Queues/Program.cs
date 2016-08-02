using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            LimitedQueue<int> limitedQueue = new LimitedQueue<int>(10);
            Random random = new Random();
            int currentRandNum;

            for (int i = 0; i < 10; i++)
            {
                currentRandNum = random.Next(1, 50);
                Console.WriteLine("Adding item");
                ThreadPool.QueueUserWorkItem(q => limitedQueue.Enque(currentRandNum));
                Thread.Sleep(500);
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Removing item");
                ThreadPool.QueueUserWorkItem(q => limitedQueue.Deque());
                Thread.Sleep(500);
            }

        }
    }
}
