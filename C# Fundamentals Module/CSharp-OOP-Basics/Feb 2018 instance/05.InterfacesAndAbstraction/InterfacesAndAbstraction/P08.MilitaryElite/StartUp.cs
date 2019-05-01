namespace P08.MilitaryElite
{
    using Contracts;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var allSoldiers = new List<ISoldier>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                ISoldier soldier = null;

                var commandArgs = command.Split();

                var soldierType = commandArgs[0];

                var id = int.Parse(commandArgs[1]);
                var firstName = commandArgs[2];
                var lastName = commandArgs[3];
                double salary;
                string corps;

                try
                {
                    switch (soldierType)
                    {
                        case "Private":
                            salary = double.Parse(commandArgs[4]);
                            soldier = new Private(id, firstName, lastName, salary);
                            break;
                        case "LeutenantGeneral":
                            salary = double.Parse(commandArgs[4]);
                            var privatesIds = commandArgs.Skip(5).Select(int.Parse).ToList();
                            var privates = allSoldiers.Where(s => privatesIds.Contains(s.Id)).Select(s => (IPrivate)s).ToList();
                            soldier = new LeutenantGeneral(id, firstName, lastName, salary, privates);
                            break;
                        case "Engineer":
                            salary = double.Parse(commandArgs[4]);
                            corps = commandArgs[5];
                            List<IRepair> repairs = GetRepairs(commandArgs);
                            soldier = new Engineer(id, firstName, lastName, salary, corps, repairs);
                            break;
                        case "Commando":
                            salary = double.Parse(commandArgs[4]);
                            corps = commandArgs[5];
                            List<IMission> missions = GetValidMissions(commandArgs);
                            soldier = new Commando(id, firstName, lastName, salary, corps, missions);
                            break;
                        case "Spy":
                            var codeNumber = int.Parse(commandArgs[4]);
                            soldier = new Spy(id, firstName, lastName, codeNumber);
                            break;
                        default:
                            break;
                    }
                }
                catch
                {
                }
                finally
                {
                    if (soldier != null)
                    {
                        allSoldiers.Add(soldier);
                    }
                }
            }

            allSoldiers
                .ForEach(s => Console.WriteLine(s));
        }

        private static List<IMission> GetValidMissions(string[] commandArgs)
        {
            var missionArgs = commandArgs.Skip(6).ToArray();
            var missions = new List<IMission>();
            for (int i = 0; i < missionArgs.Length; i += 2)
            {
                Mission mission = null;
                try
                {
                    mission = new Mission(missionArgs[i], missionArgs[i + 1]);
                }
                catch (ArgumentException)
                {
                }
                finally
                {
                    if (mission != null)
                    {
                        missions.Add(mission);
                    }
                }
            }

            return missions;
        }

        private static List<IRepair> GetRepairs(string[] commandArgs)
        {
            var repairsArgs = commandArgs.Skip(6).ToArray();
            var repairs = new List<IRepair>();
            for (int i = 0; i < repairsArgs.Length; i += 2)
            {
                repairs.Add(new Repair(repairsArgs[i], int.Parse(repairsArgs[i + 1])));
            }

            return repairs;
        }
    }
}
