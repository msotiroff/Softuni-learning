using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Digits
{
    class Digits
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int thirdDigit = number % 10;
            int secontDigit = (number / 10) % 10;
            int firstDigit = (number / 100) % 10;

            int rows = firstDigit + secontDigit;
            int columns = firstDigit + thirdDigit;
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (number % 5 == 0)
                    {
                        number -= firstDigit;
                    }
                    else if (number % 3 == 0)
                    {
                        number -= secontDigit;
                    }
                    else
                    {
                        number += thirdDigit;
                    }
                    Console.Write(number + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
