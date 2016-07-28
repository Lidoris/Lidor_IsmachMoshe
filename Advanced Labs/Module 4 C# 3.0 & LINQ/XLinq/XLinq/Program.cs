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
            //2
            var xml = new XElement("Types", from t in Assembly.GetAssembly(typeof(string)).GetTypes()
                                            where t.IsPublic && t.IsClass
                                            select new XElement("Type", new XAttribute("FullName", t.FullName),
                                            new XElement("Properties", from prop in t.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                                                       select new XElement("Property", new XAttribute("Name", prop.Name), new XAttribute("Type", prop.PropertyType))),
                                            new XElement("Methods", from th in t.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                                                                    select new XElement("Method", new XAttribute("Name", th.Name), new XAttribute("ReturnType", th.ReturnType),
                                                             new XElement("Parameters", from p in th.GetParameters()
                                                                                        select new XElement("Parameter", new XAttribute("Name", p.Name),
                                                                                                new XAttribute("Type", p.ParameterType.Name)))))));
            xml.Save("output.xml");
            //3.a
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

            Console.WriteLine("The total types without properties : {0}", query1.Count());

            //3.b
            var query2 = from methods in xml.Descendants("Methods")
                         select (methods.Descendants().Count());

            Console.WriteLine("The total number of methods : {0}", query2.Sum());

            //3.c
            var query3 = from properties in xml.Descendants("Properties")
                         select (properties.Descendants().Count());

            Console.WriteLine("The total number of properties : {0}", query3.Sum());

            var query4 = from type in xml.Descendants("Parameter").Attributes("Type")
                         group type by type.Value into groupByType
                         orderby groupByType.Count() descending
                         select new
                         {
                             Type = groupByType.Key,
                             Count = groupByType.Count()
                         };

            Console.WriteLine("The most common type as a parameter : {0} ", query4.First());

            //3.d
            var query5 = new XElement("Types", from type in xml.Descendants("Type")
                                               orderby type.Descendants("Method").Count() descending
                                               select new XElement("Type", new XAttribute("FullName", (string)type.Attribute("FullName")),
                                               new XAttribute("NumberOfProperties", type.Descendants("Property").Count()),
                                               new XAttribute("NumberOfMethods", type.Descendants("Method").Count())));

            query5.Save("output3d.xml");

            //3.e
            var query6 = from type in xml.Descendants("Type")
                         orderby type.Attribute("FullName").Value ascending
                         group new
                         {
                            FullName = (string)type.Attribute("FullName"),
                            NumberOfMethods = type.Descendants("Method").Count()
                         } by type.Descendants("Method").Count() into groupByMethodsCount
                         orderby groupByMethodsCount.Key descending
                         select groupByMethodsCount ;

            foreach (var p in query6)
            {
                Console.WriteLine(p.Key);
                Console.WriteLine("===========");
                foreach (var item in p)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("===========");
            }
        }
    }
}
