namespace P06.TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TruckTour
    {
        public static void Main(string[] args)
        {
            int numberOfPetrolPumps = int.Parse(Console.ReadLine());

            var allPumps = new Queue<Pump>();

            for (int pumpNumber = 0; pumpNumber < numberOfPetrolPumps; pumpNumber++)
            {
                var currentInput = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var amountOfPetrol = currentInput[0];
                var distanceToNextPump = currentInput[1];

                var currentPump = new Pump()
                {
                    Index = pumpNumber,
                    AmountOfPetrol = amountOfPetrol,
                    DistanceToNextPump = distanceToNextPump
                };

                allPumps.Enqueue(currentPump);
            }

            Pump startPump = null;
            int fuelTank = 0;

            for (int i = 0; i < numberOfPetrolPumps; i++)
            {
                var currentPump = allPumps.Dequeue();
                startPump = currentPump;
                allPumps.Enqueue(currentPump);

                fuelTank = currentPump.AmountOfPetrol;

                while (fuelTank >= currentPump.DistanceToNextPump)
                {
                    fuelTank -= currentPump.DistanceToNextPump;
                    currentPump = allPumps.Dequeue();
                    allPumps.Enqueue(currentPump);

                    if (currentPump.Index == startPump.Index)
                    {
                        Console.WriteLine(currentPump.Index);
                        return;
                    }

                    fuelTank += currentPump.AmountOfPetrol;
                }
            }
        }
    }
}
