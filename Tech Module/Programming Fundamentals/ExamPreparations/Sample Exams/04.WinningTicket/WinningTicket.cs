using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.WinningTicket
{
    class WinningTicket
    {
        static void Main(string[] args)
        {
            string[] allTickets = Console.ReadLine()
                .Split(',')
                .Select(x => x.Trim())
                .ToArray();
            
            for (int i = 0; i < allTickets.Length; i++)
            {
                string currentTicket = allTickets[i];

                if (currentTicket.Length == 20)
                {
                    if (currentTicket.All(ch => ch == '^') ||
                        currentTicket.All(ch => ch == '#') ||
                        currentTicket.All(ch => ch == '$') ||
                        currentTicket.All(ch => ch == '@'))
                    {
                        Console.WriteLine($"ticket \"{currentTicket}\" - 10{currentTicket[0]} Jackpot!");
                        continue;
                    }
                    string leftPart = currentTicket.Substring(0, 10);
                    string rightPart = currentTicket.Substring(10);

                    Regex winningSequence = new Regex(@"(\^{6,9}|\${6,9}|\#{6,9}|\@{6,9})");
                    var leftMatch = winningSequence.Match(leftPart);
                    var rightMatch = winningSequence.Match(rightPart);

                    if (leftMatch.Success && rightMatch.Success)
                    {
                        if (leftMatch.Value.ToString()[0] == rightMatch.Value.ToString()[0])
                        {
                            Console.WriteLine($"ticket \"{currentTicket}\" - {Math.Min(leftMatch.Length, rightMatch.Length)}{rightMatch.Value.ToString()[0]}");
                            continue;
                        }
                    }

                    Console.WriteLine($"ticket \"{currentTicket}\" - no match");
                }
                else
                {
                    Console.WriteLine("invalid ticket");
                }
            }

        }
    }
}
