using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Files
{
    class Files
    {
        static void Main(string[] args)
        {
            int numberOfFiles = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, long>> allFiles =
                new Dictionary<string, Dictionary<string, long>>();

            for (int i = 0; i < numberOfFiles; i++)
            {
                // Input format: Games\Pirates\Start\keygen.exe;1024

                string currentFileProperties = Console.ReadLine();
                string[] getSize = currentFileProperties.Split(';');

                long currentFileSize = long.Parse(getSize[1]);              // Size

                string[] getRootAndFileName = getSize[0].Split('\\');

                string currFileRoot = getRootAndFileName[0];                // Root
                string currFileName = getRootAndFileName.Last();            // Name

                if (! allFiles.ContainsKey(currFileRoot))
                {
                    allFiles[currFileRoot] = new Dictionary<string, long>();
                }
                if (! allFiles[currFileRoot].ContainsKey(currFileName))
                {
                    allFiles[currFileRoot][currFileName] = 0;
                }

                allFiles[currFileRoot][currFileName] = currentFileSize;

            }

            string[] queryParameters = Console.ReadLine()
                .Split(new[] { " in " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string neededExtension = queryParameters[0];
            string neededRoot = queryParameters[1];

            bool fileFound = false;

            foreach (var root in allFiles.Where(l => l.Key == neededRoot))
            {
                foreach (var file in root.Value
                    .Where(f => f.Key.Split('.').Last() == neededExtension)
                    .OrderByDescending(f => f.Value)
                    .ThenBy(f => f.Key))
                {
                    Console.WriteLine($"{file.Key} - {file.Value} KB");
                    fileFound = true;
                }
            }

            if (! fileFound)
            {
                Console.WriteLine("No");
            }
        }
    }
}
