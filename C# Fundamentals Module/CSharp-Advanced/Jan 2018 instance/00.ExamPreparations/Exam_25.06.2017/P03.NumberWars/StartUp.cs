namespace P03.NumberWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var result = "Draw";

            var firstPlayerCards = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Card(x))
                .ToQueue();

            var secondPlayerCards = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Card(x))
                .ToQueue();

            var turns = 0;
            while (turns < 1000000 && firstPlayerCards.Count > 0 && secondPlayerCards.Count > 0)
            {
                var firstPlayerCurrentCard = firstPlayerCards.Dequeue();
                var secondPlayerCurrentCard = secondPlayerCards.Dequeue();

                if (firstPlayerCurrentCard.Number > secondPlayerCurrentCard.Number)
                {
                    firstPlayerCards.Enqueue(firstPlayerCurrentCard);
                    firstPlayerCards.Enqueue(secondPlayerCurrentCard);
                }
                else if (firstPlayerCurrentCard.Number < secondPlayerCurrentCard.Number)
                {
                    secondPlayerCards.Enqueue(secondPlayerCurrentCard);
                    secondPlayerCards.Enqueue(firstPlayerCurrentCard);
                }
                else
                {
                    var hasHandtWinner = false;
                    var allCards = new List<Card>();

                    allCards.Add(firstPlayerCurrentCard);
                    allCards.Add(secondPlayerCurrentCard);

                    while (!hasHandtWinner)
                    {
                        if (firstPlayerCards.Count == 0 || secondPlayerCards.Count == 0)
                        {
                            break;
                        }

                        var firstPlayerPledge = new List<Card>();
                        var secondPlayerPledge = new List<Card>();

                        for (int i = 0; i < 3; i++)
                        {
                            firstPlayerPledge.Add(firstPlayerCards.Dequeue());
                            secondPlayerPledge.Add(secondPlayerCards.Dequeue());
                        }

                        allCards.AddRange(firstPlayerPledge);
                        allCards.AddRange(secondPlayerPledge);

                        var firstPlayerCurrentSum = firstPlayerPledge.Sum(c => (int)c.Letter);
                        var secondPlayerCurrentSum = secondPlayerPledge.Sum(c => (int)c.Letter);

                        if (firstPlayerCurrentSum > secondPlayerCurrentSum)
                        {
                            hasHandtWinner = true;

                            allCards = allCards.OrderByDescending(c => c.Number).ThenByDescending(c => c.Letter).ToList();

                            allCards.ForEach(c => firstPlayerCards.Enqueue(c));
                        }
                        else if (secondPlayerCurrentSum > firstPlayerCurrentSum)
                        {
                            hasHandtWinner = true;

                            allCards = allCards.OrderByDescending(c => c.Number).ThenByDescending(c => c.Letter).ToList();

                            allCards.ForEach(c => secondPlayerCards.Enqueue(c));
                        }
                    }
                }

                turns++;
            }

            var difference = firstPlayerCards.Count - secondPlayerCards.Count;

            if (difference > 0)
            {
                result = "First player wins";
            }
            else if (difference < 0)
            {
                result = "Second player wins";
            }

            Console.WriteLine($"{result} after {turns} turns");
        }
    }

    internal class Card
    {
        public Card(string card)
        {
            this.Number = long.Parse(card.Substring(0, card.Length - 1));
            this.Letter = card.Last();
        }

        public long Number { get; set; }
        public char Letter { get; set; }
    }

    internal static class CollectionsExtenssions
    {
        public static Queue<T> ToQueue<T>(this IEnumerable<T> collection)
        {
            return new Queue<T>(collection);
        }
    }
}
