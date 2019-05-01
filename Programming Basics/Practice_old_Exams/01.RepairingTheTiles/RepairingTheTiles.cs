using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.RepairingTheTiles
{
    class RepairingTheTiles
    {
        static void Main(string[] args)
        {
            int sideOfSquare = int.Parse(Console.ReadLine());

            int areaOfSquare = sideOfSquare * sideOfSquare;

            double tileWidth = double.Parse(Console.ReadLine());
            double tileLenght = double.Parse(Console.ReadLine());

            double tileArea = tileLenght * tileWidth;

            int benchWidth = int.Parse(Console.ReadLine());
            int benchLenght = int.Parse(Console.ReadLine());

            int benchArea = benchLenght * benchWidth;

            double areaForCovering = areaOfSquare - benchArea;


            double neededTiles = areaForCovering / tileArea;
            double neededTime = neededTiles * 0.2;

            Console.WriteLine(neededTiles);
            Console.WriteLine(neededTime);
        }
    }
}
