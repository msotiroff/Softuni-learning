using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.HornetArmada
{
    public class Legion
    {
        public long LastActivity { get; set; }
        public Dictionary<string, long> Soldiers { get; set; }
    }
    class HornetArmada
    {
        static void Main(string[] args)
        {
            //        LegName   Properties
            Dictionary<string, Legion> allLegions = new Dictionary<string, Legion>();

            Regex getInputData = new Regex(@"(\d+)\s=\s(.+)\s->\s(.+):(\d+)");

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string inputLine = Console.ReadLine();
                var matched = getInputData.Match(inputLine);

                long currentLastActivity = long.Parse(matched.Groups[1].ToString());
                string currentLegionName = matched.Groups[2].ToString();
                string currentSoldierType = matched.Groups[3].ToString();
                long currentSoldierCount = long.Parse(matched.Groups[4].ToString());

                if (! allLegions.ContainsKey(currentLegionName))
                {
                    allLegions[currentLegionName] = new Legion()
                    {
                        LastActivity = 0,
                        Soldiers = new Dictionary<string, long>()
                    };
                    allLegions[currentLegionName].Soldiers.Add(currentSoldierType, 0);
                }
                if (! allLegions[currentLegionName].Soldiers.ContainsKey(currentSoldierType))
                {
                    allLegions[currentLegionName].Soldiers[currentSoldierType] = 0;
                }

                allLegions[currentLegionName].Soldiers[currentSoldierType] += currentSoldierCount;
                if (allLegions[currentLegionName].LastActivity < currentLastActivity)
                {
                    allLegions[currentLegionName].LastActivity = currentLastActivity;
                }
            }

            string[] printCommand = Console.ReadLine().Split('\\');
            if (printCommand.Length > 1)
            {
                long maxLastActivity = long.Parse(printCommand[0]);
                string neededSoldierType = printCommand[1];

                foreach (var legion in allLegions
                    .Where(l => l.Value.LastActivity < maxLastActivity)
                    .Where(s => s.Value.Soldiers.ContainsKey(neededSoldierType))
                    .OrderByDescending(l => l.Value.Soldiers[neededSoldierType]))
                {
                    string currentLegion = legion.Key;
                    
                        if (allLegions[currentLegion].Soldiers.ContainsKey(neededSoldierType))
                        {
                            long currentSoldierSum = allLegions[currentLegion].Soldiers[neededSoldierType];

                            Console.WriteLine($"{currentLegion} -> {currentSoldierSum}");
                        }
                    
                }
            }
            else
            {
                string neededSoldierType = printCommand[0];

                foreach (var legion in allLegions.OrderByDescending(l => l.Value.LastActivity))
                {
                    string currentLegion = legion.Key;

                    if (allLegions[currentLegion].Soldiers.ContainsKey(neededSoldierType))
                    {
                        Console.WriteLine($"{allLegions[currentLegion].LastActivity} : {currentLegion}");
                    }
                }
            }

        }
    }
}
