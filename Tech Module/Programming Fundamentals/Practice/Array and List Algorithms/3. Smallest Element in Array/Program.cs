using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Smallest_Element_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            //Note: for this exercise, you are not allowed to use LINQ
            //for the actual algorithms(parsing the input with LINQ is okay).
            //The exercise is intended to help you flex your algorithmic thinking
            //skills, and as such, please try to solve the problems algorithmically.

            //Read a list of integers on the first line of the console.
            //After that, find the smallest element in the array and print it on the console.

            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int smallestNumber = int.MaxValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < smallestNumber)
                {
                    smallestNumber = numbers[i];
                }
            }

            Console.WriteLine(smallestNumber);
        }
    }
}
