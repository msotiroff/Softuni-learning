using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.HotelRoom
{
    class HotelRoom
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine().ToLower();
            int nights = int.Parse(Console.ReadLine());

            double studioPrice = 0;
            double apartmentPrice = 0;
            
            if (month == "may" || month == "october")
            {
                studioPrice = 50;
                apartmentPrice = 65;
                if (nights > 7 && nights <= 14)
                {
                    studioPrice *= 0.95;
                }
                else if (nights > 14)
                {
                    studioPrice *= 0.7;
                    apartmentPrice *= 0.9;
                }
            }
            else if (month == "june" || month == "september")
            {
                studioPrice = 75.2;
                apartmentPrice = 68.7;
                if (nights > 14)
                {
                    studioPrice *= 0.8;
                    apartmentPrice *= 0.9;
                }
            }
            else
            {
                studioPrice = 76;
                apartmentPrice = 77;
                if (nights > 14)
                {
                    apartmentPrice *= 0.9;
                }
            }

            Console.WriteLine("Apartment: {0:f2} lv.", apartmentPrice * nights);
            Console.WriteLine("Studio: {0:f2} lv.", studioPrice * nights);
        }
    }
}
