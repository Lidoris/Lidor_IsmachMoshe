using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomAwaiter
{
    class Program
    {
        static void Main(string[] args)
        {
            IntAwaiter.AwaitInt(100000);
            ProcessAwaiter.AwaitProcess(Process.GetCurrentProcess());
            Console.ReadLine();
        }


    }
}
