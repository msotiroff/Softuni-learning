using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.HornetArmada
{
    class HornetArmada
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> legionsAndActivity = 
                new Dictionary<string, long>();

            Dictionary<string, Dictionary<string, long>> legionsAndSoldiers = 
                new Dictionary<string, Dictionary<string, long>>();


            int numberOfInputLines = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < numberOfInputLines; i++)
            {
                // Input format: 1 = BlackBeatles -> Soldier:2000
                //  {lastActivity} = {legionName} -> {soldierType}:{soldierCount}

                string[] inputParameters = Console.ReadLine()
                    .Split(new[] { " = ", " -> ", ":" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                long currentLastActivity = long.Parse(inputParameters[0]);
                string currentLegionName = inputParameters[1];
                string currentSoldierType = inputParameters[2];
                long currentSoldierCount = long.Parse(inputParameters[3]);

                if (! legionsAndSoldiers.ContainsKey(currentLegionName))
                {
                    legionsAndSoldiers[currentLegionName] = new Dictionary<string, long>();
                    legionsAndActivity[currentLegionName] = currentLastActivity;
                }
                if (! legionsAndSoldiers[currentLegionName].ContainsKey(currentSoldierType))
                {
                    legionsAndSoldiers[currentLegionName][currentSoldierType] = 0;
                }

                legionsAndSoldiers[currentLegionName][currentSoldierType] += currentSoldierCount;

                if (legionsAndActivity[currentLegionName] < currentLastActivity)
                {
                    legionsAndActivity[currentLegionName] = currentLastActivity;
                }
                
            }
            // Next input:
            string[] command = Console.ReadLine().Split('\\').ToArray();

            if (command.Length > 1)
            {
                long neededActivity = long.Parse(command[0]);
                string neededSoldierType = command[1];

                foreach (var legion in legionsAndSoldiers
                    .Where(l => l.Value.ContainsKey(neededSoldierType))
                    .OrderByDescending(l => l.Value[neededSoldierType]))
                {
                    if(legionsAndActivity[legion.Key] < neededActivity && legionsAndSoldiers[legion.Key].ContainsKey(neededSoldierType))
                    {
                        Console.WriteLine($"{legion.Key} -> {legion.Value[neededSoldierType]}");
                    }
                }
            }
            else
            {
                string neededSoldierType = command[0];

                foreach (var legion in legionsAndActivity.OrderByDescending(l => l.Value))
                {
                    if (legionsAndSoldiers[legion.Key].ContainsKey(neededSoldierType))
                    {
                        Console.WriteLine($"{legion.Value} : {legion.Key}");
                    }
                }
            }
            
            
        }
    }
}
