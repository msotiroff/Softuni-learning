namespace _05.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            List<Team> allTeams = new List<Team>();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandParams = command.Split(';');

                string mainCommand = commandParams[0];
                string teamName = commandParams[1];

                try
                {
                    if (mainCommand == "Team")
                    {
                        // Add Team:
                        allTeams.Add(new Team(teamName));
                    }
                    else if (mainCommand == "Add")
                    {
                        //Add player:
                        // Input format: <PlayerName>;<Endurance>;<Sprint>;<Dribble>;<Passing>;<Shooting>

                        if (allTeams.Any(t => t.Name == teamName))
                        {
                            string playerName = commandParams[2];
                            int endurance = int.Parse(commandParams[3]);
                            int sprint = int.Parse(commandParams[4]);
                            int dribble = int.Parse(commandParams[5]);
                            int passing = int.Parse(commandParams[6]);
                            int shooting = int.Parse(commandParams[7]);

                            var teamToAddPlayer = allTeams.FirstOrDefault(t => t.Name == teamName);
                            var playerToBeAdded = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                            if (playerToBeAdded != null)
                            {
                                teamToAddPlayer.AddPlayer(playerToBeAdded);
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                    }
                    else if (mainCommand == "Remove")
                    {
                        //Remove player:
                        if (allTeams.Any(t => t.Name == teamName))
                        {
                            string playerName = commandParams[2];

                            var teamToRemovePlayer = allTeams
                                .FirstOrDefault(t => t.Name == teamName);

                            var playerToBeRemoved = teamToRemovePlayer
                                .Players
                                .FirstOrDefault(p => p.Name == playerName);

                            if (playerToBeRemoved == null)
                            {
                                Console.WriteLine($"Player {playerName} is not in {teamToRemovePlayer.Name} team.");
                            }
                            else
                            {
                                teamToRemovePlayer.RemovePlayer(playerToBeRemoved);
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                    }
                    else if (mainCommand == "Rating")
                    {
                        //print rating:
                        var team = allTeams.FirstOrDefault(t => t.Name == teamName);
                        if (team != null)
                        {
                            Console.WriteLine($"{team.Name} - {Math.Round((team.Rating))}");
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
