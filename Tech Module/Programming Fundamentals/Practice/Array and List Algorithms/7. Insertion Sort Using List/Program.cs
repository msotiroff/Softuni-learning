using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Insertion_Sort_Using_List
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
            //After that, sort the array, using the Insertion Sort algorithm,
            //but instead of doing it in-place, add the result one by one to a list.

            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            for (int j = 0; j < numbers.Count; j++)
            {
                for (int i = 0; i < numbers.Count - 1; i++)
                {
                    if (numbers[i + 1] < numbers[i])
                    {
                        int numberToInsert = numbers[i + 1];
                        numbers.RemoveAt(i + 1);
                        numbers.Insert(i, numberToInsert);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
