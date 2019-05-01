using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Array_Contains_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read a list of integers on the first line of the console
            //and an integer N from the second line of the console
            //and print whether the element is contained in the array.
            //If it is, print “yes”, otherwise print “no”.

            //Note: for this exercise, you are not allowed to use LINQ
            //for the actual algorithms (parsing the input with LINQ is okay). 
            //The exercise is intended to help you flex your algorithmic thinking
            //skills, and as such, please try to solve the problems algorithmically.

            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int n = int.Parse(Console.ReadLine());

            bool isFound = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == n)
                {
                    isFound = true;
                    break;
                }
            }

            if (isFound)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

        }
    }
}
