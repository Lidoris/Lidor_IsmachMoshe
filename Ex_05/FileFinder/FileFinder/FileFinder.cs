using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder
{
    class FileFinder
    {
        public string Path { get; private set; }
        public string Substring { get; private set; }

        public FileFinder(string path, string substring )
        {
            Path = path;
            Substring = substring;
        }

        public List<string> FindFiles()
        {
             string[] Files;
            List<string> filesWithSubstring;

            Files = recursiveFindPath(Path).ToArray();
            filesWithSubstring = FindFilesBySubstring(Files);

            return filesWithSubstring;
        }

        public List<string> recursiveFindPath(string path)
        {
            List<string> allFiles = new List<string>();
            allFiles.AddRange(Directory.GetFiles(path));
            
            string[] curFiles = Directory.GetDirectories(path);
            if (curFiles.Length != 0)
            {
                foreach (string innerPath in curFiles)
                {
                    allFiles.AddRange(recursiveFindPath(innerPath));
                }
            }
            
            return allFiles;
        }

        public List<string> FindFilesBySubstring(string[] dirs)
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
