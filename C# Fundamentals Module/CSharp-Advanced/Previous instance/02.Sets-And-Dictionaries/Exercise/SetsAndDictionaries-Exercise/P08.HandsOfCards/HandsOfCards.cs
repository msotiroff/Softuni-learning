namespace P08.HandsOfCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HandsOfCards
    {
        private static readonly string[] cardPowers = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        private static readonly char[] cardTypes = new char[] { 'C', 'D', 'H', 'S' };

        public static void Main(string[] args)
        {
            var allPlayers = new Dictionary<string, HashSet<string>>();

            // Example input: {personName}: {PT, PT, PT,… PT}, where P = card power, T = card type
            var inputLine = Console.ReadLine();

            while (inputLine != "JOKER")
            {
                var playerName = inputLine.Split(':').First();

                var cards = inputLine
                    .Replace(playerName + ": ", null)
                    .Split(new string[] { ", "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (!allPlayers.ContainsKey(playerName))
                {
                    allPlayers[playerName] = new HashSet<string>();
                }

                cards.ForEach(c => allPlayers[playerName].Add(c));

                inputLine = Console.ReadLine();
            }

            foreach (var player in allPlayers)
            {
                var name = player.Key;
                var cardsValue = CalculateCardsValue(player.Value);

                Console.WriteLine($"{name}: {cardsValue}");
            }
        }

        private static int CalculateCardsValue(HashSet<string> cards)
        {
            var result = 0;

            foreach (var card in cards)
            {
                var currentCardType = card.Last();

                var currentCardPower = card.Substring(0, card.Length - 1);

                var typeValue = Array.IndexOf(cardTypes, currentCardType) + 1;

                var powerValue = Array.IndexOf(cardPowers, currentCardPower) + 2;

                var currentCardValue = typeValue * powerValue;

                result += currentCardValue;
            }

            return result;
        }
    }
}
