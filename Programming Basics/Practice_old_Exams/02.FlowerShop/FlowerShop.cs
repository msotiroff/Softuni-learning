using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.FlowerShop
{
    class FlowerShop
    {
        static void Main(string[] args)
        {
            int magnolius = int.Parse(Console.ReadLine());
            int zumbulius = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int cactus = int.Parse(Console.ReadLine());
            double giftPrice = double.Parse(Console.ReadLine());

            double earning = (magnolius * 3.25 + zumbulius * 4 + roses * 3.5 + cactus * 8) * 0.95;
            double difference = Math.Abs(earning - giftPrice);

            if (earning >= giftPrice)
            {
                Console.WriteLine("She is left with {0} leva.", Math.Floor(difference));
            }
            else
            {
                Console.WriteLine("She will have to borrow {0} leva.", Math.Ceiling(difference));
            }

        }
    }
}
