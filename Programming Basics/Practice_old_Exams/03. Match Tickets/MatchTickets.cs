using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Match_Tickets
{
    class MatchTickets
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine().ToLower();
            int peopleInGroup = int.Parse(Console.ReadLine());

            double transportCosts = 0;

            if (peopleInGroup < 5)
            {
                transportCosts = budget * 0.75;
            }
            else if (peopleInGroup >= 5 && peopleInGroup < 10)
            {
                transportCosts = budget * 0.6;
            }
            else if (peopleInGroup >= 10 && peopleInGroup < 25)
            {
                transportCosts = budget * 0.5;
            }
            else if (peopleInGroup >= 25 && peopleInGroup < 50)
            {
                transportCosts = budget * 0.4;
            }
            else if (peopleInGroup >= 50)
            {
                transportCosts = budget * 0.25;
            }

            double moneyLeft = budget - transportCosts;
            double ticketsCost = 0;
            if (category == "vip")
            {
                ticketsCost = peopleInGroup * 499.99;
            }
            else if (category == "normal")
            {
                ticketsCost = peopleInGroup * 249.99;
            }

            double difference = Math.Abs(moneyLeft - ticketsCost);

            if (moneyLeft >= ticketsCost)
            {
                Console.WriteLine("Yes! You have {0:f2} leva left.", difference);
            }
            else
            {
                Console.WriteLine("Not enough money! You need {0:f2} leva.", difference);
            }
        }
    }
}
