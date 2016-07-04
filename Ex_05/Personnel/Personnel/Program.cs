using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnel
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfData;

            try
            {
                listOfData = ReadData("myData.txt");
                foreach (string line in listOfData)
                {
                    Console.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public static List<string> ReadData(string path)
        {
            List<string> listOfData = new List<string>();
            StreamReader reader = new StreamReader(path);
            string line;

            line = reader.ReadLine();
            while (line != null)
            {
                listOfData.Add(line);
                line = reader.ReadLine();
            }

            return listOfData;
        }
    }
}
