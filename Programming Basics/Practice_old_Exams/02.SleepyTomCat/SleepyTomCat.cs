using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SleepyTomCat
{
    class SleepyTomCat
    {
        static void Main(string[] args)
        {
            int daysOff = int.Parse(Console.ReadLine());

            int playingMinutesInDayoff = daysOff * 127;
            int playingMinutesInWorkdays = (365 - daysOff) * 63;

            int allPlayingMinutes = playingMinutesInDayoff + playingMinutesInWorkdays;
            int difference = Math.Abs(30000 - allPlayingMinutes);

            int diffHours = difference / 60;
            int diffMinutes = difference % 60;

            if (allPlayingMinutes <= 30000)
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{diffHours} hours and {diffMinutes} minutes less for play");
            }
            else
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{diffHours} hours and {diffMinutes} minutes more for play");
            }

        }
    }
}
