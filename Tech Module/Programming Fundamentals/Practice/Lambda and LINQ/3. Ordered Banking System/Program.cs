using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Ordered_Banking_System
{
    class OrderedBankingSystem
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, decimal>> bankSystem =
                new Dictionary<string, Dictionary<string, decimal>>();

            string inputLine = Console.ReadLine();

            while (inputLine != "end")
            {
                string[] parameters = inputLine
                    .Split(new[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string bank = parameters[0];
                string account = parameters[1];
                decimal balance = decimal.Parse(parameters[2]);

                if (! bankSystem.ContainsKey(bank))
                {
                    bankSystem[bank] = new Dictionary<string, decimal>();
                }
                if (! bankSystem[bank].ContainsKey(account))
                {
                    bankSystem[bank].Add(account, 0);
                }
                bankSystem[bank][account] += balance;
                
                inputLine = Console.ReadLine();
            }


            bankSystem = bankSystem.
                OrderByDescending(bank => bank.Value.Sum(account => account.Value))
                .ThenByDescending(bank => bank.Value.Max(account => account.Value))
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var bank in bankSystem)
            {
                foreach (var accounts in bank.Value.OrderByDescending(account => account.Value))
                {
                    Console.WriteLine($"{accounts.Key} -> {accounts.Value} ({bank.Key})");
                }
            }
        }
    }
}
