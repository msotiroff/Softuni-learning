using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumArrayElements
{
    class SumArrayElements
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            for (int index = 0; index < numbers.Length; index++)
            {
                int num = int.Parse(Console.ReadLine());
                numbers[index] = num;
            }

            int sum = 0;

            for (int index = 0; index < numbers.Length; index++)
            {
                sum += numbers[index];
            }

            Console.WriteLine(sum);
        }
    }
}
