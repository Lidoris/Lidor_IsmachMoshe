using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
                string Substring = args[1];
                List<string> filesWithSubstring;
                FileFinder fileFinder = new FileFinder(args[0], args[1]);

                filesWithSubstring = fileFinder.FindFiles();

                foreach (string path in filesWithSubstring)
                {
                    Console.WriteLine("{0} , file length: {1}.", path, (new FileInfo(path)).Length);
                }

            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("The caller does not have the required permission.");
            }
            catch (IOException)
            {
                Console.WriteLine("path is a file name.");
            }
        }

        
    }
}
