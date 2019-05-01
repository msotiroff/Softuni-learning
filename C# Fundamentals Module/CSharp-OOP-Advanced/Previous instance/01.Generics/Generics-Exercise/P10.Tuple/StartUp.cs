using System;

public class StartUp
{
    public static void Main(string[] args)
    {
        var personArgs = Console.ReadLine().Split();
        var personName = string.Concat(personArgs[0], " ", personArgs[1]);
        var personAddress = personArgs[2];
        
        Console.WriteLine(new Tuple<string, string>(personName, personAddress));

        var beerBreederArgs = Console.ReadLine().Split();
        var beerBreeder = beerBreederArgs[0];
        var litresOfBeer = int.Parse(beerBreederArgs[1]);

        Console.WriteLine(new Tuple<string, int>(beerBreeder, litresOfBeer));

        var numbers = Console.ReadLine().Split();
        var integer = int.Parse(numbers[0]);
        var floatingPoint = double.Parse(numbers[1]);

        Console.WriteLine(new Tuple<int, double>(integer, floatingPoint));
    }
}