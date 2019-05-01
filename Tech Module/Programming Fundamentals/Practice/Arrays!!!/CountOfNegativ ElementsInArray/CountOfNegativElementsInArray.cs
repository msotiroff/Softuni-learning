using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountOfNegativ_ElementsInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());
                numbers[i] = currentNum;
            }

            int counter = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }
    }
}
