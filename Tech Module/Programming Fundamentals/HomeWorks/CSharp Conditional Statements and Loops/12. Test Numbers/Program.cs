using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Test_Numbers
{
    class TestNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            int maxSum = int.Parse(Console.ReadLine());

            int realSum = 0;
            int counter = 0;

            for (int i = n; i >= 1; i--)
            {
                for (int j = 1; j <= m; j++)
                {
                    int currentSum = i * j * 3;
                    realSum += currentSum;
                    counter++;
                    if (realSum >= maxSum)
                    {
                        Console.WriteLine($"{counter} combinations");
                        Console.WriteLine($"Sum: {realSum} >= {maxSum}");
                        return;
                    }
                    if (i == 1 && j == m)
                    {
                        Console.WriteLine($"{counter} combinations");
                        Console.WriteLine($"Sum: {realSum}");
                    }
                }
            }
        }
    }
}
