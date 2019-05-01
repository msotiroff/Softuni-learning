using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.SortArrayUsingInsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //        Note: for this exercise, you are not allowed to use LINQ
            //for the actual algorithms(parsing the input with LINQ is okay).
            //The exercise is intended to help you flex your algorithmic thinking
            //skills, and as such, please try to solve the problems algorithmically.

            //Read a list of integers on the first line of the console.
            //After that, sort the array, using the Insertion Sort algorithm.

            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int smallestNumber = int.MaxValue;
            int tempIndex = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i; j < numbers.Length; j++)
                {
                    if (numbers[j] < smallestNumber)
                    {
                        smallestNumber = numbers[j];
                        tempIndex = j;
                    }
                }
                numbers[tempIndex] = numbers[i];
                numbers[i] = smallestNumber;
                smallestNumber = int.MaxValue;
                tempIndex = 0;
            }
            
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
