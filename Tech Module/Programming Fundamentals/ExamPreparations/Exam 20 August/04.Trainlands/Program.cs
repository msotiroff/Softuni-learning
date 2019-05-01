using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Trainlands
{
    class Program
    {
        static void Main(string[] args)
        {
            //         TrainName        WagonName  Power
            Dictionary<string, Dictionary<string, long>> allTrains
                = new Dictionary<string, Dictionary<string, long>>();

            string inputLine = Console.ReadLine();

            while (inputLine != "It's Training Men!")
            {
                string[] inputParameters = inputLine
                    .Split(new[] { " -> ", " : ", " = " }, StringSplitOptions.RemoveEmptyEntries);

                string currentTrainName = inputParameters[0];

                if (inputParameters.Length == 3)
                {
                    string currentWagon = inputParameters[1];
                    long currentPower = long.Parse(inputParameters[2]);

                    if (!allTrains.ContainsKey(currentTrainName))
                    {
                        allTrains[currentTrainName] = new Dictionary<string, long>();
                    }

                    allTrains[currentTrainName].Add(currentWagon, currentPower);
                }
                else
                {
                    string otherTrainName = inputParameters[1];

                    if (inputLine.Contains(" = "))
                    {
                        if (!allTrains.ContainsKey(currentTrainName))
                        {
                            allTrains[currentTrainName] = new Dictionary<string, long>();
                        }

                        allTrains[currentTrainName].Clear();

                        foreach (var wagons in allTrains[otherTrainName])
                        {
                            allTrains[currentTrainName].Add(wagons.Key, wagons.Value);
                        }
                    }
                    else
                    {
                        if (!allTrains.ContainsKey(currentTrainName))
                        {
                            allTrains[currentTrainName] = new Dictionary<string, long>();
                        }

                        foreach (var wagons in allTrains[otherTrainName])
                        {
                            allTrains[currentTrainName].Add(wagons.Key, wagons.Value);
                        }

                        allTrains.Remove(otherTrainName);
                    }
                }


                inputLine = Console.ReadLine();
            }


            foreach (var train in allTrains
                .OrderByDescending(t => t.Value.Values.Sum())
                .ThenBy(t => t.Value.Count()))
            {
                Console.WriteLine($"Train: {train.Key}");

                foreach (var wagon in allTrains[train.Key]
                    .OrderByDescending(w => w.Value))
                {
                    Console.WriteLine($"###{wagon.Key} - {wagon.Value}");
                }
            }
        }
    }
}
