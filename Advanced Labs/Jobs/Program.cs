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
            using (Job job = new Job())
            {
                for (int i = 0; i < 10; i++)
                {
                    Process process = Process.Start("Notepad");
                    job.AddProcessToJob(process);
                }

                Console.WriteLine("Press enter to kill all the processes");
                Console.ReadLine();
                job.Kill();
            }
        }
	}
}
