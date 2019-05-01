
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMethod
{
    class MinMethod
    {
        static void Main(string[] args)
        {
            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());
            int numThree = int.Parse(Console.ReadLine());

            int smaller = GetMin(numOne, numTwo);
            int smallest = GetMin(smaller, numThree);

            Console.WriteLine(smallest);
        }

        static int GetMin(int a, int b)
        {
            if (a < b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
    }
}
