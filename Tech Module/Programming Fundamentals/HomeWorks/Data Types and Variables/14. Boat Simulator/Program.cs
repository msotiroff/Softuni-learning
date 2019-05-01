using System;

namespace _14.Boat_Simulator
{
    class BoatSimulator
    {
        static void Main(string[] args)
        {
            char firstBoatName = char.Parse(Console.ReadLine());
            char secondBoatName = char.Parse(Console.ReadLine());
            int numberOfInputs = int.Parse(Console.ReadLine());

            int firstBoatTiles = 0;
            int secondBoatTiles = 0;
            bool hasAWinner = false;

            for (int i = 1; i <= numberOfInputs; i++)
            {
                string currentInput = Console.ReadLine();
                int currentSpeed = currentInput.Length;

                if (currentInput == "UPGRADE")
                {
                    firstBoatName = Convert.ToChar(firstBoatName + 3);
                    secondBoatName = Convert.ToChar(secondBoatName + 3);
                }
                else
                {
                    if (i % 2 != 0)
                    {
                        firstBoatTiles += currentSpeed;
                        if (firstBoatTiles >= 50)
                        {
                            Console.WriteLine(firstBoatName);
                            hasAWinner = true;
                            break;
                        }
                    }
                    else
                    {
                        secondBoatTiles += currentSpeed;
                        if (secondBoatTiles >= 50)
                        {
                            Console.WriteLine(secondBoatName);
                            hasAWinner = true;
                            break;
                        }
                    }
                }
                
            }

            if (! hasAWinner)
            {
                Console.WriteLine(firstBoatTiles > secondBoatTiles ? $"{firstBoatName}" : $"{secondBoatName}");
            }

        }
    }
}
