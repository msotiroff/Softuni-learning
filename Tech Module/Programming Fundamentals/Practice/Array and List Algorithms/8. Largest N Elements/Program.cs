using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Largest_N_Elements
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
            //On the next line, you will receive an integer N.
            //After that, find and print the largest N elements in the array,
            //sorted in descending order.

            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int n = int.Parse(Console.ReadLine());

            for (int j = 0; j < numbers.Count; j++)
            {
                for (int i = 0; i < numbers.Count - 1; i++)
                {
                    if (numbers[i + 1] > numbers[i])
                    {
                        int numberToInsert = numbers[i + 1];
                        numbers.RemoveAt(i + 1);
                        numbers.Insert(i, numberToInsert);
                    }
                }
            }

            for (int index = 0; index < n; index++)
            {
                Console.Write(numbers[index] + " ");
            }
            Console.WriteLine();
        }
    }
}
