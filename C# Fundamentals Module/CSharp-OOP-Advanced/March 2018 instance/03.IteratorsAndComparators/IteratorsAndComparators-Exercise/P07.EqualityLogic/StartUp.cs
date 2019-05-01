using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main(string[] args)
    {
        var personComparator = new PersonComparator();
        var personEqualityComparer = new PersonEqualityComparer();

        var sortedPeople = new SortedSet<Person>(personComparator);
        var unsortedPeople = new HashSet<Person>(personEqualityComparer);

        var linesCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < linesCount; i++)
        {
            var personArgs = Console.ReadLine().Split();
            var name = personArgs[0];
            var age = int.Parse(personArgs[1]);

            var person = new Person(name, age);

            sortedPeople.Add(person);
            unsortedPeople.Add(person);
        }

        Console.WriteLine(sortedPeople.Count);
        Console.WriteLine(unsortedPeople.Count);
    }
}
