using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Money
{
    class Money
    {
        static void Main(string[] args)
        {
            double bitcoins = double.Parse(Console.ReadLine());
            double chineseCurrency = double.Parse(Console.ReadLine());
            double comission = double.Parse(Console.ReadLine());

            double moneyInLeva = bitcoins * 1168 + chineseCurrency * 0.15 * 1.76;
            double moneyInEuro = moneyInLeva / 1.95;
            moneyInEuro -= moneyInEuro * comission / 100;

            Console.WriteLine(moneyInEuro);
        }
    }
}
