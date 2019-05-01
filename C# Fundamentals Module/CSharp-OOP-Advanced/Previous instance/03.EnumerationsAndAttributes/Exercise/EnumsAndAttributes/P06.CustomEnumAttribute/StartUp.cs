using System;

public class StartUp
{
    public static void Main()
    {
        var suitOrRank = Console.ReadLine();

        Type type = null;

        switch (suitOrRank)
        {
            case "Suit":
                type = typeof(CardSuit);
                break;
            case "Rank":
                type = typeof(CardRank);
                break;
            default:
                break;
        }

        var attributes = type.GetCustomAttributes(false);

        foreach (var attribute in attributes)
        {
            Console.WriteLine(attribute);
        }
    }
}
