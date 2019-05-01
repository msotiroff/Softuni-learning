using System;
using System.Globalization;

namespace _01.SinoTheWalker
{
    class SinoTheWalker
    {
        static void Main(string[] args)
        {
            string leaveTime = Console.ReadLine();
            DateTime sinoLeave = DateTime.ParseExact(leaveTime, "HH:mm:ss", CultureInfo.InvariantCulture);

            int numberOfSteps = int.Parse(Console.ReadLine()) % (60 * 60 * 24);
            int secondsPerStep = int.Parse(Console.ReadLine()) % (60 * 60 * 24);
            long allSecondsNeeded = (numberOfSteps * secondsPerStep);

            DateTime arrivalTime = sinoLeave.AddSeconds(allSecondsNeeded);

            string result = arrivalTime.TimeOfDay.ToString();

            Console.WriteLine("Time Arrival: " + result);
        }
    }
}
