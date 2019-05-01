namespace P11.LogsAggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LogsAggregator
    {
        public static void Main(string[] args)
        {
            int inputCount = int.Parse(Console.ReadLine());

            //                             <User, <IP, minutes>>
            var agregator = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < inputCount; i++)
            {
                var inputParams = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var currentUser = inputParams[1];
                var currentIp = inputParams[0];
                var currentSession = int.Parse(inputParams[2]);

                if (!agregator.ContainsKey(currentUser))
                {
                    agregator[currentUser] = new Dictionary<string, int>();
                }

                if (!agregator[currentUser].ContainsKey(currentIp))
                {
                    agregator[currentUser][currentIp] = 0;
                }

                agregator[currentUser][currentIp] += currentSession;
            }

            foreach (var user in agregator.OrderBy(a => a.Key))
            {
                var userName = user.Key;
                var duration = user.Value.Sum(v => v.Value);
                var ipAddresses = user.Value.Keys.OrderBy(ip => ip).ToArray();

                Console.WriteLine($"{userName}: {duration} [{string.Join(", ", ipAddresses)}]");
            }
        }
    }
}
