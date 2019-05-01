using System;
using System.Globalization;

namespace _01.SinoTheWalker
{
    class SinoTheWalker
    {
        static void Main(string[] args)
        {
            DateTime sinoLeave = 
                DateTime.ParseExact(Console.ReadLine(), "HH:mm:ss", CultureInfo.InvariantCulture);
            long numberOfSteps = long.Parse(Console.ReadLine());
            long secondsForEachStep = long.Parse(Console.ReadLine());

            long tripTimeInSeconds = (numberOfSteps * secondsForEachStep) % 86400;
            DateTime timeArrival = sinoLeave.AddSeconds(tripTimeInSeconds);

            Console.WriteLine("Time Arrival: " + timeArrival.TimeOfDay);

        }
    }
}
