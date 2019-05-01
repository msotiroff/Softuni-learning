using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ControlNumber
{
    class ControlNumber
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int controlNumber = int.Parse(Console.ReadLine());

            int sum = 0;
            int counter = 0;

            for (int i = 1; i <= n; i++)
            {
                for (int j = m; j >=1; j--)
                {
                    counter++;
                    int currentSum = i * 2 + j * 3;
                    sum += currentSum;
                    if (sum >= controlNumber)
                    {
                        Console.WriteLine($"{counter} moves");
                        Console.WriteLine($"Score: {sum} >= {controlNumber}");
                        return;
                    }
                    if (i == n && j == 1)
                    {
                        Console.WriteLine($"{counter} moves");
                    }
                }
            }
        }
    }
}
