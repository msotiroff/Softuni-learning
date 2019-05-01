using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.MaxCombination
{
    class MaxCombination
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());
            int maxCombinations = int.Parse(Console.ReadLine());

            int counter = 0;
            for (int i = startNumber; i <= endNumber; i++)
            {
                for (int j = startNumber; j <= endNumber; j++)
                {
                    counter++;
                    Console.Write($"<{i}-{j}>");
                    if (counter == maxCombinations)
                    {
                        return;
                    }
                }
            }

        }
    }
}
