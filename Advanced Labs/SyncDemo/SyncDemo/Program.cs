using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SyncDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            bool mutexWasCreated;
            Mutex SyncFileMutex = new Mutex(true, "SyncFileMutex", out mutexWasCreated);
            if (!Directory.Exists(@"c:\temp"))
            {
                Directory.CreateDirectory(@"c:\temp");
            }
           
            Console.WriteLine("Start writing");
            for (int i = 0; i < 10000; i++)
            {
                try
                {
                    SyncFileMutex.WaitOne();
                    
                    using (StreamWriter streamWriter = new StreamWriter(@"c:\temp\data.txt", true))
                    {
                        streamWriter.WriteLine(" {0}- Process identifier : {1}", i, Process.GetCurrentProcess().Id);
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    SyncFileMutex.ReleaseMutex();
                }
            }
        }
    }
}
