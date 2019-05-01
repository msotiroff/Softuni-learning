namespace P06.FootballTeamGenerator
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static Constants;

    public class StartUp
    {
        public static void Main()
        {
            var teams = new HashSet<Team>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                try
                {
                    var inputParams = inputLine
                        .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    var mainCommand = inputParams[0];
                    var teamName = inputParams[1];
                    string playerName;

                    switch (mainCommand)
                    {
                        case "Team":
                            var team = new Team(teamName);
                            teams.Add(team);
                            break;
                        case "Add":
                            var teamToAddPlayer = teams.FirstOrDefault(t => t.Name == teamName);
                            if (teamToAddPlayer == null)
                            {
                                Console.WriteLine(UnexistingTeam, teamName);
                            }
                            else
                            {
                                playerName = inputParams[2];
                                var stats = inputParams
                                    .Skip(3)
                                    .Select(int.Parse)
                                    .ToArray();

                                var playerStats = new Stats(stats[0], stats[1], stats[2], stats[3], stats[4]);

                                var player = new Player(playerName, playerStats);

                                teamToAddPlayer.AddPlayer(player);
                            }

                            break;
                        case "Remove":
                            playerName = inputParams[2];
                            var teamToRemovePlayer = teams.FirstOrDefault(t => t.Name == teamName);
                            if (teamToRemovePlayer == null)
                            {
                                Console.WriteLine(UnexistingTeam, teamName);
                            }
                            else
                            {
                                teamToRemovePlayer.RemovePlayer(playerName);
                            }
                            break;
                        case "Rating":
                            var teamToShowRating = teams.FirstOrDefault(t => t.Name == teamName);
                            if (teamToShowRating == null)
                            {
                                Console.WriteLine(UnexistingTeam, teamName);
                            }
                            else
                            {
                                Console.WriteLine($"{teamToShowRating.Name} - {Math.Round(teamToShowRating.Rating)}");
                            }
                            break;
                        default:
                            break;
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
