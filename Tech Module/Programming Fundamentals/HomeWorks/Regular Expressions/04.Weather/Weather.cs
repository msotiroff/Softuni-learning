using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Weather
{
    public class City
    {
        public double AvgTemperature { get; set; }
        public string TypeOfWeather { get; set; }
    }
    class Weather
    {
        static void Main(string[] args)
        {
            Dictionary<string, City> allTowns = new Dictionary<string, City>();

            string pattern = @"([A-Z]{2})(\d+\.\d+)([A-Za-z]+)\|";
            Regex getWeather = new Regex(pattern);

            string inputLine = Console.ReadLine();

            while (inputLine != "end")
            {
                var matchedWeather = getWeather.Match(inputLine);

                if (matchedWeather.Success)
                {
                    string currentTownName = matchedWeather.Groups[1].Value.ToString();
                    double currentTownTemperature = double.Parse(matchedWeather.Groups[2].Value.ToString());
                    string currentTypeOfWeather = matchedWeather.Groups[3].Value.ToString();

                    if (! allTowns.ContainsKey(currentTownName))
                    {
                        allTowns[currentTownName] = new City();
                    }

                    allTowns[currentTownName].AvgTemperature = currentTownTemperature;
                    allTowns[currentTownName].TypeOfWeather = currentTypeOfWeather;
                }


                inputLine = Console.ReadLine();
            }


            foreach (var town in allTowns.OrderBy(t => t.Value.AvgTemperature))
            {
                Console.WriteLine($"{town.Key} => {town.Value.AvgTemperature:f2} => {town.Value.TypeOfWeather}");
            }



        }
    }
}
