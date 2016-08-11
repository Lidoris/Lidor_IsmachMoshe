using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomAwaiter
{
    static class IntAwaiter
    {
        public static async void AwaitInt( int miliseconds)
        {
            await miliseconds;
        }

        public static TaskAwaiter GetAwaiter(this int miliseconds)
        {
            return Task.Delay(miliseconds).GetAwaiter();
        }
    }
}
