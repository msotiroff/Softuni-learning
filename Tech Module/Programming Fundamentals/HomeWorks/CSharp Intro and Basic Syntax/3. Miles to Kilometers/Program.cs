using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Miles_to_Kilometers
{
    public class MilesToKilometers
    {
        public static void Main(string[] args)
        {
            double miles = double.Parse(Console.ReadLine());
            double kilometers = 1.60934 * miles;

            Console.WriteLine($"{kilometers:f2}");
        }
    }
}