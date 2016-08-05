using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectBuilder
{
    class Project
    {
        public int ID { get; private set; }

        public Project(int id)
        {
            ID = id;
        }

        public void BuildProject()
        {
            Console.WriteLine("Start building project number {0}...", ID);
            Thread.Sleep(1000);
            Console.WriteLine("Finished {0}", ID);
        }
    }
}
