using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var people = new List<Person>();

        string inputLine;
        while ((inputLine = Console.ReadLine()) != "END")
        {
            var tokens = inputLine.Split();

            var name = tokens[0];
            var age = int.Parse(tokens[1]);
            var town = tokens[2];
            
            people.Add(new Person(name, age, town));
        }

        var personIndex = int.Parse(Console.ReadLine()) - 1;
        var person = people[personIndex];

        var equalPeople = 1;
        var nonEqualPeople = 0;
        var totalNumberOfPeople = people.Count;

        people.RemoveAt(personIndex);

        foreach (var currentPerson in people)
        {
            if (person.CompareTo(currentPerson) == 0)
            {
                equalPeople++;
            }
            else
            {
                nonEqualPeople++;
            }
        }

        var result = equalPeople == 1
            ? "No matches"
            : $"{equalPeople} {nonEqualPeople} {totalNumberOfPeople}";

        Console.WriteLine(result);
    }
}
