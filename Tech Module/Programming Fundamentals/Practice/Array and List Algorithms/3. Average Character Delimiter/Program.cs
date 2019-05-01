using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Average_Character_Delimiter
{
    class Program
    {
        static void Main(string[] args)
        {
            //            You will receive an array of strings as input.
            //Your task is to find the average character within every string in the array. 
            //As in, take every character’s ASCII code, 
            //sum it and divide the result by the sum of the count of all the letters in the array.
            //Note: for this exercise, you are not allowed to use LINQ
            //for the actual algorithms (parsing the input with LINQ is okay). 

            string[] input = Console.ReadLine().Split(' ').ToArray();

            int charactersCount = 0;
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string currentWord = input[i];

                for (int j = 0; j < currentWord.Length; j++)
                {
                    int currentASCIInumber = currentWord[j];
                    sum += currentASCIInumber;
                    charactersCount++;
                }
            }

            int average = sum / charactersCount;

            char delimiter = Convert.ToChar(average);
            string separator = Convert.ToString(delimiter).ToUpper();

            Console.WriteLine(string.Join(separator, input));
        }
    }
}
