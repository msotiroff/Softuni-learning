using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.TwoNumbersSum
{
    class TwoNumbersSum
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());

            int counter = 0;

            for (int i = firstNum; i >= secondNum; i--)
            {
                for (int j = firstNum; j >= secondNum; j--)
                {
                    counter++;
                    if (i + j == magicNum)
                    {
                        Console.WriteLine($"Combination N:{counter} ({i} + {j} = {magicNum})");
                        return;
                    }
                    if (i == secondNum && j == secondNum)
                    {
                        Console.WriteLine($"{counter} combinations - neither equals {magicNum}");
                    }
                }
            }
        }
    }
}
