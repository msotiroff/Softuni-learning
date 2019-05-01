namespace P06.TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TruckTour
    {
        static void Main(string[] args)
        {
            int countOfPumps = int.Parse(Console.ReadLine());

            var allPumps = new Queue<PetrolPump>();

            for (int i = 0; i < countOfPumps; i++)
            {
                var pumpArgs = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();

                var pump = new PetrolPump(i, pumpArgs.First(), pumpArgs.Last());

                allPumps.Enqueue(pump);
            }

            PetrolPump startPump;
            long fuelTank = 0;

            for (int id = 0; id < countOfPumps; id++)
            {
                var currentPump = allPumps.Dequeue();

                startPump = currentPump;

                allPumps.Enqueue(currentPump);

                fuelTank = currentPump.AmountOfPetrol;

                while (fuelTank >= currentPump.Distance)
                {
                    fuelTank -= currentPump.Distance;
                    currentPump = allPumps.Dequeue();
                    allPumps.Enqueue(currentPump);

                    if (currentPump.Id == startPump.Id)
                    {
                        Console.WriteLine(currentPump.Id);
                        Environment.Exit(0);
                    }

                    fuelTank += currentPump.AmountOfPetrol;
                }
            }
        }
    }

    public class PetrolPump
    {
        public PetrolPump(int id, long petrol, long distance)
        {
            this.Id = id;
            this.AmountOfPetrol = petrol;
            this.Distance = distance;
        }

        public int Id { get; set; }

        public long AmountOfPetrol { get; set; }

        public long Distance { get; set; }
    }
}
