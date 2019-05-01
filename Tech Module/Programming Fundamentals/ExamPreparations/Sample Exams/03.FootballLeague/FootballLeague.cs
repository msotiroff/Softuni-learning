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
            //        TeamName    [0]-goals, [1]-points
            Dictionary<string, List<long>> scoreBoard = new Dictionary<string, List<long>>();

            string keyDelimiter = Console.ReadLine();
            string pattern =
                  @".*" + Regex.Escape(keyDelimiter)
                + @"([A-Za-z]*)" + Regex.Escape(keyDelimiter)
                + @".*\s.*"
                + Regex.Escape(keyDelimiter)
                + @"([A-Za-z]*)"
                + Regex.Escape(keyDelimiter)
                + @".*\s(\d+):(\d+)";

            Regex takeData = new Regex(pattern);

            string inputLine = Console.ReadLine();

            while (inputLine != "final")
            {
                var currentMatch = takeData.Match(inputLine);

                string firstTeamName = ReverceAndUp(currentMatch.Groups[1].ToString());
                string secondTeamName = ReverceAndUp(currentMatch.Groups[2].ToString());
                long firstTeamGoals = long.Parse(currentMatch.Groups[3].ToString());
                long secondTeamGoals = long.Parse(currentMatch.Groups[4].ToString());
                long firstTeamPoints = 1;
                long secondTeamPoints = 1;

                if (!scoreBoard.ContainsKey(firstTeamName))
                {
                    scoreBoard[firstTeamName] = new List<long>();
                    scoreBoard[firstTeamName].Add(0);
                    scoreBoard[firstTeamName].Add(0);
                }
                if (!scoreBoard.ContainsKey(secondTeamName))
                {
                    scoreBoard[secondTeamName] = new List<long>();
                    scoreBoard[secondTeamName].Add(0);
                    scoreBoard[secondTeamName].Add(0);
                }
                scoreBoard[firstTeamName][0] += firstTeamGoals;
                scoreBoard[secondTeamName][0] += secondTeamGoals;

                if (firstTeamGoals > secondTeamGoals)
                {
                    firstTeamPoints = 3;
                    secondTeamPoints = 0;
                }
                else if (secondTeamGoals > firstTeamGoals)
                {
                    firstTeamPoints = 0;
                    secondTeamPoints = 3;
                }

                scoreBoard[firstTeamName][1] += firstTeamPoints;
                scoreBoard[secondTeamName][1] += secondTeamPoints;

                inputLine = Console.ReadLine();
            }

            PrintRanking(scoreBoard);

        }

        public static void PrintRanking(Dictionary<string, List<long>> scoreBoard)
        {
            Console.WriteLine("League standings:");
            int placeCounter = 0;
            foreach (var team in scoreBoard.OrderByDescending(t => t.Value[1]).ThenBy(t => t.Key))
            {
                placeCounter++;
                Console.WriteLine($"{placeCounter}. {team.Key} {team.Value[1]}");
            }

            Console.WriteLine("Top 3 scored goals:");
            int goalScoreCounter = 0;
            foreach (var team in scoreBoard.OrderByDescending(t => t.Value[0]).ThenBy(t => t.Key))
            {
                goalScoreCounter++;
                Console.WriteLine($"- {team.Key} -> {team.Value[0]}");
                if (goalScoreCounter == 3)
                {
                    break;
                }
            }
        }

        public static string ReverceAndUp(string teamName)
        {
            string result = string.Empty;

            for (int i = teamName.Length - 1; i >= 0; i--)
            {
                result += teamName[i].ToString().ToUpper();
            }

            return result;
        }
    }
}
