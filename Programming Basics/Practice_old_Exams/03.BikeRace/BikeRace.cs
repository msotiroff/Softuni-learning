using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.BikeRace
{
    class BikeRace
    {
        static void Main(string[] args)
        {
            int juniorRacers = int.Parse(Console.ReadLine());
            int seniorRacers = int.Parse(Console.ReadLine());
            string trace = Console.ReadLine().ToLower();

            double juniorTaxes = 0;
            double seniorTaxes = 0;

            if (trace == "trail")
            {
                juniorTaxes = 5.5 * juniorRacers;
                seniorTaxes = 7 * seniorRacers;
            }
            else if (trace == "cross-country")
            {
                juniorTaxes = 8 * juniorRacers;
                seniorTaxes = 9.5 * seniorRacers;
                if (juniorRacers + seniorRacers >= 50)
                {
                    juniorTaxes *= 0.75;
                    seniorTaxes *= 0.75;
                }
            }
            else if (trace == "downhill")
            {
                juniorTaxes = 12.25 * juniorRacers;
                seniorTaxes = 13.75 * seniorRacers;
            }
            else if (trace == "road")
            {
                juniorTaxes = 20 * juniorRacers;
                seniorTaxes = 21.5 * seniorRacers;
            }

            double allTaxes = juniorTaxes + seniorTaxes;

            double netSum = allTaxes * 0.95;

            Console.WriteLine("{0:f2}", netSum);
        }
    }
}
