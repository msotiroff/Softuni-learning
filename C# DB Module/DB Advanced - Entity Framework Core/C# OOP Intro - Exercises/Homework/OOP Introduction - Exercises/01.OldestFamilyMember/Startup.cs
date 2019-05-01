using System;
using System.Linq;
using System.Reflection;

public class Startup
{
    public static void Main(string[] args)
    {
        // Judge system verification:
        MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
        if (oldestMemberMethod == null || addMemberMethod == null)
        {
            throw new Exception();
        }


        int numberOfLines = int.Parse(Console.ReadLine());

        Family family = new Family();

        for (int i = 0; i < numberOfLines; i++)
        {
            string[] personParams = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string name = personParams[0];
            int age = int.Parse(personParams[1]);

            Person person = new Person(name, age);
            family.AddMember(person);
        }

        Console.WriteLine(family.PrintOldestMember());
    }
}
