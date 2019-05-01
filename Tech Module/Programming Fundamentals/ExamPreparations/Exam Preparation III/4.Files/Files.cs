using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Files
{
    public class File
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Root { get; set; }
        public long Size { get; set; }

    }

    class Files
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> filesData = new List<string>();

            List<File> allFiles = new List<File>();

            for (int i = 0; i < n; i++)
            {
                string currentFileData = Console.ReadLine();
                filesData.Add(currentFileData);
            }

            for (int i = 0; i < filesData.Count; i++)
            {
                string[] pathNameAndSize = filesData[i].Split(';').ToArray();

                long currentFileSize = long.Parse(pathNameAndSize[1]);                    // FILE SIZE !!!
                
                string currentFileName = pathNameAndSize[0]
                    .Split(new[] { "\\" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray()
                    .Last();                                                            // FILE NAME

                string currentFileRoot = pathNameAndSize[0]
                    .Split(new[] { "\\" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray()
                    .First();                                                           // FILE ROOT

                string currentFileExtension = currentFileName.Split('.').Last();        // FILE EXTENSION

                bool existingFileFound = false;

                for (int j = 0; j < allFiles.Count; j++)
                {
                    File currFile = allFiles[j];
                    if (currFile.Name == currentFileName && currFile.Root == currentFileRoot)
                    {
                        currFile.Size = currentFileSize;
                        existingFileFound = true;
                        break;
                    }
                }

                if (! existingFileFound)
                {
                    File currentFile = new File();
                    currentFile.Name = currentFileName;
                    currentFile.Extension = currentFileExtension;
                    currentFile.Root = currentFileRoot;
                    currentFile.Size = currentFileSize;

                    allFiles.Add(currentFile);
                }
            }

            string[] command = Console.ReadLine()
                .Split(new[] { " in " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            // Command format:  {extension} in {root}

            string neededExtension = command[0];
            string neededRoot = command[1];

            bool isMatched = false;

            if (allFiles.Count > 0)
            {
                foreach (var file in allFiles.OrderByDescending(x => x.Size).ThenBy(x => x.Name))
                {
                    if (file.Root == neededRoot && file.Extension == neededExtension)
                    {
                        isMatched = true;
                        Console.WriteLine($"{file.Name} - {file.Size} KB");
                    }
                }
            }
            if(!isMatched)
            {
                Console.WriteLine("No");
            }

        }
    }
}
