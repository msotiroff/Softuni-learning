using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _2.Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([1]?[0-9JQKA])([SHDC])";
            Regex needed = new Regex(pattern);

            string inputLine = Console.ReadLine();

            var cards = needed.Matches(inputLine);

            List<string> validCards = new List<string>();

            foreach (Match card in cards)
            {
                int cardPower;
                if (int.TryParse(card.Groups[1].Value, out cardPower))
                {
                    if (cardPower < 2 || cardPower > 10)
                    {
                        continue;
                    }
                }
                validCards.Add(card.Value);
            }

            Console.WriteLine(string.Join(", ", validCards));
        }
    }
}
