using System;

namespace _4.Tourist_Information
{
    class TouristInformation
    {
        static void Main(string[] args)
        {
            string initialUnit = Console.ReadLine();
            double value = double.Parse(Console.ReadLine());
            double coptyOfValue = value;
            string convertedUnit = string.Empty;
            double convertedValue = 0;

            if (initialUnit == "miles")
            {
                convertedUnit = "kilometers";
                convertedValue = value * 1.6;
            }
            else if (initialUnit == "inches")
            {
                convertedUnit = "centimeters";
                convertedValue = 2.54 * value;
            }
            else if (initialUnit == "feet")
            {
                convertedUnit = "centimeters";
                convertedValue = 30 * value;
            }
            else if (initialUnit == "yards")
            {
                convertedUnit = "meters";
                convertedValue = 0.91 * value;
            }
            else if (initialUnit == "gallons")
            {
                convertedUnit = "liters";
                convertedValue = 3.8 * value;
            }

            Console.WriteLine($"{coptyOfValue} {initialUnit} = {convertedValue:f2} {convertedUnit}");
        }
    }
}
