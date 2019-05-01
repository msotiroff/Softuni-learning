using System;

public class StartUp
{
    public static void Main()
    {
        var allRanks = Enum.GetValues(typeof(CardRank));

        Console.WriteLine("Card Ranks:");

        foreach (CardRank rank in allRanks)
        {
            Console.WriteLine($"Ordinal value: {(int)rank}; Name value: {rank}");
        }
    }
}
