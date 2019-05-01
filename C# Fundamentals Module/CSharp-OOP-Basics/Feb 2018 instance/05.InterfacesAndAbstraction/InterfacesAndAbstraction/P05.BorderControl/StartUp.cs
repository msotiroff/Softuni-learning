using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main(string[] args)
    {
        var detaineds = new List<IResident>();

        string inputLine;
        while ((inputLine = Console.ReadLine()) != "End")
        {
            IResident resident = null;

            var inputArgs = inputLine.Split();

            if (inputArgs.Length == 3)
            {
                var name = inputArgs[0];
                var age = int.Parse(inputArgs[1]);
                var id = inputArgs[2];

                resident = new Citizen(name, age, id);
            }
            else
            {
                var model = inputArgs[0];
                var id = inputArgs[1];

                resident = new Robot(model, id);
            }

            detaineds.Add(resident);
        }

        var fakeIdsLastNumber = Console.ReadLine();

        detaineds
            .Where(r => r.Id.EndsWith(fakeIdsLastNumber))
            .ToList()
            .ForEach(r => Console.WriteLine(r.Id));
    }
}