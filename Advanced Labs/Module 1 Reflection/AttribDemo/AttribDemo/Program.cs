using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AttribDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyAnalayze assemblyAnalayze = new AssemblyAnalayze();
            Console.WriteLine("All Attributes are Approved: {0}", assemblyAnalayze.AnalayzeAssembly(Assembly.GetExecutingAssembly())); 
        }
    }
}
