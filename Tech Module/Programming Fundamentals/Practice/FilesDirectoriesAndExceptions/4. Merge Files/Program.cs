using System;
using System.Collections.Generic;
using System.IO;

namespace _4.Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            // Reads each string in the given two files and save them in arrays:
            string[] firstWords = File.ReadAllLines("../../FileOne.txt");
            string[] secondWords = File.ReadAllLines("../../FileTwo.txt");

            // Get the count of smaller array and bigger array:
            int minIndexes = Math.Min(firstWords.Length, secondWords.Length);
            int maxIndexes = Math.Max(firstWords.Length, secondWords.Length);
            
            List<string> resultCollection = new List<string>();

            // Add lines mixed one by one from the two arrays in "resultCollection":
            for (int i = 0; i < minIndexes; i++)
            {
                resultCollection.Add(firstWords[i]);
                resultCollection.Add(secondWords[i]);
            }
            for (int i = minIndexes; i < maxIndexes; i++)
            {
                if (firstWords.Length == maxIndexes)
                {
                    resultCollection.Add(firstWords[i]);
                }
                else
                {
                    resultCollection.Add(secondWords[i]);
                }
            }

            // Append the merged strings in a new .txt file:
            File.AppendAllLines("../../Output.txt", resultCollection);

        }
    }
}
