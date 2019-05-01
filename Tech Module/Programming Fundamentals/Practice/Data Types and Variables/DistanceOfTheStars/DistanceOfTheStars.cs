using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace DistanceOfTheStars
{
    class DistanceOfTheStars
    {
        static void Main(string[] args)
        {
            decimal lightYear = 9450000000000;
            decimal proxima = (decimal)4.22 * lightYear;
            decimal milkyWay = 26000 * lightYear;
            decimal milkyWayDiameter = 100000 * lightYear;
            decimal edgeOfUniverse = 46500000000 * lightYear;
           
            Console.WriteLine(proxima.ToString("e2", CultureInfo.InvariantCulture));
            Console.WriteLine(milkyWay.ToString("e2", CultureInfo.InvariantCulture));
            Console.WriteLine(milkyWayDiameter.ToString("e2", CultureInfo.InvariantCulture));
            Console.WriteLine(edgeOfUniverse.ToString("e2", CultureInfo.InvariantCulture));

        }
    }
}
