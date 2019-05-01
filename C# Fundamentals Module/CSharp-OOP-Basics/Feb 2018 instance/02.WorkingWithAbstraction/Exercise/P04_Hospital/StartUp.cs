namespace P04_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doktors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


            string command;
            while ((command  = Console.ReadLine()) != "Output")
            {
                var commandArgs = command.Split();

                var departament = commandArgs[0];
                var firstName = commandArgs[1];
                var lastName = commandArgs[2];
                var patient = commandArgs[3];

                var doctorFullName = firstName + " " + lastName;

                if (!doktors.ContainsKey(doctorFullName))
                {
                    doktors[doctorFullName] = new List<string>();
                }
                if (!departments.ContainsKey(departament))
                {
                    departments[departament] = new List<List<string>>();
                    for (int room = 0; room < 20; room++)
                    {
                        departments[departament].Add(new List<string>());
                    }
                }

                bool hasFreeBed = departments[departament].SelectMany(x => x).Count() < 60;
                if (hasFreeBed)
                {
                    int currentRoom = 0;
                    doktors[doctorFullName].Add(patient);
                    for (int st = 0; st < departments[departament].Count; st++)
                    {
                        if (departments[departament][st].Count < 3)
                        {
                            currentRoom = st;
                            break;
                        }
                    }
                    departments[departament][currentRoom].Add(patient);
                }
            }

            while ((command  = Console.ReadLine()) != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int staq))
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]][staq - 1].OrderBy(x => x)));
                }
                else
                {
                    string doctorName = args[0] + " " + args[1];
                    Console.WriteLine(string.Join("\n", doktors[doctorName].OrderBy(x => x)));
                }
            }
        }
    }
}
