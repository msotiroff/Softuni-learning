using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Profit
{
    class Profit
    {
        static void Main(string[] args)
        {
            int workingDaysByMonth = int.Parse(Console.ReadLine());
            double moneyPerDay = double.Parse(Console.ReadLine());
            double dollarExchange = double.Parse(Console.ReadLine());

            double annualEarning = workingDaysByMonth * moneyPerDay * 14.5 * dollarExchange;
            double netEarning = annualEarning * 0.75;

            double daylyEarning = netEarning / 365;

            Console.WriteLine($"{daylyEarning:f2}");

        }
    }
}
