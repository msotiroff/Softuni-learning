namespace P03.JediCodeX
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var jedis = new Queue<string>();
            var messages = new List<string>();

            var linesCount = int.Parse(Console.ReadLine());

            var allLines = new StringBuilder();

            for (int i = 0; i < linesCount; i++)
            {
                allLines.Append(Console.ReadLine());
            }

            var jediPrefix = Console.ReadLine();
            var jediLength = jediPrefix.Length;

            var jediPattern = jediPrefix + $@"([A-Za-z]{{{jediLength}}})(?![A-Za-z])";

            var allJedis = Regex.Matches(allLines.ToString(), jediPattern);
            foreach (Match jedi in allJedis)
            {
                jedis.Enqueue(jedi.Groups[1].Value);
            }

            var msgPrefix = Console.ReadLine();
            var msgLength = msgPrefix.Length;

            var msgPattern = msgPrefix + $@"([A-Za-z0-9]{{{msgLength}}})(?![A-Za-z0-9])";

            var allMsgs = Regex.Matches(allLines.ToString(), msgPattern);

            foreach (Match msg in allMsgs)
            {
                messages.Add(msg.Groups[1].Value);
            }

            var indexes = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            foreach (var index in indexes)
            {
                if (index - 1 < messages.Count && index - 1 >= 0 && jedis.Count > 0)
                {
                    var currentJedi = jedis.Dequeue();
                    var currentMessage = messages[index - 1];
                
                    Console.WriteLine($"{currentJedi} - {currentMessage}");
                }
            }
        }
    }
}
