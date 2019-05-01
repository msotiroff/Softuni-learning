using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.Files
{
    class Program
    {
        static void Main(string[] args)
        {
            //         Root              FileName Size
            Dictionary<string, Dictionary<string, long>> allFiles
                = new Dictionary<string, Dictionary<string, long>>();

            Regex getSizeAndFullPath = new Regex(@"(.+);(\d+)");

            int numberOfFiles = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfFiles; i++)
            {
                string currentInput = Console.ReadLine();

                Match currentMatch = getSizeAndFullPath.Match(currentInput);

                string currentRoot = currentMatch.Groups[1].ToString().Split('\\').First();
                string currentFileName = currentMatch.Groups[1].ToString().Split('\\').Last();
                long currentFileSize = long.Parse(currentMatch.Groups[2].ToString());

                if (! allFiles.ContainsKey(currentRoot))
                {
                    allFiles[currentRoot] = new Dictionary<string, long>();
                }
                if (allFiles[currentRoot].ContainsKey(currentFileName))
                {
                    allFiles[currentRoot][currentFileName] = 0;
                }
                allFiles[currentRoot][currentFileName] = currentFileSize;
            }

            string[] finalCommands = Console.ReadLine().Split().ToArray();
            string neededExtension = finalCommands[0];
            string neededRoot = finalCommands[2];

            bool anyFilesFound = false;

            foreach (var root in allFiles.Where(x => x.Key == neededRoot))
            {
                foreach (var file in root.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    string currentFileExtension = file.Key.Split('.').Last();
                    if (currentFileExtension == neededExtension)
                    {
                        anyFilesFound = true;
                        Console.WriteLine($"{file.Key} - {file.Value} KB");
                    }
                }
            }

            if (! anyFilesFound)
            {
                Console.WriteLine("No");
            }
        }
    }
}
