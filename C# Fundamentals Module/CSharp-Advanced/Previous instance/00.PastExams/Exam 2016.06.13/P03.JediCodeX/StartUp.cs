namespace P03.JediCodeX
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class StartUp
    {
        static void Main(string[] args)
        {
            var allJedis = new List<string>();
            var allMessages = new List<string>();

            var allJedisAndMessages = new Dictionary<string, List<string>>();

            var linesCount = int.Parse(Console.ReadLine());

            var allLines = new StringBuilder();

            for (int i = 0; i < linesCount; i++)
            {
                var currentMsg = Console.ReadLine();
                allLines.Append(currentMsg);
            }

            var lettersPattern = Console.ReadLine();
            var lettersAndDigitsPattern = Console.ReadLine();
            var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var validNamePattern = $@"{lettersPattern}([a-zA-Z]{{{lettersPattern.Length}}})(?![A-Za-z])";
            var validMsgPattern = $@"{lettersAndDigitsPattern}([A-Za-z0-9]{{{lettersAndDigitsPattern.Length}}})(?![A-Za-z0-9])";

            var namesMatches = Regex.Matches(allLines.ToString(), validNamePattern);
            var msgsMatches = Regex.Matches(allLines.ToString(), validMsgPattern);

            var names = new Queue<string>();
            var messages = new List<string>();

            foreach (Match name in namesMatches)
            {
                names.Enqueue(name.Groups[1].Value);
            }
            foreach (Match msg in msgsMatches)
            {
                messages.Add(msg.Groups[1].Value);
            }

            for (int i = 0; i < indexes.Length; i++)
            {
                var currentIndex = indexes[i] - 1;

                if (currentIndex >= 0 && currentIndex < messages.Count && names.Any())
                {
                    Console.WriteLine($"{names.Dequeue()} - {messages[currentIndex]}");
                }
            }
        }
    }
}
