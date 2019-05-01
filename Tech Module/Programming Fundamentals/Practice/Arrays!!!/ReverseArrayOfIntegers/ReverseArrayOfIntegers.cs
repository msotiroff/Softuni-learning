using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseArrayOfIntegers
{
    class ReverseArrayOfIntegers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] array = new int[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            for (int index = n-1; index >= 0; index--)
            {
                Console.Write("{0} ", array[index]);
            }
            Console.WriteLine();

        }
    }
}
