namespace _6.User_Logs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class UserLogs
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, int>> usersDatabase =
                new SortedDictionary<string, Dictionary<string, int>>();

            string inputLine = Console.ReadLine();


            while (inputLine != "end")
            {
                string[] inputParameters = inputLine
                    .Split(new[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string ipAdress = inputParameters[1];
                string userName = inputParameters[inputParameters.Length - 1];

                if (!usersDatabase.ContainsKey(userName))
                {
                    usersDatabase[userName] = new Dictionary<string, int>();
                    usersDatabase[userName][ipAdress] = 0;
                }
                if (!usersDatabase[userName].ContainsKey(ipAdress))
                {
                    usersDatabase[userName][ipAdress] = 0;
                }
                usersDatabase[userName][ipAdress] += 1;

                inputLine = Console.ReadLine();
            }

            PrintResults(usersDatabase);

        }

        public static void PrintResults(SortedDictionary<string, Dictionary<string, int>> usersDatabase)
        {
            foreach (var item in usersDatabase)
            {
                Console.WriteLine($"{item.Key}: ");
                var ipAndCounters = item.Value;
                string toPrint = string.Empty;
                foreach (var ipCountPair in ipAndCounters)
                {
                    toPrint += ipCountPair.Key + " => " + ipCountPair.Value + ", ";
                }
                toPrint = toPrint.Substring(0, toPrint.Length - 2);
                toPrint += ".";
                Console.WriteLine(toPrint);
            }
        }
    }
}
