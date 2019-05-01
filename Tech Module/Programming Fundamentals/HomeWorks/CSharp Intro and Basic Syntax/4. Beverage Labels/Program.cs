using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Beverage_Labels
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int volume = int.Parse(Console.ReadLine());
            int energyContent = int.Parse(Console.ReadLine());
            int sugarContent = int.Parse(Console.ReadLine());

            double calories = (double)volume * energyContent / 100;
            double sugars = (double)volume * sugarContent / 100;

            Console.WriteLine($"{volume}ml {product}:");
            Console.WriteLine($"{calories}kcal, {sugars}g sugars");
        }
    }
}