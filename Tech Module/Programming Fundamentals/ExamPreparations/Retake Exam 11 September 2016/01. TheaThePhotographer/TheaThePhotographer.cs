using System;

namespace _01.TheaThePhotographer
{
    class TheaThePhotographer
    {
        static void Main(string[] args)
        {
            long picturesTaken = long.Parse(Console.ReadLine());
            long filterTimeInSeconds = long.Parse(Console.ReadLine());
            long filterFactor = long.Parse(Console.ReadLine());
            long uploadTimeInSeconds = long.Parse(Console.ReadLine());

            double filteredPics = Math.Ceiling(1.0 * picturesTaken * filterFactor / 100);

            long totalTime = picturesTaken * filterTimeInSeconds + (int)filteredPics * uploadTimeInSeconds;

            long daysNeeded = totalTime / 86400;
            long hoursNeeded = (totalTime - daysNeeded * 86400) / 3600;
            long minutesNeeded = (totalTime - daysNeeded * 86400 - hoursNeeded * 3600) / 60;
            long secondsNeeded = (totalTime - daysNeeded * 86400 - hoursNeeded * 3600 - minutesNeeded * 60);

            
            Console.WriteLine($"{daysNeeded}:{hoursNeeded:00}:{minutesNeeded:00}:{secondsNeeded:00}");

        }
    }
}
