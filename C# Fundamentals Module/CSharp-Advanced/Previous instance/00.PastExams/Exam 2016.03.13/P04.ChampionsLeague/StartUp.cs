namespace P04.ChampionsLeague
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var allTeams = new Dictionary<string, TeamInfo>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "stop")
            {
                var inputArgs = inputLine.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                var host = inputArgs[0].Trim();
                var guest = inputArgs[1].Trim();

                var firstMatchGoals = inputArgs[2].Split(':').Select(int.Parse).ToArray();
                var secondMatchGoals = inputArgs[3].Split(':').Select(int.Parse).ToArray();

                if (!allTeams.ContainsKey(host))
                {
                    allTeams[host] = new TeamInfo();
                }
                if (!allTeams.ContainsKey(guest))
                {
                    allTeams[guest] = new TeamInfo();
                }

                allTeams[host].Opponents.Add(guest);
                allTeams[guest].Opponents.Add(host);

                var hostGoals = firstMatchGoals.First() + secondMatchGoals.Last();
                var guestGoals = firstMatchGoals.Last() + secondMatchGoals.First();

                if (hostGoals > guestGoals)
                {
                    allTeams[host].Wins++;
                }
                else if (hostGoals < guestGoals)
                {
                    allTeams[guest].Wins++;
                }
                else
                {
                    if (secondMatchGoals.Last() > firstMatchGoals.Last())
                    {
                        allTeams[host].Wins++;
                    }
                    else
                    {
                        allTeams[guest].Wins++;
                    }
                }
            }

            foreach (var team in allTeams.OrderByDescending(t => t.Value.Wins).ThenBy(t => t.Key))
            {
                Console.WriteLine(team.Key);

                Console.WriteLine($"- Wins: {team.Value.Wins}");

                Console.WriteLine($"- Opponents: {string.Join(", ", team.Value.Opponents.OrderBy(op => op))}");
            }
        }
    }
}