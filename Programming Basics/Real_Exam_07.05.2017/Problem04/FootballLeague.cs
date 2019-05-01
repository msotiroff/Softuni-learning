using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem04
{
    class FootballLeague
    {
        static void Main(string[] args)
        {
            double stadionCapacity = double.Parse(Console.ReadLine());
            double fans = double.Parse(Console.ReadLine());

            double sectorA = 0.0;
            double sectorB = 0.0;
            double sectorV = 0.0;
            double sectorG = 0.0;

            for (int i = 0; i < fans; i++)
            {
                string currentSector = Console.ReadLine();

                if (currentSector == "A")
                {
                    sectorA++;
                }
                else if (currentSector == "B")
                {
                    sectorB++;
                }
                else if (currentSector == "V")
                {
                    sectorV++;
                }
                else if (currentSector == "G")
                {
                    sectorG++;
                }
            }

            Console.WriteLine("{0:f2}%", sectorA / fans * 100);
            Console.WriteLine("{0:f2}%", sectorB / fans * 100);
            Console.WriteLine("{0:f2}%", sectorV / fans * 100);
            Console.WriteLine("{0:f2}%", sectorG / fans * 100);
            Console.WriteLine("{0:f2}%", fans / stadionCapacity * 100);
        }
    }
}
