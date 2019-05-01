using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Logistics
{
    class Logistics
    {
        static void Main(string[] args)
        {
            int loads = int.Parse(Console.ReadLine());

            int byBus = 0;
            int byTrack = 0;
            int byTrain = 0;

            for (int i = 0; i < loads; i++)
            {
                int tonsPerEachLoad = int.Parse(Console.ReadLine());
                if (tonsPerEachLoad <= 3)
                {
                    byBus += tonsPerEachLoad;
                }
                else if (tonsPerEachLoad > 3 && tonsPerEachLoad <= 11)
                {
                    byTrack += tonsPerEachLoad;
                }
                else if (tonsPerEachLoad > 11)
                {
                    byTrain += tonsPerEachLoad;
                }
            }
            int allCargo = byBus + byTrack + byTrain;

            double pricePerTon = (byBus * 200.0 + byTrack * 175.0 + byTrain * 120.0) / allCargo * 1.0;

            Console.WriteLine("{0:f2}", pricePerTon);
            Console.WriteLine("{0:f2}%", byBus * 1.0 / allCargo * 100);
            Console.WriteLine("{0:f2}%", byTrack * 1.0 / allCargo * 100);
            Console.WriteLine("{0:f2}%", byTrain * 1.0 / allCargo * 100);
        }
    }
}
