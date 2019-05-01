using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01
{
    class AlcocholMarket
    {
        static void Main(string[] args)
        {
            double whiskeyPricePerLiter = double.Parse(Console.ReadLine());

            double beerQuantity = double.Parse(Console.ReadLine());
            double wineQuantity = double.Parse(Console.ReadLine());
            double rakiaQuantity = double.Parse(Console.ReadLine());
            double whiskeyQuantity = double.Parse(Console.ReadLine());

            double whiskeyCosts = whiskeyQuantity * whiskeyPricePerLiter;
            double rakiaCosts = whiskeyPricePerLiter / 2 * rakiaQuantity;
            double wineCosts = 0.6 * (whiskeyPricePerLiter / 2) * wineQuantity;
            double beerCosts = 0.2 * (whiskeyPricePerLiter / 2) * beerQuantity;

            double allCosts = whiskeyCosts + rakiaCosts + wineCosts + beerCosts;

            Console.WriteLine("{0:f2}", allCosts);


        }
    }
}
