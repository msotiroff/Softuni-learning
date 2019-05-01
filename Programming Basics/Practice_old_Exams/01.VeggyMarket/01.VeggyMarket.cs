using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.VeggyMarket
{
    class VeggyMarket
    {
        static void Main(string[] args)
        {
            double veggyPrice = double.Parse(Console.ReadLine()) / 1.94;
            double fruitPrice = double.Parse(Console.ReadLine()) / 1.94;
            int veggyKg = int.Parse(Console.ReadLine());
            int fruitKg = int.Parse(Console.ReadLine());

            double totalPrice = veggyPrice * veggyKg + fruitPrice * fruitKg;
            Console.WriteLine(totalPrice);

        }
    }
}
