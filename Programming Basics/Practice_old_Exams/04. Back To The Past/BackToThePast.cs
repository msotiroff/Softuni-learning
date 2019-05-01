using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Back_To_The_Past
{
    class BackToThePast
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int yearOfDeath = int.Parse(Console.ReadLine());

            double spentMoney = 0;

            for (int i = 1800; i <= yearOfDeath; i++)
            {
                if (i % 2 == 0)
                {
                    spentMoney += 12000;
                }
                else
                {
                    spentMoney += 12000 + 50 * (i - 1800 + 18);
                }
            }
            double difference = Math.Abs(money - spentMoney);

            if (money >= spentMoney)
            {
                Console.WriteLine("Yes! He will live a carefree life and will have {0:f2} dollars left.", difference);
            }
            else
            {
                Console.WriteLine("He will need {0:f2} dollars to survive.", difference);
            }
        }
    }
}
