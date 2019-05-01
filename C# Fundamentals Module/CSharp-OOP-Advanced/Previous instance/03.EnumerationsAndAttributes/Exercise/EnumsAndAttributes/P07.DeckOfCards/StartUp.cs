using System;

public class StartUp
{
    public static void Main()
    {
        var allSuits = Enum.GetValues(typeof(CardSuit));
        var allRanks = Enum.GetValues(typeof(CardRank));

        foreach (CardSuit suit in allSuits)
        {
            foreach (CardRank rank in allRanks)
            {
                Console.WriteLine($"{rank} of {suit}");
            }
        }
    }
}
