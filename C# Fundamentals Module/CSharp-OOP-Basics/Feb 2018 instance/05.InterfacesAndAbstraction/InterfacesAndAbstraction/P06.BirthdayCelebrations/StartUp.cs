using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    private static readonly string CitizenType = typeof(Citizen).Name;
    private static readonly string PetType = typeof(Pet).Name;

    public static void Main(string[] args)
    {
        var bornables = new List<IBornable>();

        string inputLine;
        while ((inputLine = Console.ReadLine()) != "End")
        {
            IBornable bornable = null;

            var inputArgs = inputLine.Split();

            var currentType = inputArgs[0];
            var name = inputArgs[1];

            if (currentType == CitizenType)
            {
                var age = int.Parse(inputArgs[2]);
                var id = inputArgs[3];
                var birthdate = inputArgs[4];

                bornable = new Citizen(name, age, id, birthdate);
            }
            else if (currentType == PetType)
            {
                var birthdate = inputArgs[2];

                bornable = new Pet(name, birthdate);
            }

            if (bornable != null)
            {
                bornables.Add(bornable);
            }
        }

        var targetYear = Console.ReadLine();

        bornables
            .Where(b => b.Birthdate
                .Substring(b.Birthdate.LastIndexOf("/") + 1) == targetYear)
            .ToList()
            .ForEach(b =>
                Console.WriteLine(b.Birthdate));
    }
}