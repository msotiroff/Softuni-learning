using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Restaurant_Discount
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupSize = int.Parse(Console.ReadLine());
            string package = Console.ReadLine();

            string hallName = string.Empty;
            double hallPrice = 0.0;
            double packagePrice = 0.0;
            double discount = 0.0;

            if (package == "Normal")
            {
                packagePrice = 500;
                discount = 0.95;
            }
            else if (package == "Gold")
            {
                packagePrice = 750;
                discount = 0.90;
            }
            else if (package == "Platinum")
            {
                packagePrice = 1000;
                discount = 0.85;
            }

            if (groupSize <= 50)
            {
                hallName = "Small Hall";
                hallPrice = 2500;
            }
            else if (groupSize <= 100)
            {
                hallName = "Terrace";
                hallPrice = 5000;
            }
            else if (groupSize <= 120)
            {
                hallName = "Great Hall";
                hallPrice = 7500;
            }
            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
                return;
            }

            double totalPrice = (hallPrice + packagePrice) * discount;
            double pricePerPerson = (double)totalPrice / groupSize;

            Console.WriteLine($"We can offer you the {hallName}");
            Console.WriteLine($"The price per person is {pricePerPerson:f2}$");
        }
    }
}
