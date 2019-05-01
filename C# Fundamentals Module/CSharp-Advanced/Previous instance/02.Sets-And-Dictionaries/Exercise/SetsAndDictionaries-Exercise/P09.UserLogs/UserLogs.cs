namespace P09.UserLogs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserLogs
    {
        public static void Main(string[] args)
        {
            var userLogs = new Dictionary<string, Dictionary<string, int>>();

            // Input format: IP={IP.Address} message=’{A&sample&message}’ user={username}
            string inputLine;
            while ((inputLine = Console.ReadLine()) != "end")
            {
                var inputParams = inputLine
                    .Split(new[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var currentIP = inputParams.Skip(1).First();
                var currentUsername = inputParams.Last();

                if (!userLogs.ContainsKey(currentUsername))
                {
                    userLogs[currentUsername] = new Dictionary<string, int>();
                }

                if (!userLogs[currentUsername].ContainsKey(currentIP))
                {
                    userLogs[currentUsername][currentIP] = 0;
                }

                userLogs[currentUsername][currentIP]++;
            }

            // Print result:
            foreach (var user in userLogs.OrderBy(u => u.Key))
            {
                Console.WriteLine($"{user.Key}: ");

                var currentUserLogs = user
                    .Value
                    .Select(l => $"{l.Key} => {l.Value}")
                    .ToArray();

                Console.WriteLine($"{string.Join(", ", currentUserLogs)}.");
            }
        }
    }
}
