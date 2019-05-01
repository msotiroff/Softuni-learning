using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        Type type = typeof(Weapon);

        var attributes = type.GetCustomAttributes(false);

        var attribute = (WeaponAttribute)attributes.First();

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            switch (command)
            {
                case "Author":
                    Console.WriteLine($"Author: {attribute.Author}");
                    break;

                case "Revision":
                    Console.WriteLine($"Revision: {attribute.Revision}");
                    break;

                case "Description":
                    Console.WriteLine($"Class description: {attribute.Description}");
                    break;

                case "Reviewers":
                    Console.WriteLine($"Reviewers: {string.Join(", ", attribute.Reviewers)}");
                    break;
            }
        }
    }
}
