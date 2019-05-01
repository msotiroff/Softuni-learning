using System;

namespace _20.Thea_the_Photographer
{
    class TheaPhotographer
    {
        static void Main(string[] args)
        {
            long picturesTaken = long.Parse(Console.ReadLine());
            long filterTimeInSeconds = long.Parse(Console.ReadLine());
            long filterFactor = long.Parse(Console.ReadLine());
            double goodPictures = Math.Ceiling((1.0 * filterFactor / 100) * picturesTaken);
            long goodPics = (long)goodPictures;
            long uploadTimeInSeconds = long.Parse(Console.ReadLine());

            long totalTimeInSeconds = picturesTaken * filterTimeInSeconds + goodPics * uploadTimeInSeconds;

            long days = totalTimeInSeconds / 86400;
            long hours = (totalTimeInSeconds - days * 86400) / 3600;
            long minutes = (totalTimeInSeconds - days * 86400 - hours * 3600) / 60;
            long seconds = totalTimeInSeconds - days * 86400 - hours * 3600 - minutes * 60;

            Console.WriteLine($"{days}:{hours:00}:{minutes:00}:{seconds:00}");
        }
    }
}
