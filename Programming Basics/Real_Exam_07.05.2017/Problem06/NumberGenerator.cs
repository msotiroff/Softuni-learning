using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem06
{
    class NumberGenerator
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            int specialNumber = int.Parse(Console.ReadLine());
            int controlNumber = int.Parse(Console.ReadLine());

            for (int firstDigit = m; firstDigit >= 1; firstDigit--)
            {
                for (int secondDigit = n; secondDigit >= 1; secondDigit--)
                {
                    for (int thirdDigit = l; thirdDigit >= 1; thirdDigit--)
                    {
                        if ((firstDigit + secondDigit + thirdDigit) % 3 == 0)
                        {
                            specialNumber += 5;
                        }
                        else if (thirdDigit == 5)
                        {
                            specialNumber -= 2;
                        }
                        else if (thirdDigit % 2 == 0)
                        {
                            specialNumber *= 2;
                        }
                        if (specialNumber >= controlNumber)
                        {
                            Console.WriteLine($"Yes! Control number was reached! Current special number is {specialNumber}.");
                            return;
                        }
                    }
                }
            }
            Console.WriteLine($"No! {specialNumber} is the last reached special number.");
        }
    }
}
