using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.TeamworkProjects
{
    class TeamworkProjects
    {
        static void Main(string[] args)
        {
            int numberOfRegisterInputs = int.Parse(Console.ReadLine());

            List<Team> allTeams = new List<Team>();

            for (int i = 0; i < numberOfRegisterInputs; i++)
            {
                RegisterTeams(allTeams);
            }


            string joinProcedure = Console.ReadLine();

            while (joinProcedure != "end of assignment")
            {
                JoinMembers(allTeams, joinProcedure);

                joinProcedure = Console.ReadLine();
            }


            foreach (var team in allTeams.OrderByDescending(t => t.Members.Count).ThenBy(t => t.Name))
            {
                if (team.Members.Count > 0)
                {
                    Console.WriteLine(team.Name);
                    Console.WriteLine($"- {team.Creator}");

                    foreach (var member in team.Members.OrderBy(m => m))
                    {
                        Console.WriteLine($"-- {member}");
                    }
                }
            }


            Console.WriteLine("Teams to disband:");
            foreach (var team in allTeams.Where(t => t.Members.Count == 0).OrderBy(t => t.Name))
            {
                Console.WriteLine(team.Name);
            }


        }

        public static void JoinMembers(List<Team> allTeams, string joinProcedure)
        {
            string[] joinParameters = joinProcedure.Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
            string currentMemmber = joinParameters[0];
            string wantedTeam = joinParameters[1];


            if (allTeams.Any(t => t.Name == wantedTeam))
            {
                if (allTeams.Any(t => t.Members.Contains(currentMemmber)))
                {
                    Console.WriteLine($"Member {currentMemmber} cannot join team {wantedTeam}!");
                }
                else if (allTeams.Any(t => t.Creator == currentMemmber))
                {
                    Console.WriteLine($"Member {currentMemmber} cannot join team {wantedTeam}!");
                }

                else
                {
                    foreach (var team in allTeams)
                    {
                        if (team.Name == wantedTeam)
                        {
                            team.Members.Add(currentMemmber);
                        }
                    }
                }
            }

            else
            {
                Console.WriteLine($"Team {wantedTeam} does not exist!");
            }
        }

        public static void RegisterTeams(List<Team> allTeams)
        {
            string[] teamsAndCreators = Console.ReadLine().Split('-');
            string currentCreator = teamsAndCreators[0];
            string currentTeamName = teamsAndCreators[1];

            if (allTeams.Any(t => t.Name == currentTeamName))
            {
                Console.WriteLine($"Team {currentTeamName} was already created!");
            }
            else if (allTeams.Any(t => t.Creator == currentCreator))
            {
                Console.WriteLine($"{currentCreator} cannot create another team!");
            }
            else
            {
                Team currentTeam = new Team()
                {
                    Name = currentTeamName,
                    Creator = currentCreator,
                    Members = new List<string>()
                };
                allTeams.Add(currentTeam);

                Console.WriteLine($"Team {currentTeamName} has been created by {currentCreator}!");
            }
        }
    }
}
