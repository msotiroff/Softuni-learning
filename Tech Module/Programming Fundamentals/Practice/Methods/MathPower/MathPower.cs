using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPower
{
    class MathPower
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            PoweredNumber(number, power);
        }

        static double PoweredNumber(double number, int power)
        {
            double poweredNumber = 1.0;
            for (int i = 0; i < power; i++)
            {
                poweredNumber *= number;
            }
            Console.WriteLine(poweredNumber);
            return poweredNumber;
        }
    }
}
