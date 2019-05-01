namespace P13.FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var allPeople = new List<Person>();
            var allRelations = new List<string>();

            var mainPersonArgument = Console.ReadLine();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "End")
            {
                if (inputLine.Contains(" - "))
                {
                    allRelations.Add(inputLine);
                }
                else
                {
                    var inputParams = inputLine.Split();
                    var date = inputParams.Last();
                    var name = inputParams[0] + " " + inputParams[1];  //inputLine.Replace(date, string.Empty).Trim();

                    allPeople.Add(new Person(name, date));
                }
            }

            var mainPerson = allPeople
                .First(p => p.Name == mainPersonArgument || p.BirthDate == mainPersonArgument);

            foreach (var relation in allRelations)
            {
                var kvp = relation.Split(" - ");
                var parentNameOrDate = kvp.First();
                var childNameOrDate = kvp.Last();

                if (mainPerson.Name == parentNameOrDate || mainPerson.BirthDate == parentNameOrDate)
                {
                    mainPerson.AddChild(allPeople.First(p => p.Name == childNameOrDate || p.BirthDate == childNameOrDate));
                }
                else if (mainPerson.Name == childNameOrDate || mainPerson.BirthDate == childNameOrDate)
                {
                    mainPerson.AddParent(allPeople.First(p => p.Name == parentNameOrDate || p.BirthDate == parentNameOrDate));
                }
            }

            Console.WriteLine(mainPerson);
        }
        
        private static bool IsDate(string argument)
        {
            var match = Regex.Match(argument, @"\d{1,2}\/\d{1,2}\/\d{4}");
            return match.Success;
        }
    }
}
