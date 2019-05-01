using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Entertrain
{
    class Program
    {
        static void Main(string[] args)
        {
            int locomotivePower = int.Parse(Console.ReadLine());

            List<int> allWagons = new List<int>();

            string inputLine = Console.ReadLine();

            while (inputLine != "All ofboard!")
            {
                int currentWagonWeight = int.Parse(inputLine);

                allWagons.Add(currentWagonWeight);

                if (allWagons.Sum() > locomotivePower)
                {
                    int average = (int)(allWagons.Average());

                    int indexToRemove = 0;
                    int smallestDifference = int.MaxValue;

                    for (int i = 0; i < allWagons.Count; i++)
                    {
                        if (Math.Abs(allWagons[i] - average) < smallestDifference)
                        {
                            smallestDifference = Math.Abs(allWagons[i] - average);
                            indexToRemove = i;
                        }
                    }

                    allWagons.RemoveAt(indexToRemove);
                }


                inputLine = Console.ReadLine();
            }

            allWagons.Insert(0, locomotivePower);

            allWagons.Reverse();

            Console.WriteLine(string.Join(" ", allWagons));
        }
    }
}
