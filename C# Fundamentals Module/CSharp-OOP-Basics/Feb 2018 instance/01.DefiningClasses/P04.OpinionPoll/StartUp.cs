using System;
using System.Linq;

public class StartUp
{
    public static void Main(string[] args)
    {
        var family = new Family();

        var peopleCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < peopleCount; i++)
        {
            var currentPersonArgs = Console.ReadLine().Split();

            var person = new Person(currentPersonArgs[0], int.Parse(currentPersonArgs[1]));

            family.AddMember(person);
        }

        family.Members
            .Where(p => p.Age > 30)
            .OrderBy(p => p.Name)
            .ToList()
            .ForEach(p => Console.WriteLine(p));
    }
}
