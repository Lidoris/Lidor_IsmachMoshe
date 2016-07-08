using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AttribDemo
{
    class AssemblyAnalayze
    {
        public bool AnalayzeAssembly(Assembly assembly)
        {
            Type [] arrayOfTypes = assembly.GetTypes();
            bool flag = true;
            foreach (Type type in arrayOfTypes)
            {
                if (type != null)
                {
                    var attr = type.GetCustomAttribute(typeof(CodeReviewAttribute));
                    if (attr is CodeReviewAttribute && attr != null)
                    {
                        if ((attr as CodeReviewAttribute).IsApproved == false)
                        {
                            flag = false;
                        }

                        Console.WriteLine(attr.ToString()); 
                    }
                }
            }

            return flag;
        }
    }
}
