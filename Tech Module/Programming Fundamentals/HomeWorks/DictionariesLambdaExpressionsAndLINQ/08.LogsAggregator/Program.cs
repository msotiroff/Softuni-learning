using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.Logs_Aggregator
{
    class LogsAggregator
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedDictionary<string, SortedDictionary<string, int>> usersLogs =
                new SortedDictionary<string, SortedDictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();

                string currentIP = input[0];
                string currentName = input[1];
                int currentDuration = int.Parse(input[2]);

                if (!usersLogs.ContainsKey(currentName))
                {
                    usersLogs[currentName] = new SortedDictionary<string, int>();
                }
                if (!usersLogs[currentName].ContainsKey(currentIP))
                {
                    usersLogs[currentName][currentIP] = 0;
                }
                usersLogs[currentName][currentIP] += currentDuration;

            }

            foreach (var name in usersLogs)
            {
                Console.Write($"{name.Key}: ");
                string toPrint = string.Empty;
                int currentNameLogsSum = name.Value.Values.Sum();
                toPrint += currentNameLogsSum.ToString() + " [";
                foreach (var item in name.Value)
                {
                    string currIP = item.Key;
                    toPrint += currIP + ", ";
                }
                toPrint = toPrint.Substring(0, toPrint.Length - 2);
                toPrint += "]";
                Console.WriteLine(toPrint);
            }

        }
    }
}
