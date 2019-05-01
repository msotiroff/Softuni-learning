using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Sort_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            //            You are given an array of strings(one line, space - delimited).
            //Sort the array using the Bubble sort or Insertion sort algorithms.
            //Instead of comparing if one string is smaller than the other(which you can’t do), 
            //you can use the string.CompareTo(str) method.Once the array is sorted, 
            //print it on the console, separating the elements by spaces.
            //Note: for this exercise, you are not allowed to use LINQ
            //for the actual algorithms (parsing the input with LINQ is okay). 

            string[] words = Console.ReadLine().Split(' ').ToArray();

            for (int j = 0; j < words.Length; j++)
            {
                for (int i = 0; i < words.Length - 1; i++)
                {
                    string leftWord = words[i];
                    string rightWord = words[i + 1];
                    int difference = leftWord.CompareTo(rightWord);
                    if (difference > 0)
                    {
                        words[i] = rightWord;
                        words[i + 1] = leftWord;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", words));
        }
    }
}

