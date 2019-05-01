using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main(string[] args)
    {
        var nameComparator = new NameComparator();
        var ageComparator = new AgeComparator();

        var sortedByName = new SortedSet<Person>(nameComparator);
        var sortedByAge = new SortedSet<Person>(ageComparator);

        var peopleCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < peopleCount; i++)
        {
            var personArgs = Console.ReadLine().Split();

            var currentPerson = new Person(personArgs[0], int.Parse(personArgs[1]));

            sortedByName.Add(currentPerson);
            sortedByAge.Add(currentPerson);
        }

        Console.WriteLine(string.Join(Environment.NewLine, sortedByName));
        Console.WriteLine(string.Join(Environment.NewLine, sortedByAge));
    }
}