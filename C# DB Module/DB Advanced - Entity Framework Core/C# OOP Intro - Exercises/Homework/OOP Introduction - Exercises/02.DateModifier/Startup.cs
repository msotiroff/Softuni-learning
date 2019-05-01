using System;

public class Startup
{
    public static void Main(string[] args)
    {
        string firstDate = Console.ReadLine();
        string secondDate = Console.ReadLine();

        DateModifier dateModifier = 
            new DateModifier();

        dateModifier.CalculateDateDifference(firstDate, secondDate);

        Console.WriteLine(dateModifier.DaysDifference);
    }
}
