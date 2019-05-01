using System;

public class StartUp
{
    public static void Main()
    {
        var rank = Console.ReadLine();
        var suit = Console.ReadLine();

        Card card = new Card(rank, suit);

        Console.WriteLine(card);
    }
}
