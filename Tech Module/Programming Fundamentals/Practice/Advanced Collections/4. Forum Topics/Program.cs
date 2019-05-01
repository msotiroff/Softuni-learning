using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Forum_Topics
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> forumTopics = new Dictionary<string, HashSet<string>>();

            char[] delimiters = { ' ', '-', '>', ',' };
            string[] input = Console.ReadLine()
                .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (input[0] != "filter")
            {
                string topic = input[0];

                if (! forumTopics.ContainsKey(topic))
                {
                    forumTopics[topic] = new HashSet<string>();
                }
                for (int tags = 1; tags < input.Length; tags++)
                {
                    string currentTag = input[tags];
                    forumTopics[topic].Add(currentTag);
                }

                input = Console.ReadLine()
                    .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }

            char[] separators = { ' ', ',' };
            string[] commands = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var kvp in forumTopics)
            {
                int tagsCounter = 0;
                for (int tags = 0; tags < commands.Length; tags++)
                {
                    if (kvp.Value.Contains(commands[tags]))
                    {
                        tagsCounter++;
                    }
                }

                if (tagsCounter == commands.Length)
                {
                    Console.WriteLine($"{kvp.Key} | #{string.Join(", #", kvp.Value)}");
                }
            }
        }
    }
}
