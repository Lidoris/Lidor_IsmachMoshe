using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynInvoke
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(InvokeHello("Lidor", new A()));
                Console.WriteLine(InvokeHello("Hadar", new B()));
                Console.WriteLine(InvokeHello("Sapir", new C()));
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("One or more of the arguments is null");
            }
            catch (MissingMethodException)
            {
                Console.WriteLine("No method can be found that matches the arguments in args");
            }
        }

        public static string InvokeHello (string str, Object obj)
        {
            if(obj != null)
            {
              
                Type type = obj.GetType();
                return (string)type.InvokeMember("Hello", BindingFlags.InvokeMethod, null, obj, new string[] { str });
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }
}
