using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SmartLilly
{
    class SmartLilly
    {
        static void Main(string[] args)
        {
            int lillysAge = int.Parse(Console.ReadLine());
            double washingMashinePrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            int toys = 0;
            int money = 0;

            for (int i = 1; i <= lillysAge; i++)
            {
                if (i % 2 != 0)
                {
                    toys++;
                }
                else
                {
                    money += i * 5 - 1;
                }
            }
            int moneyByToys = toys * toyPrice;

            int allSavedMoney = moneyByToys + money;
            double difference = Math.Abs(allSavedMoney - washingMashinePrice);

            if (allSavedMoney >= washingMashinePrice)
            {
                Console.WriteLine("Yes! {0:f2}", difference);
            }
            else
            {
                Console.WriteLine("No! {0:f2}", difference);
            }

        }
    }
}
