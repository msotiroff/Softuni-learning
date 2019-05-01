using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Choose_a_Drink_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string profession = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            double bill = 0;

            if (profession == "Athlete")
            {
                bill = 0.7 * quantity;
            }
            else if (profession == "Businessman" || profession == "Businesswoman")
            {
                bill = 1.00 * quantity;
            }
            else if (profession == "SoftUni Student")
            {
                bill = 1.7 * quantity;
            }
            else
            {
                bill = 1.2 * quantity;
            }

            Console.WriteLine($"The {profession} has to pay {bill:f2}.");
        }
    }
}
