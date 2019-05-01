using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Bills
{
    class Bills
    {
        static void Main(string[] args)
        {
            int months = int.Parse(Console.ReadLine());

            int waterAndInternet = 35;

            double electricity = 0;

            for (int i = 0; i < months; i++)
            {
                double currentElectricity = double.Parse(Console.ReadLine());
                electricity += currentElectricity;
            }

            double others = (waterAndInternet * months + electricity) * 1.2;
            double average = (waterAndInternet * months + electricity + others) / months;

            Console.WriteLine($"Electricity: {electricity:f2} lv");
            Console.WriteLine($"Water: {months * 20:f2} lv");
            Console.WriteLine($"Internet: {months * 15:f2} lv");
            Console.WriteLine($"Other: {others:f2} lv");
            Console.WriteLine($"Average: {average:f2} lv");

        }
    }
}
