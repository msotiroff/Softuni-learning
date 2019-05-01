using System;

public class StartUp
{
    public static void Main(string[] args)
    {
        var firstDate = Console.ReadLine();
        var secondDate = Console.ReadLine();

        var dateModifier = new DateModifier(firstDate, secondDate);
        Console.WriteLine(dateModifier.GetDifference());
    }
}