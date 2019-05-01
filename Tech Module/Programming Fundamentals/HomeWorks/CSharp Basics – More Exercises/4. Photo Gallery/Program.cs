using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _4.Photo_Gallery
{
    class PhotoGallery
    {
        static void Main(string[] args)
        {
            string photoNumber = Console.ReadLine();
            while (photoNumber.Length < 4)
            {
                photoNumber = "0" + photoNumber;
            }

            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            int hour = int.Parse(Console.ReadLine());
            int minute = int.Parse(Console.ReadLine());

            string dateTimeResult = $"{day:00}/{month:00}/{year} {hour:00}:{minute:00}";
            //DateTime imageDate = new DateTime(year, month, day, hour, minute, 0);
            //string imageDateToPrint = imageDate.ToString("dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture);

            double sizeInBytes = double.Parse(Console.ReadLine());
            double sizeToPrint = 0;
            string sizeUnit = "B";
            if (sizeInBytes >= 1000 && sizeInBytes < 1000000)
            {
                sizeToPrint = 1.0 * sizeInBytes / 1000;
                sizeUnit = "KB";
            }
            else if (sizeInBytes >= 1000000)
            {
                sizeToPrint = 1.0 * sizeInBytes / 1000000;
                sizeUnit = "MB";
            }
            else
            {
                sizeToPrint = sizeInBytes;
            }


            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            string resolutionType = string.Empty;
            if (width > height)
            {
                resolutionType = "landscape";
            }
            else if (width < height)
            {
                resolutionType = "portrait";
            }
            else
            {
                resolutionType = "square";
            }

            Console.WriteLine($"Name: DSC_{photoNumber}.jpg");
            Console.WriteLine($"Date Taken: {dateTimeResult}");
            Console.WriteLine($"Size: {sizeToPrint}{sizeUnit}");
            Console.WriteLine($"Resolution: {width}x{height} ({resolutionType})");

        }
    }
}
