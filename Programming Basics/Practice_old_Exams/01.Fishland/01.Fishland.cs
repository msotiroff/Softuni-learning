using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Fishland
{
    class Program
    {
        static void Main(string[] args)
        {
            double skumriaPrice = double.Parse(Console.ReadLine());
            double cacaPrice = double.Parse(Console.ReadLine());
            double kgPalamud = double.Parse(Console.ReadLine());
            double kgSafrid = double.Parse(Console.ReadLine());
            double kgMidi = double.Parse(Console.ReadLine());

            double palamud = kgPalamud * skumriaPrice * 1.6;
            double safrid = kgSafrid * 1.8 * cacaPrice;
            double midi = kgMidi * 7.5;

            double bill = palamud + safrid + midi;

            Console.WriteLine("{0:f2}", bill);
        }
    }
}
