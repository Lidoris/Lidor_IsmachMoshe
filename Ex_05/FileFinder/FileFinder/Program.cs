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
            string[] Files = Directory.GetFiles(args[0]);
            string Substring = args[1];
            List<string> filesWithSubstring;
            
            filesWithSubstring = FindFilesBySubstring(Files, Substring);

            foreach (string path in filesWithSubstring)
            {
                Console.WriteLine(path);
            }
        }

        static List<string> FindFilesBySubstring(string[] dirs, string Substring)
        {
            List<string> filesWithSubstring = new List<string>();

            foreach (string path in dirs)
            {
                if (path.Contains(Substring))
                {
                    filesWithSubstring.Add(path);
                }
            }

            return filesWithSubstring;
        }
    }
}
