using System;

public class StartUp
{
    public static void Main()
    {
        var firstCard = new Card(Console.ReadLine(), Console.ReadLine());
        var secondCard = new Card(Console.ReadLine(), Console.ReadLine());

        if (firstCard.CompareTo(secondCard) > 0)
        {
            Console.WriteLine(firstCard);
        }
        else
        {
            Console.WriteLine(secondCard);
        }
    }
}
