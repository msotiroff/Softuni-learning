using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    private static Dictionary<string, HashSet<Card>> currentGame;

    public static void Main()
    {
        //var deck = GetAllCards();

        var firstPlayerName = Console.ReadLine();
        var secondPlayerName = Console.ReadLine();

        currentGame = new Dictionary<string, HashSet<Card>>()
        {
            [firstPlayerName] = new HashSet<Card>(),
            [secondPlayerName] = new HashSet<Card>()
        };

        var givenCardsCount = 0;

        while (givenCardsCount < 5)
        {
            try
            {
                var cardParams = Console.ReadLine().Split();

                var rank = cardParams.First();
                var suit = cardParams.Last();

                var card = new Card(rank, suit);

                if (currentGame.Values
                    .Any(set => set
                        .Any(c => c.Rank.ToString() == rank && c.Suit.ToString() == suit)))
                {
                    Console.WriteLine("Card is not in the deck.");
                }
                else
                {
                    currentGame[firstPlayerName].Add(card);
                    givenCardsCount++;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        while (givenCardsCount < 10)
        {
            try
            {
                var cardParams = Console.ReadLine().Split();

                var rank = cardParams.First();
                var suit = cardParams.Last();

                var card = new Card(rank, suit);

                if (currentGame.Values
                    .Any(set => set
                        .Any(c => c.Rank.ToString() == rank && c.Suit.ToString() == suit)))
                {
                    Console.WriteLine("Card is not in the deck.");
                }
                else
                {
                    currentGame[secondPlayerName].Add(card);
                    givenCardsCount++;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        var firstPlayerMaxCard = currentGame[firstPlayerName].Max(c => c.Power);
        var secondPlayerMaxCard = currentGame[secondPlayerName].Max(c => c.Power);

        if (firstPlayerMaxCard > secondPlayerMaxCard)
        {
            var winnerCard = currentGame[firstPlayerName].OrderBy(c => c.Power).Last();
            Console.WriteLine($"{firstPlayerName} wins with {winnerCard.ToString()}.");
        }
        else if (firstPlayerMaxCard < secondPlayerMaxCard)
        {
            var winnerCard = currentGame[secondPlayerName].OrderBy(c => c.Power).Last();
            Console.WriteLine($"{secondPlayerName} wins with {winnerCard.ToString()}.");
        }
    }
}
