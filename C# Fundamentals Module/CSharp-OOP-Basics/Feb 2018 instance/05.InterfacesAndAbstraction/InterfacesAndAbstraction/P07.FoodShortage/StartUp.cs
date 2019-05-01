using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main(string[] args)
    {
        var buyers = new List<IBuyer>();

        var buyersCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < buyersCount; i++)
        {
            IBuyer buyer = null;

            var buyerArgs = Console.ReadLine().Split();
            var name = buyerArgs[0];
            var age = int.Parse(buyerArgs[1]);
            var idOrGroup = buyerArgs[2];

            if (buyerArgs.Length > 3)
            {
                var birthdate = buyerArgs[3];
                buyer = new Citizen(name, age, idOrGroup, birthdate);
            }
            else
            {
                buyer = new Rebel(name, age, idOrGroup);
            }

            if (buyer != null)
            {
                buyers.Add(buyer);
            }
        }

        string buyerName;
        while ((buyerName = Console.ReadLine()) != "End")
        {
            buyers
                .FirstOrDefault(b => b.Name == buyerName)
                ?.BuyFood();
        }

        Console.WriteLine(buyers.Sum(b => b.Food));
    }
}
