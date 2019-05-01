using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallisticsTraining
{
    class BallisticsTraining
    {
        static void Main(string[] args)
        {
            int[] coordinatesOfAirplane = new int[2];
            coordinatesOfAirplane = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[] movementsOfGun = Console.ReadLine().Split().ToArray();

            int positionX = 0;
            int positionY = 0;

            for (int i = 0; i < movementsOfGun.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (movementsOfGun[i] == "up")
                    {
                        positionY += int.Parse(movementsOfGun[i + 1]);
                    }
                    else if (movementsOfGun[i] == "down")
                    {
                        positionY -= int.Parse(movementsOfGun[i + 1]);
                    }
                    else if (movementsOfGun[i] == "left")
                    {
                        positionX -= int.Parse(movementsOfGun[i + 1]);
                    }
                    else if (movementsOfGun[i] == "right")
                    {
                        positionX += int.Parse(movementsOfGun[i + 1]);
                    }
                }
            }

            Console.WriteLine($"firing at [{positionX}, {positionY}]");

            if (positionX == coordinatesOfAirplane[0] && positionY == coordinatesOfAirplane[1])
            {
                Console.WriteLine("got 'em!");
            }
            else
            {
                Console.WriteLine("better luck next time...");
            }
        }
    }
}
