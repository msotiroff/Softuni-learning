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
            string keyDelimiter = Console.ReadLine();
            int delimiterLenght = keyDelimiter.Length;

            Regex gameResult = new Regex(@"(\d+):(\d+)");

            Dictionary<string, List<long>> allTeams = new Dictionary<string, List<long>>();

            string input = Console.ReadLine();

            while (input != "final")
            {
                string[] inputParams = input.Split().ToArray();

                string hostName = GetHostName(keyDelimiter, delimiterLenght, inputParams);

                string guestName = GetGuestName(keyDelimiter, delimiterLenght, inputParams);

                var matchedResult = gameResult.Match(input);
                long hostCurrentGoals = long.Parse(matchedResult.Groups[1].ToString());            // First team goalscore
                long guestCurrentGoals = long.Parse(matchedResult.Groups[2].ToString());           // Second team goal score

                int hostCurrentPoints = 0;                                                          // each team current points
                int guestCurrentPoint = 0;                                                          // each team current points

                if (hostCurrentGoals > guestCurrentGoals)
                {
                    hostCurrentPoints = 3;
                }
                else if (hostCurrentGoals < guestCurrentGoals)
                {
                    guestCurrentPoint = 3;
                }
                else
                {
                    hostCurrentPoints = 1;
                    guestCurrentPoint = 1;
                }
                ///////////////   Teams properties token !!! ///////////////////////

                // [0] -> Goals     [1] -> Points

                if (!allTeams.ContainsKey(hostName))
                {
                    allTeams[hostName] = new List<long>();
                    allTeams[hostName].Add(0);
                    allTeams[hostName].Add(0);
                }
                allTeams[hostName][0] += hostCurrentGoals;
                allTeams[hostName][1] += hostCurrentPoints;

                if (!allTeams.ContainsKey(guestName))
                {
                    allTeams[guestName] = new List<long>();
                    allTeams[guestName].Add(0);
                    allTeams[guestName].Add(0);
                }
                allTeams[guestName][0] += guestCurrentGoals;
                allTeams[guestName][1] += guestCurrentPoint;


                input = Console.ReadLine();
            }
            

            PrintRanking(allTeams);
        }

        public static void PrintRanking(Dictionary<string, List<long>> allTeams)
        {
            Console.WriteLine("League standings:");
            int counter = 0;
            foreach (var team in allTeams.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key))
            {
                counter++;
                Console.WriteLine($"{counter}. {team.Key} {team.Value[1]}");
            }

            Console.WriteLine("Top 3 scored goals:");

            int goalChampCounter = 1;

            foreach (var team in allTeams.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key))
            {
                Console.WriteLine($"- {team.Key} -> {team.Value[0]}");
                goalChampCounter++;
                if (goalChampCounter > 3)
                {
                    break;
                }
            }
        }

        public static string GetGuestName(string keyDelimiter, int delimiterLenght, string[] inputParams)
        {
            int secondTeamStartIndex = inputParams[1].IndexOf(keyDelimiter) + delimiterLenght;
            int secondTeamEndIndex = inputParams[1].LastIndexOf(keyDelimiter);
            int secondTeamNameLenght = secondTeamEndIndex - secondTeamStartIndex;

            string primeGuest = inputParams[1].Substring(secondTeamStartIndex, secondTeamNameLenght).ToUpper();
            string guestName = string.Empty;                                                        // Second team name
            for (int i = primeGuest.Length - 1; i >= 0; i--)
            {
                guestName += primeGuest[i];
            }

            return guestName;
        }

        public static string GetHostName(string keyDelimiter, int delimiterLenght, string[] inputParams)
        {
            int firstTeamStartIndex = inputParams[0].IndexOf(keyDelimiter) + delimiterLenght;
            int firstTeamEndIndex = inputParams[0].LastIndexOf(keyDelimiter);
            int firstTeamNameLenght = firstTeamEndIndex - firstTeamStartIndex;

            string primeHost = inputParams[0].Substring(firstTeamStartIndex, firstTeamNameLenght).ToUpper();
            string hostName = string.Empty;                                                         // First team name
            for (int i = primeHost.Length - 1; i >= 0; i--)
            {
                hostName += primeHost[i];
            }

            return hostName;
        }
    }
}
