using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var nameComparator = new NameComparator();
        var ageComparator = new AgeComparator();

        var soretdByName = new SortedSet<Person>(nameComparator);
        var sortedByAge = new SortedSet<Person>(ageComparator);

        var numberOfPeople = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfPeople; i++)
        {
            var personParams = Console.ReadLine().Split();

            var person = new Person(personParams[0], int.Parse(personParams[1]));

            soretdByName.Add(person);
            sortedByAge.Add(person);
        }

        foreach (var person in soretdByName)
        {
            Console.WriteLine($"{person.Name} {person.Age}");
        }

        foreach (var person in sortedByAge)
        {
            Console.WriteLine($"{person.Name} {person.Age}");
        }
    }
}
