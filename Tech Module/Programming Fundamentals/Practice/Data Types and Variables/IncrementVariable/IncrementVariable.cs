using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncrementVariable
{
    class IncrementVariable
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            if (num <= 255)
            {
                Console.WriteLine(num);
            }
            else
            {
                double overFlow = num / 256;
                Console.WriteLine(num % 256);
                Console.WriteLine("Overflowed {0} times", overFlow);
            }
        }
    }
}
