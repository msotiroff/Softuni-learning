using System;
using System.Linq;

public class StartUp
{
    public static void Main(string[] args)
    {
        var citizenParams = Console.ReadLine().Split().ToList();
        var town = citizenParams.Last();
        citizenParams.RemoveAt(citizenParams.Count - 1);
        var address = citizenParams.Last();
        citizenParams.RemoveAt(citizenParams.Count - 1);
        var name = string.Join(" ", citizenParams);
        var citizen = new Threeuple<string, string, string>(name, address, town);

        var beerDrinkerParams = Console.ReadLine().Split().ToList();
        var isDrunk = beerDrinkerParams.Last().ToLower() == "drunk";
        beerDrinkerParams.RemoveAt(beerDrinkerParams.Count - 1);
        var beer = int.Parse(beerDrinkerParams.Last());
        beerDrinkerParams.RemoveAt(beerDrinkerParams.Count - 1);
        var drinkerName = string.Join(" ", beerDrinkerParams);
        var beerDrinker = new Threeuple<string, int, bool>(drinkerName, beer, isDrunk);

        var numbersParams = Console.ReadLine().Split();
        var numberHolder = new Threeuple<string, double, string>(numbersParams[0], double.Parse(numbersParams[1]), numbersParams[2]);

        Console.WriteLine(citizen);
        Console.WriteLine(beerDrinker);
        Console.WriteLine(numberHolder);
    }
}
