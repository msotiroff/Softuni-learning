using System;

public class StartUp
{
    public static void Main(string[] args)
    {
        var personArgs = Console.ReadLine().Split();
        var personName = string.Concat(personArgs[0], " ", personArgs[1]);
        var personAddress = personArgs[2];
        var personTown = personArgs[3];

        Console.WriteLine(new Threeuple<string, string, string>(personName, personAddress, personTown));

        var beerBreederArgs = Console.ReadLine().Split();
        var beerBreeder = beerBreederArgs[0];
        var litresOfBeer = int.Parse(beerBreederArgs[1]);
        var isDrunk = beerBreederArgs[2] == "drunk";

        Console.WriteLine(new Threeuple<string, int, bool>(beerBreeder, litresOfBeer, isDrunk));

        var bankArgs = Console.ReadLine().Split();
        var name = bankArgs[0];
        var balance = double.Parse(bankArgs[1]);
        var bankName = bankArgs[2];

        Console.WriteLine(new Threeuple<string, double, string>(name, balance, bankName));
    }
}