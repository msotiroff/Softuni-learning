using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SoftUniWaterSupplies
{
    class SoftUniWaterSupplies
    {
        static void Main(string[] args)
        {
            double totalWater = double.Parse(Console.ReadLine());
            double[] bottles = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();
            double bottlesCapacity = double.Parse(Console.ReadLine());

            if (totalWater % 2 == 0)
            {
                List<int> indexes = new List<int>();
                for (int i = 0; i < bottles.Length; i++)
                {
                    indexes.Add(i);
                }

                for (int i = 0; i < bottles.Length; i++)
                {
                    double currentBottle = bottles[i];
                    double neededWaterForCurrBottle = bottlesCapacity - currentBottle;

                    if (neededWaterForCurrBottle <= totalWater)
                    {
                        totalWater -= neededWaterForCurrBottle;
                        bottles[i] += neededWaterForCurrBottle;
                        indexes.Remove(i);
                    }
                    else
                    {
                        Console.WriteLine($"We need more water!");
                        Console.WriteLine($"Bottles left: {bottles.Where(b => b < bottlesCapacity).Count()}");
                        Console.WriteLine($"With indexes: {string.Join(", ", indexes)}");
                        Console.WriteLine($"We need {bottles.Length * bottlesCapacity - bottles.Sum() - totalWater} more liters!");
                        break;
                    }

                    if (i == bottles.Length - 1)
                    {
                        Console.WriteLine("Enough water!");
                        Console.WriteLine($"Water left: {totalWater}l.");
                    }
                }
            }
            else
            {
                List<int> indexes = new List<int>();
                for (int i = 0; i < bottles.Length; i++)
                {
                    indexes.Add(i);
                }

                for (int i = bottles.Length - 1; i >= 0; i--)
                {
                    double currentBottle = bottles[i];
                    double neededWaterForCurrBottle = bottlesCapacity - currentBottle;

                    if (neededWaterForCurrBottle <= totalWater)
                    {
                        totalWater -= neededWaterForCurrBottle;
                        bottles[i] += neededWaterForCurrBottle;
                        indexes.RemoveAt(i);
                    }
                    else
                    {
                        indexes.Reverse();
                        Console.WriteLine($"We need more water!");
                        Console.WriteLine($"Bottles left: {bottles.Where(b => b < bottlesCapacity).Count()}");
                        Console.WriteLine($"With indexes: {string.Join(", ", indexes)}");
                        Console.WriteLine($"We need {bottles.Length * bottlesCapacity - bottles.Sum() - totalWater} more liters!");
                        break;
                    }

                    if (i == 0)
                    {
                        Console.WriteLine("Enough water!");
                        Console.WriteLine($"Water left: {totalWater}l.");
                    }
                }
            }
        }
    }
}
