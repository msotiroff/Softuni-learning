using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.HornetWings
{
    class Program
    {
        static void Main(string[] args)
        {
            int wingFlaps = int.Parse(Console.ReadLine());  // hornet makes 100 flapes per second
            double distanceFor1000flaps = double.Parse(Console.ReadLine());  // in meters
            int endurance = int.Parse(Console.ReadLine()); // how many flaps befor rest

            double distance = ((double)wingFlaps / 1000) * distanceFor1000flaps;

            double timeInSeconds = wingFlaps / 100.0 + (wingFlaps / endurance) * 5;

            Console.WriteLine($"{distance:f2} m.");

            Console.WriteLine($"{timeInSeconds} s.");
        }
    }
}
