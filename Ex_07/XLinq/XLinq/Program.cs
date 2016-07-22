using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XLinq
{
    class Program
    {
        static void Main(string[] args)
        {

            var xml = new XElement("Types", from t in Assembly.GetAssembly(typeof(string)).GetTypes()
                                              where t.IsPublic && t.IsClass
                                              select new XElement("Type", new XAttribute("FullName", t.FullName),
                                              new XElement("Properties", from prop in t.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                                                         select new XElement("Property", new XAttribute("Name", prop.Name), new XAttribute("Type", prop.PropertyType))),
                                              new XElement("Methods", from th in t.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                                                                          //  where /// not including inherited ones that are not overridden
                                                                      select new XElement("Method", new XAttribute("Name", th.Name), new XAttribute("ReturnType", th.ReturnType),
                                                               new XElement("Parameters", from p in th.GetParameters()
                                                                                          select new XElement("Parameter", new XAttribute("Name", p.Name),
                                                                                                  new XAttribute("Type", p.GetType())))))));
            xml.Save("output.xml");

            var query1 = from type in xml.Descendants("Type")
                         where type.Element("Properties").Descendants().Count() == 0
                         orderby (string)type.Attribute("FullName")
                         select new
                         {
                             FullName = (string)type.Attribute("FullName")
                         };

            foreach (var type in query1)
            {
                Console.WriteLine(type);
            }

            Console.WriteLine("The total types without properties : {0}",query1.Count()); //170

            var query2 = from method in xml.Descendants("Method")
                             //where method.//   not including inherited on
                         select (method.Descendants().Count());

            Console.WriteLine("The total number of methods : {0}", query2);


        }
    }
}
