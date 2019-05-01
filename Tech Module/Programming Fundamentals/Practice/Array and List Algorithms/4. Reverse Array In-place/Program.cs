using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Reverse_Array_In_place
{
    class Program
    {
        static void Main(string[] args)
        {
            //        Note: for this exercise, you are not allowed to use LINQ
            //for the actual algorithms(parsing the input with LINQ is okay).
            //The exercise is intended to help you flex your algorithmic thinking
            //skills, and as such, please try to solve the problems algorithmically.

            //Read a list of integers on the first line of the console. After that,
            //reverse the array in-place(as in, don’t create a new collection to hold the result,
            //reverse it using only the original array). 
            //After you are done, print the reversed array on the console.

            //Note: You are not allowed to iterate over the list backwards and just print it.

            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < numbers.Length / 2; i++)
            {
                int currentNumber = numbers[i];
                numbers[i] = numbers[numbers.Length - i - 1];
                numbers[numbers.Length - i - 1] = currentNumber;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
            Console.WriteLine();
        }
    }
}
