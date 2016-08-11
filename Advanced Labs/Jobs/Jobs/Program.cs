using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace Jobs
{
    class Program
    {
        static void Main(string[] args)
        {
            Process curProcess;
            using (Job job = new Job("a", 1))
            {
                for (int i = 0; i < 20; i++)
                {
                    curProcess = Process.Start("Notepad");
                    job.AddProcessToJob(curProcess);
                }

                Console.WriteLine("Press any key to kill the processes");
                Console.ReadLine();
                job.Kill();
            }
        }
    }
}
