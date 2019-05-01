using System;

public class StartUp
{
    public static void Main()
    {
        var suits = Enum.GetValues(typeof(CardSuit));

        Console.WriteLine("Card Suits:");

        foreach (CardSuit suit in suits)
        {
            Console.WriteLine($"Ordinal value: {(int)suit}; Name value: {suit}");
        }
    }
}
