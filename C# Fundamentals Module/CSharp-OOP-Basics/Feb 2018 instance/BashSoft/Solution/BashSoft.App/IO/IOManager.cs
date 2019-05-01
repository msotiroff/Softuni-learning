namespace BashSoft.App.IO
{
    using Core;
    using Extensions;
    using Extensions.CustomExceptions;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class IOManager
    {
        public void TraverseDirectory(int depth)
        {
            OutputWriter.WriteEmptyLine();
            int initialIdentation = SessionData.currentPath.Split(@"\").Length;

            Queue<string> subFolders = new Queue<string>();
            subFolders.Enqueue(SessionData.currentPath);

            while (subFolders.Count > 0)
            {
                var currentPath = subFolders.Dequeue();
                var identation = currentPath.Split(@"\").Length - initialIdentation;

                if (depth - identation < 0)
                {
                    break;
                }

                try
                {
                    var allPathsInCurrentDirectory = Directory.GetDirectories(currentPath);

                    allPathsInCurrentDirectory.ForEach(p => subFolders.Enqueue(p));

                    OutputWriter.WriteMessageOnNewLine($"{new string('-', identation)}{currentPath}");

                    Directory.GetFiles(currentPath)
                    .ForEach(f =>
                        OutputWriter.WriteMessageOnNewLine(string.Format("{0}{1}",
                            new string('-', f.LastIndexOf("\\")),
                            f.Substring(f.LastIndexOf("\\")))));
                }
                catch (UnauthorizedAccessException)
                {
                    throw new UnauthorizedAccessException(ExceptionMessages.UnauthorizedAccess);
                }
            }
        }

        public void CreateDirectoryInCurrentFolder(string folderName)
        {
            string path = SessionData.currentPath + "\\" + folderName;
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (Exception)
            {
                throw new InvalidFileNameException();
            }
        }

        public void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath.Equals(".."))
            {
                try
                {
                    string currentPath = SessionData.currentPath;
                    int indexOfLastSlash = currentPath.LastIndexOf("\\");
                    string newPath = currentPath.Substring(0, indexOfLastSlash);
                    SessionData.currentPath = newPath;
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw new ArgumentOutOfRangeException(ExceptionMessages.UnableToGoHigherInPartitionHierarchy);
                }

            }
            else
            {
                string currentPath = SessionData.currentPath;
                currentPath += "\\" + relativePath;
                ChangeCurrentDirectoryAbsolute(currentPath);
            }
        }

        public void ChangeCurrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                throw new InvalidPathException();
            }

            SessionData.currentPath = absolutePath;
        }

        public string ReadHelpInfo()
        {
            var helpInfo = File.ReadAllText(Constants.HelpFilePath);

            return helpInfo;
        }
    }
}
