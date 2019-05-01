namespace P03.NumberWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NumberWars
    {
        private const int maxTurns = 1_000_000;
        
        public static void Main(string[] args)
        {
            var turnsCount = 0;
            var winner = string.Empty;
            var result = string.Empty;

            var firstPlayerInput = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Card
                {
                    CardValue = long.Parse(x.Substring(0, x.Length - 1)),
                    LetterValue = Convert.ToInt32(x.Last())
                })
                .ToArray();

            var secondPlayerInput = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Card
                {
                    CardValue = long.Parse(x.Substring(0, x.Length - 1)),
                    LetterValue = Convert.ToInt32(x.Last())
                })
                .ToArray();

            var firstPlayerCards = new Queue<Card>(firstPlayerInput);
            var secondPlayerCards = new Queue<Card>(secondPlayerInput);

            
            for (int i = 1; i <= maxTurns; i++)
            {
                turnsCount = i;

                var firstPayerCard = firstPlayerCards.Dequeue();
                var secondPalyerCard = secondPlayerCards.Dequeue();

                if (firstPayerCard.CardValue > secondPalyerCard.CardValue)
                {
                    firstPlayerCards.Enqueue(firstPayerCard);
                    firstPlayerCards.Enqueue(secondPalyerCard);
                }
                else if (firstPayerCard.CardValue < secondPalyerCard.CardValue)
                {
                    secondPlayerCards.Enqueue(secondPalyerCard);
                    secondPlayerCards.Enqueue(firstPayerCard);
                }
                else
                {
                    // Card values are equal:

                    List<Card> allCards = new List<Card>();
                    allCards.Add(firstPayerCard);
                    allCards.Add(secondPalyerCard);

                    var isTurnOver = false;

                    while (!isTurnOver)
                    {
                        var firstPlayerPledge = new List<Card>();
                        var secondPlayerPledge = new List<Card>();

                        for (int j = 0; j < 3; j++)
                        {
                            firstPlayerPledge.Add(firstPlayerCards.Dequeue());
                            secondPlayerPledge.Add(secondPlayerCards.Dequeue());
                        }
                        allCards.AddRange(firstPlayerPledge);
                        allCards.AddRange(secondPlayerPledge);

                        var firstPlayerCurrentSum = firstPlayerPledge.Sum(c => c.LetterValue);
                        var secondPlayerCurrentSum = secondPlayerPledge.Sum(c => c.LetterValue);

                        if (firstPlayerCurrentSum == secondPlayerCurrentSum)
                        {
                            continue;
                        }

                        // First player wins the current turn:
                        if (firstPlayerCurrentSum > secondPlayerCurrentSum)
                        {
                            allCards = allCards
                                .OrderByDescending(c => c.CardValue)
                                .ThenByDescending(c => c.LetterValue)
                                .ToList();

                            allCards.ForEach(c => firstPlayerCards.Enqueue(c));

                            isTurnOver = true;
                        }

                        // Second player wins the current turn:
                        if (firstPlayerCurrentSum < secondPlayerCurrentSum)
                        {
                            allCards = allCards
                                .OrderByDescending(c => c.CardValue)
                                .ThenByDescending(c => c.LetterValue)
                                .ToList();

                            allCards.ForEach(c => secondPlayerCards.Enqueue(c));

                            isTurnOver = true;
                        }
                    }
                }

                if (!secondPlayerCards.Any())
                {
                    winner = "First player";
                    break;
                }
                if (!firstPlayerCards.Any())
                {
                    winner = "Second player";
                    break;
                }
            }

            if (turnsCount == maxTurns)
            {
                if (firstPlayerCards.Count > secondPlayerCards.Count)
                {
                    winner = "First player";
                }
                else if (firstPlayerCards.Count < secondPlayerCards.Count)
                {
                    winner = "Second player";
                }
            }

            if (winner == string.Empty)
            {
                result = $"Draw after {turnsCount} turns";
            }
            else
            {
                result = $"{winner} wins after {turnsCount} turns";
            }

            // Print final result:
            Console.WriteLine(result);
        }
    }
}
