using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace _10.StudentGroups
{
    class StudentGroups
    {
        static void Main(string[] args)
        {
            List<Town> allTowns = new List<Town>();
            List<Student> allStudent = new List<Student>();
            
            string input = Console.ReadLine();

            string townToAdd = string.Empty;

            while (input != "End")
            {
                if (input.Contains("=>"))
                {
                    string[] inputParams = input
                                    .Split(new[] { "=>" }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(x => x.Trim())
                                    .ToArray();

                    townToAdd = inputParams[0];

                    ReadTowns(allTowns, inputParams);
                }
                else
                {
                    string[] inputParams = input.Split('|').Select(x => x.Trim()).ToArray();

                    ReadStudents(allTowns, allStudent, townToAdd, inputParams);
                }


                input = Console.ReadLine();
            }

            List<Group> allGroups = new List<Group>();
            List<Town> sortedTowns = allTowns.OrderBy(t => t.Name).ToList();

            for (int i = 0; i < sortedTowns.Count; i++)
            {
                Town currentTown = sortedTowns[i];

                ReadGroups(allGroups, currentTown);
            }

            PrintOutput(allTowns, allGroups);

        }

        public static void PrintOutput(List<Town> allTowns, List<Group> allGroups)
        {
            Console.WriteLine($"Created {allGroups.Count} groups in {allTowns.Count} towns:");

            foreach (var group in allGroups)
            {
                List<string> emailsToPrint = group.Students.Select(s => s.Email).ToList();

                Console.WriteLine($"{group.Town.Name} => {string.Join(", ", emailsToPrint)}");
            }
        }

        public static void ReadGroups(List<Group> allGroups, Town currentTown)
        {
            List<Student> currTownStudents = currentTown.Students
                                .OrderBy(s => s.RegistrationDate)
                                .ThenBy(s => s.Name)
                                .ThenBy(s => s.Email)
                                .ToList();

            while (currTownStudents.Any())
            {
                Group currentGroup = new Group();
                currentGroup.Town = currentTown;
                currentGroup.Students = currTownStudents.Take(currentGroup.Town.SeatsCount).ToList();
                currTownStudents = currTownStudents.Skip(currentGroup.Town.SeatsCount).ToList();
                allGroups.Add(currentGroup);
            }
        }

        public static void ReadStudents(List<Town> allTowns, List<Student> allStudent, string townToAdd, string[] inputParams)
        {
            string currStudentName = inputParams[0];
            string currStudentMail = inputParams[1];
            DateTime currStudentRegDate = DateTime.ParseExact(inputParams[2], "d-MMM-yyyy", CultureInfo.InvariantCulture);

            Student currentStudent = new Student()
            {
                Name = currStudentName,
                Email = currStudentMail,
                RegistrationDate = currStudentRegDate
            };

            allStudent.Add(currentStudent);

            foreach (var town in allTowns)
            {
                if (town.Name == townToAdd)
                {
                    town.Students.Add(currentStudent);
                }
            }
        }

        public static void ReadTowns(List<Town> allTowns, string[] inputParams)
        {
            string currentTownName = inputParams[0];
            int labSeats = int.Parse(inputParams[1].Split(' ')[0]);



            Town currentTown = new Town()
            {
                Name = currentTownName,
                SeatsCount = labSeats,
                Students = new List<Student>()
            };

            allTowns.Add(currentTown);
        }
    }
}
