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

            //1.a
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

            //1.b
            var query2 = from p in Process.GetProcesses()
                         where p.Threads.Count < 5 && p.IsSystem()
                         orderby p.Id
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

            //1.c
            var query3 = from p in Process.GetProcesses()
                         where p.Threads.Count < 5 && p.IsSystem()          // IsSystem it is an Extension Method that was created to check if process.StartTime will throw an exception
                         group new
                         {
                             Name = p.ProcessName,
                             ID = p.Id,
                             StartTime = p.StartTime
                         } by p.BasePriority into BasePriority
                         select BasePriority;
 
            foreach (var p in query3)
            {
                Console.WriteLine(p.Key);
                Console.WriteLine("===========");
                foreach (var item in p)
                {
                    Console.WriteLine(item);

                }

                Console.WriteLine("===========");
            }

            //1.d
            var totalNumOfThreads = Process.GetProcesses().Select(x => x.Threads.Count).Sum();
            Console.WriteLine("Total threads: {0}", totalNumOfThreads);
            //2
            Student student = new Student(123456789, "Lidor", 24);
            Person persone = new Person(0, "0", 0);
            student.CopyTo(persone);
            Console.WriteLine(persone);
        }
    }
}
