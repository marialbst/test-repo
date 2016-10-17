using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Files
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, long>> fileDirectory = new Dictionary<string, Dictionary<string, long>>();

            for (int i = 0; i < n; i++)
            {
                string[] path = Console.ReadLine().Split('\\');
                string rootDir = path[0];
                string[] fileInfo = path[path.Length - 1].Split(new char[] { ';'}, StringSplitOptions.RemoveEmptyEntries);
                string file = fileInfo[0];
                long size = long.Parse(fileInfo[fileInfo.Length-1]);
                if (!fileDirectory.ContainsKey(rootDir))
                {
                    fileDirectory.Add(rootDir, new Dictionary<string, long>());
                }

                if (!fileDirectory[rootDir].ContainsKey(file))
                {
                    fileDirectory[rootDir].Add(file, 0);
                }

                fileDirectory[rootDir][file] = size;
            }

            string[] query = Console.ReadLine().Split(' ');

            string whereToSearch = query[2];
            string extention = query[0];
            bool contains = false;
            foreach (var root in fileDirectory.Where(x => x.Key == whereToSearch))
            {
                foreach (var file in root.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                   
                    if (file.Key.Contains(extention))
                    {
                        contains = true;
                        Console.WriteLine($"{file.Key} - {file.Value} KB");
                    }
                }
            }

            if (!contains)
            {
                Console.WriteLine("No");
            }
            
        }
    }
}
