using System;
using System.Linq;

namespace _5.Weather_Forecast
{
    class WeatherForecast
    {
        static void Main(string[] args)
        {
            string inputNumber = Console.ReadLine();
            string weather = string.Empty;

            if (inputNumber.Contains('.'))
            {
                weather = "Rainy";
            }
            else
            {
                long number = long.Parse(inputNumber);

                if (number > -128 && number < 127)
                {
                    weather = "Sunny";
                }
                else if (number > int.MinValue && number < int.MaxValue)
                {
                    weather = "Cloudy";
                }
                else
                {
                    weather = "Windy";
                }
            }

            Console.WriteLine(weather);
        }
    }
}
