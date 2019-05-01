using System;

public class StartUp
{
    public static void Main(string[] args)
    {
        var family = new Family();

        int membersCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < membersCount; i++)
        {
            var currentPersonArgs = Console.ReadLine().Split();

            var person = new Person(currentPersonArgs[0], int.Parse(currentPersonArgs[1]));

            family.AddMember(person);
        }

        Console.WriteLine(family.GetOldestMember());
    }
}