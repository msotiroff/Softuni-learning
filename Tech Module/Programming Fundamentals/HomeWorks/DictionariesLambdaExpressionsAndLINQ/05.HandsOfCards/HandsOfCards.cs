using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.Hands_of_cards
{
    class HandsOfCards
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> cardHolder = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "JOKER")
            {
                var currentInput = input
                .Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                FillingCardHolder(cardHolder, currentInput);

                input = Console.ReadLine();
            }

            PrintResults(cardHolder);
        }

        public static void PrintResults(Dictionary<string, List<string>> cardHolder)
        {
            Dictionary<string, int> cardPower = new Dictionary<string, int>();
            cardPower["2"] = 2;
            cardPower["3"] = 3;
            cardPower["4"] = 4;
            cardPower["5"] = 5;
            cardPower["6"] = 6;
            cardPower["7"] = 7;
            cardPower["8"] = 8;
            cardPower["9"] = 9;
            cardPower["10"] = 10;
            cardPower["J"] = 11;
            cardPower["Q"] = 12;
            cardPower["K"] = 13;
            cardPower["A"] = 14;
            Dictionary<string, int> cardType = new Dictionary<string, int>();
            cardType["S"] = 4;
            cardType["H"] = 3;
            cardType["D"] = 2;
            cardType["C"] = 1;

            foreach (var item in cardHolder)
            {
                string[] temp = cardHolder[item.Key].ToArray();
                int value = 0;
                for (int i = 0; i < temp.Length; i++)
                {
                    string[] card = { temp[i].Substring(0, temp[i].Length - 1), temp[i][temp[i].Length - 1].ToString() };
                    value += cardPower[card[0]] * cardType[card[1]];
                }
                Console.WriteLine($"{item.Key}: {value}");
            }
        }

        public static void FillingCardHolder(Dictionary<string, List<string>> cardHolder, string[] currentInput)
        {
            var name = currentInput[0];
            var cards = currentInput[currentInput.Length - 1];
            List<string> currentCards = cards
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            currentCards = currentCards.Distinct().ToList();

            if (!cardHolder.ContainsKey(name))
            {
                cardHolder[name] = new List<string>();
            }
            for (int i = 0; i < currentCards.Count; i++)
            {
                if (!cardHolder[name].Contains(currentCards[i]))
                {
                    cardHolder[name].Add(currentCards[i]);
                }
            }
        }
    }
}
