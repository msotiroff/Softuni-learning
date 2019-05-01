using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Sort_Array_Using_Bubble_Sort
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
            //After that, sort the array, using the Bubble Sort algorithm.

            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = 0; j < numbers.Length - i - 1; j++)
                {
                    int leftElement = numbers[j];
                    int rightElement = numbers[j + 1];

                    if (leftElement > rightElement)
                    {
                        numbers[j] = rightElement;
                        numbers[j + 1] = leftElement;
                    }
                }
            }
            
            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
