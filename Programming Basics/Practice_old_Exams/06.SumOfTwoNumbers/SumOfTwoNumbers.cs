namespace _06.SumOfTwoNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class SumOfTwoNumbers
    {
        public static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int finishNumber = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            int counter = 0;

            for (int i = startNumber; i <= finishNumber; i++)
            {
                for (int j = startNumber; j <= finishNumber; j++)
                {
                    counter++;
                    if (i + j == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{counter} ({i} + {j} = {magicNumber})");
                        return;
                    }
                    if (i == finishNumber && j == finishNumber)
                    {
                        Console.WriteLine($"{counter} combinations - neither equals {magicNumber}");
                    }
                }
            }

        }
    }
}
