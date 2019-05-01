using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Batteries
{
    class Program
    {
        static void Main(string[] args)
        {
            //You are in a battery manufacturing plant. 
            //Your task is to stress test the latest batch of batteries for longevity.
            //You will receive an array of doubles on the console(first line, space - separated),
            //indicating the capacities of the different batteries in the batch(in mAh).
            //On the next line, you will receive the usage per hour for each battery
            //as an array of doubles(second line, space - separated).
            //Next, you will receive the amount of hours you have to stress test each battery for (as an integer).
            //Each of the batteries drains by its capacity until either the testing hours are over,
            //or the battery dies(reaches 0 capacity).
            //Print the status of all the batteries at the end of the testing session(in percentage).
            //If any batteries die, along with the percentage, print how many hours it took.
            //The capacity and percentage are rounded to the 2nd decimal point.

            //Note: for this exercise, you are not allowed to use LINQ
            //for the actual algorithms (parsing the input with LINQ is okay).

            double[] batteryCapacity = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            double[] usagePerHour = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            int stressTestHours = int.Parse(Console.ReadLine());

            double[] startBatteryCapacity = new double[batteryCapacity.Length];
            for (int i = 0; i < batteryCapacity.Length; i++)
            {
                startBatteryCapacity[i] = batteryCapacity[i];
            }

            int[] hoursLastedCounter = new int[batteryCapacity.Length];

            for (int j = 0; j < stressTestHours; j++)
            {
                for (int i = 0; i < batteryCapacity.Length; i++)
                {
                    if (batteryCapacity[i] > 0)
                    {
                        hoursLastedCounter[i]++;
                    }
                    batteryCapacity[i] -= usagePerHour[i];
                }
            }

            for (int i = 0; i < batteryCapacity.Length; i++)
            {
                double currentBatteryPercent = (double)(batteryCapacity[i] / startBatteryCapacity[i] * 100);
                if (batteryCapacity[i] > 0)
                {
                    Console.WriteLine($"Battery {i + 1}: {batteryCapacity[i]:f2} mAh ({currentBatteryPercent:f2})%");
                }
                else
                {
                    Console.WriteLine($"Battery {i + 1}: dead (lasted {hoursLastedCounter[i]} hours)");
                }
            }
        }
    }
}
