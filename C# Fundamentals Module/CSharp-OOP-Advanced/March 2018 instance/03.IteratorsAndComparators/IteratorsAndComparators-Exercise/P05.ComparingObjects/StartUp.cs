using System;
using System.Linq;
using System.Collections.Generic;

public class StartUp
{
    public static void Main(string[] args)
    {
        var people = new List<Person>();

        string inputLine;
        while ((inputLine = Console.ReadLine()) != "END")
        {
            var personArgs = inputLine.Split();
            var name = personArgs[0];
            var age = int.Parse(personArgs[1]);
            var town = personArgs[2];

            people.Add(new Person(name, age, town));
        }


        var index = int.Parse(Console.ReadLine()) - 1;

        var personToBeCompared = people[index];

        var equalPeople = people.Count(p => p.CompareTo(personToBeCompared) == 0);

        var result = "No matches";

        if (equalPeople > 1)
        {
            result = $"{equalPeople} {people.Count - equalPeople} {people.Count}";
        }

        Console.WriteLine(result);
    }
}