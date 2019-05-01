using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HornetAssault
{
    class HornetAssault
    {
        static void Main(string[] args)
        {
            List<long> beehives = Console.ReadLine()
                .Split(' ')
                .Select(long.Parse)
                .ToList();
            List<long> eachHornetPower = Console.ReadLine()
                .Split(' ')
                .Select(long.Parse)
                .ToList();

            for (int i = 0; i < beehives.Count; i++)
            {
                long hornetSummedPower = eachHornetPower.Sum();

                if (hornetSummedPower > beehives[i])
                {
                    beehives.RemoveAt(i);
                    i--;
                }
                else if (hornetSummedPower < beehives[i])
                {
                    beehives[i] -= hornetSummedPower;
                    eachHornetPower.RemoveAt(0);
                }
                else
                {
                    beehives.RemoveAt(i);
                    i--;
                    eachHornetPower.RemoveAt(0);
                }
                if (beehives.Count == 0 || eachHornetPower.Count == 0)
                {
                    break;
                }
            }

            if (beehives.Count > 0)
            {
                Console.WriteLine(string.Join(" ", beehives));
            }
            else
            {
                Console.WriteLine(string.Join(" ", eachHornetPower));
            }


        }
    }
}
