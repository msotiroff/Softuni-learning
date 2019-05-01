using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.Optimized_Banking_System
{
    public class OptimizedBankingSystem
    {
        public static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            List<BankAccount> allAccountsData = new List<BankAccount>();

            while (inputLine != "end")
            {
                string[] inputParameters = inputLine
                    .Split(new[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                BankAccount currentBankAccount = new BankAccount
                {
                    BankName = inputParameters[0],
                    AccountName = inputParameters[1],
                    AccountBalance = decimal.Parse(inputParameters[2])
                };
                allAccountsData.Add(currentBankAccount);

                inputLine = Console.ReadLine();
            }

            foreach (var account in allAccountsData
                .OrderByDescending(bal => bal.AccountBalance)
                .ThenBy(name => name.BankName.Length))
            {
                Console.WriteLine($"{account.AccountName} -> {account.AccountBalance} ({account.BankName})");
            }

        }
    }
}
