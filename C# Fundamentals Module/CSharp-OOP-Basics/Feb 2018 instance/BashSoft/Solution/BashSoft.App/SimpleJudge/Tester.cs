namespace BashSoft.App.SimpleJudge
{
    using Core;
    using Extensions;
    using Extensions.CustomExceptions;
    using IO;
    using System;
    using System.IO;

    public class Tester
    {
        public void CompareContent(string userOutputPath, string expectedOutputPath)
        {
            OutputWriter.WriteMessageOnNewLine(Constants.ReadingFiles);

            try
            {
                string mismatchesPath = GetMismatchPath(expectedOutputPath);

                string[] actualOutputLines = File.ReadAllLines(userOutputPath);
                string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);

                bool hasMismatch;
                string[] mismatches =
                    GetLineWithPossibleMismatches(actualOutputLines, expectedOutputLines, out hasMismatch);

                PrintOutput(mismatches, hasMismatch, mismatchesPath);
                OutputWriter.WriteMessageOnNewLine(Constants.FilesRead);
            }
            catch (FileNotFoundException)
            {
                throw new InvalidPathException();
            }
            catch (DirectoryNotFoundException)
            {
                throw new InvalidPathException();
            }
        }

        private void PrintOutput(string[] mismatches, bool hasMismatch, string mismatchesPath)
        {
            if (hasMismatch)
            {
                mismatches
                    .ForEach(line => OutputWriter.WriteMessageOnNewLine(line));

                try
                {
                    File.WriteAllLines(mismatchesPath, mismatches);
                }
                catch (DirectoryNotFoundException)
                {
                    throw new InvalidPathException();
                }
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine(Constants.NoMismatches);
            }
        }

        private string[] GetLineWithPossibleMismatches(string[] actualOutputLines, string[] expectedOutputLines, out bool hasMismatch)
        {
            hasMismatch = false;
            string output = string.Empty;
            
            OutputWriter.WriteMessageOnNewLine(Constants.ComparingFiles);

            var minOutputLines = actualOutputLines.Length;

            if (actualOutputLines.Length != expectedOutputLines.Length)
            {
                OutputWriter.DisplayException(ExceptionMessages.ComparisonOfFilesWithDifferentSizes);
            }

            string[] mismatches = new string[minOutputLines];

            for (int index = 0; index < minOutputLines; index++)
            {
                string actualLine = actualOutputLines[index];
                string expectedLine = expectedOutputLines[index];

                if (!actualLine.Equals(expectedLine))
                {
                    output = string.Format(Constants.MismatchByLine, index, expectedLine, actualLine);
                    output += Environment.NewLine;
                    hasMismatch = true;
                }
                else
                {
                    output = actualLine;
                    output += Environment.NewLine;
                }

                mismatches[index] = output;
            }

            return mismatches;
        }

        private string GetMismatchPath(string expectedOutputPath)
        {
            int indexOf = expectedOutputPath.LastIndexOf("\\");
            string directoryPath = expectedOutputPath.Substring(0, indexOf);
            string finalPath = directoryPath + @"\Mismatches.txt";
            return finalPath;
        }
    }
}
