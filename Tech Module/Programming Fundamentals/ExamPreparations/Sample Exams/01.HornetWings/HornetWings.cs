using System;

namespace _01.HornetWings
{
    class HornetWings
    {
        static void Main(string[] args)
        {
            long wingFlaps = long.Parse(Console.ReadLine());
            double distanceFor1000flaps = double.Parse(Console.ReadLine());
            long endurance = long.Parse(Console.ReadLine());

            double distance = ((double)wingFlaps / 1000) * distanceFor1000flaps;

            double secondsWORest = (double)wingFlaps / 100;
            double secondsRest = (int)(wingFlaps / endurance) * 5;

            double totalSeconds = secondsWORest + secondsRest;

            Console.WriteLine($"{distance:f2} m.");
            Console.WriteLine($"{totalSeconds} s.");
        }
    }
}
