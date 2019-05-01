using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Array_Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            //            You will be given a string array on the console(single line, space - separated).
            //Your task is to make statistics about the elements of the array. 
            //Find out how many times each word occurs in the array. 
            //After which, sort the result by the count of occurrences in descending order
            //and print statistics about every word in the following format:
            //        { word} -> { count} times({ percentage: F2}%)
            //Note: for this exercise, you are not allowed to use LINQ
            //for the actual algorithms (parsing the input with LINQ is okay). 

            string[] words = Console.ReadLine().Split(' ').ToArray();
            int[] counters = new int[words.Length];
            bool[] found = new bool[words.Length];

            AddValuesToArrays(words, counters, found);

            SortArrays(words, counters, found);

            List<string> sortedWords = new List<string>();
            List<int> sortedCounters = new List<int>();
            List<double> compared = new List<double>();

            AddValuesFromArraysToLists(words, counters, found, sortedWords, sortedCounters, compared);

            for (int i = 0; i < sortedWords.Count; i++)
            {
                Console.WriteLine($"{sortedWords[i]} -> {sortedCounters[i]} times ({compared[i]:F2}%)");
            }
        }

        public static void AddValuesFromArraysToLists
            (string[] words, int[] counters, bool[] found, 
            List<string> sortedWords, List<int> sortedCounters, List<double> compared)
        {
            for (int i = 0; i < words.Length; i++)
            {
                if (!found[i])
                {
                    sortedWords.Add(words[i]);
                    sortedCounters.Add(counters[i]);
                }
            }

            int sumOfCounters = 0;
            for (int i = 0; i < sortedCounters.Count; i++)
            {
                sumOfCounters += sortedCounters[i];
            }

            for (int i = 0; i < sortedCounters.Count; i++)
            {
                double currentPercentage = (double)sortedCounters[i] / sumOfCounters * 100;
                compared.Add(currentPercentage);
            }
        }

        public static void SortArrays(string[] words, int[] counters, bool[] found)
        {
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words.Length - 1; j++)
                {
                    int leftCounter = counters[j];
                    int rightCounter = counters[j + 1];
                    string leftWord = words[j];
                    string rightWord = words[j + 1];
                    bool leftBool = found[j];
                    bool rightBool = found[j + 1];

                    if (leftCounter < rightCounter)
                    {
                        counters[j + 1] = leftCounter;
                        words[j + 1] = leftWord;
                        found[j + 1] = leftBool;
                        counters[j] = rightCounter;
                        words[j] = rightWord;
                        found[j] = rightBool;
                    }
                }
            }
        }

        public static void AddValuesToArrays(string[] words, int[] counters, bool[] found)
        {
            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i];
                int currentWordCounter = 1;
                for (int j = i; j < words.Length - 1; j++)
                {
                    if (found[j + 1] == false)
                    {
                        if (words[j + 1] == currentWord)
                        {
                            currentWordCounter++;
                            found[j + 1] = true;
                        }
                    }
                }
                counters[i] = currentWordCounter;
            }
        }
    }
}
