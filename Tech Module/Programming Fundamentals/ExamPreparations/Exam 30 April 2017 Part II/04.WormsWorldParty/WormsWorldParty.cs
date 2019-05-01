using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.WormsWorldParty
{
    class WormsWorldParty
    {
        static void Main(string[] args)
        {
            // Input format: {wormName} -> {teamName} -> {wormScore}
            
            string inputLine = Console.ReadLine();

            Dictionary<string, Dictionary<string, long>> allWorms =
                new Dictionary<string, Dictionary<string, long>>();

            while (inputLine != "quit")
            {
                string[] inputParameters = inputLine
                    .Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string currentWormName = inputParameters[0];
                string currentTeamName = inputParameters[1];
                long currentWormScore = long.Parse(inputParameters[2]);

                if (allWorms.Values.Any(x => x.Keys.Any(n => n == currentWormName)))
                {
                    inputLine = Console.ReadLine();
                    continue;
                }
                if (! allWorms.ContainsKey(currentTeamName))
                {
                    allWorms[currentTeamName] = new Dictionary<string, long>();
                }
                allWorms[currentTeamName][currentWormName] = currentWormScore;
                

                inputLine = Console.ReadLine();
            }

            int teamsCounter = 0;

            foreach (var team in allWorms
                .OrderByDescending(t => t.Value.Values.Sum())
                .ThenByDescending(t => t.Value.Values.Average()))
            {
                teamsCounter++;

                Console.WriteLine($"{teamsCounter}. Team: {team.Key} - {team.Value.Values.Sum()}");

                foreach (var worm in team.Value.OrderByDescending(w => w.Value))
                {
                    Console.WriteLine($"###{worm.Key} : {worm.Value}");
                }
                
            }

        }
    }
}
