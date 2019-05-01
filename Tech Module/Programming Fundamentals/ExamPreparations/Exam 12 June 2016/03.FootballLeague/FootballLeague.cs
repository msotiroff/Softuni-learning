using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.FootballLeague
{
    class FootballLeague
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<long>> allTeams =       // [0] -> Goals  [1] -> Points
                new Dictionary<string, List<long>>();

            string key = Console.ReadLine();

            string inputLine = Console.ReadLine();

            string pattern =
                Regex.Escape(key) + @"([A-Za-z]*?)" + Regex.Escape(key) +
                @".*" + Regex.Escape(key) + @"([A-Za-z]*?)" + Regex.Escape(key);

            Regex getTeamName = new Regex(pattern);

            Regex getResult = new Regex(@"(\d+):(\d+)$");

            while (inputLine != "final")
            {
                Match opposideTeamNames = getTeamName.Match(inputLine);
                Match result = getResult.Match(inputLine);

                string firstTeamName = string.Empty;
                string secondTeamName = string.Empty;
                long firstTeamGoals = long.Parse(result.Groups[1].Value.ToString());
                long seconTeamGoals = long.Parse(result.Groups[2].Value.ToString());
                long firstTeamPoints = 1;
                long secondTeamPoints = 1;

                GetTeamNames(opposideTeamNames, ref firstTeamName, ref secondTeamName);

                GetTeamPointScores(firstTeamGoals, seconTeamGoals, ref firstTeamPoints, ref secondTeamPoints);

                FillScoreBoard(allTeams, firstTeamName, secondTeamName, firstTeamGoals, 
                    seconTeamGoals, firstTeamPoints, secondTeamPoints);

                inputLine = Console.ReadLine();
            }

            PrintRanking(allTeams);

        }

        public static void FillScoreBoard(Dictionary<string, List<long>> allTeams, string firstTeamName, 
            string secondTeamName, long firstTeamGoals, long seconTeamGoals, long firstTeamPoints, long secondTeamPoints)
        {
            if (!allTeams.ContainsKey(firstTeamName))
            {
                allTeams[firstTeamName] = new List<long>();
                allTeams[firstTeamName].Add(0);
                allTeams[firstTeamName].Add(0);
            }
            allTeams[firstTeamName][0] += firstTeamGoals;
            allTeams[firstTeamName][1] += firstTeamPoints;

            if (!allTeams.ContainsKey(secondTeamName))
            {
                allTeams[secondTeamName] = new List<long>();
                allTeams[secondTeamName].Add(0);
                allTeams[secondTeamName].Add(0);
            }
            allTeams[secondTeamName][0] += seconTeamGoals;
            allTeams[secondTeamName][1] += secondTeamPoints;
        }

        public static void GetTeamPointScores(long firstTeamGoals, long seconTeamGoals, 
            ref long firstTeamPoints, ref long secondTeamPoints)
        {
            if (firstTeamGoals > seconTeamGoals)
            {
                firstTeamPoints = 3;
                secondTeamPoints = 0;
            }
            else if (firstTeamGoals < seconTeamGoals)
            {
                firstTeamPoints = 0;
                secondTeamPoints = 3;
            }
        }

        public static void GetTeamNames(Match opposideTeamNames, ref string firstTeamName, ref string secondTeamName)
        {
            string firstTeamOppName = opposideTeamNames.Groups[1].Value.ToString().ToUpper();
            for (int i = firstTeamOppName.Length - 1; i >= 0; i--)
            {
                firstTeamName += firstTeamOppName[i];
            }
            string secondTeamOppName = opposideTeamNames.Groups[2].Value.ToString().ToUpper();
            for (int i = secondTeamOppName.Length - 1; i >= 0; i--)
            {
                secondTeamName += secondTeamOppName[i];
            }
        }

        public static void PrintRanking(Dictionary<string, List<long>> allTeams)
        {
            int pointScoreCounter = 0;

            Console.WriteLine("League standings:");
            foreach (var team in allTeams.OrderByDescending(t => t.Value[1]).ThenBy(t => t.Key))
            {
                pointScoreCounter++;
                Console.WriteLine($"{pointScoreCounter}. {team.Key} {team.Value[1]}");
            }

            int goalScoreCounter = 0;

            Console.WriteLine("Top 3 scored goals:");
            foreach (var team in allTeams.OrderByDescending(t => t.Value[0]).ThenBy(t => t.Key))
            {
                goalScoreCounter++;
                Console.WriteLine($"- {team.Key} -> {team.Value[0]}");
                if (goalScoreCounter == 3)
                {
                    break;
                }
            }
        }
    }
}
