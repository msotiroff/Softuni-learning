using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Distance
{
    class Distance
    {
        static void Main(string[] args)
        {
            int firstSpeed = int.Parse(Console.ReadLine());
            double firstTimeInHours = double.Parse(Console.ReadLine()) / 60;
            double secondTimeInHours = double.Parse(Console.ReadLine()) / 60;
            double thirdTimeInHours = double.Parse(Console.ReadLine()) / 60;

            double firstDistance = 1.0 * firstSpeed * firstTimeInHours;
            double secondDistance = 1.1 * firstSpeed * secondTimeInHours;
            double thirdDistance = 1.1 * firstSpeed * 0.95 * thirdTimeInHours;

            double distance = firstDistance + secondDistance + thirdDistance;

            Console.WriteLine("{0:f2}", distance);

        }
    }
}
