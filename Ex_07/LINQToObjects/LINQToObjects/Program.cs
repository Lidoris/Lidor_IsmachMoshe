using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LINQToObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly mscorlib = typeof(string).Assembly;
            var query1 = from a in mscorlib.GetTypes()
                         where a.IsInterface && a.IsPublic
                         orderby a.Name
                         select new
                         {
                             Name = a.Name,
                             NumOfMethods = a.GetMethods().Length
                         };

            foreach (var a in query1)
            {
                Console.WriteLine(a);
            }

            var query2 = from p in Process.GetProcesses()
                         where p.Threads.Count < 5 && p.IsSystem()
                         orderby p.Id
                         //group p by p.BasePriority into BasePriority
                         select new
                         {
                             Name = p.ProcessName,
                             ID = p.Id,
                             StartTime = p.StartTime
                         };

            foreach (var p in query2)
            {
                Console.WriteLine(p);
            }

            var totalNumOfThreads = Process.GetProcesses().Select(x => x.Threads.Count).Sum();

            Console.WriteLine("Total threads: {0}", totalNumOfThreads);

            Student firstStudent = new Student(123456789, "Lidor", 24);
            Student secondStudent = new Student(0, "0", 0);
            firstStudent.CopyTo(secondStudent);

            Console.WriteLine(secondStudent);
        }
    }
}
