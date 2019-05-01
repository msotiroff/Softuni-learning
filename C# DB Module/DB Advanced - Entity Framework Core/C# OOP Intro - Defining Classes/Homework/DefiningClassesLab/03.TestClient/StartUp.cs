using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.TestClient
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var allAccounts = new Dictionary<int, BankAccount>();

            string commands;
            while ((commands = Console.ReadLine()) != "End")
            {
                string[] commandParameters = commands.Split(' ').ToArray();
                string mainCommand = commandParameters[0];
                int accountId = int.Parse(commandParameters[1]);

                if (mainCommand == "Create")
                {
                    if (allAccounts.ContainsKey(accountId))
                    {
                        Console.WriteLine("Account already exists");
                    }
                    else
                    {
                        var accountToCreate = new BankAccount();
                        accountToCreate.ID = accountId;
                        accountToCreate.Balance = 0;

                        allAccounts.Add(accountId, accountToCreate);
                    }
                }
                else if(mainCommand == "Deposit")
                {
                    decimal amountToDeposit = decimal.Parse(commandParameters[2]);
                    if (! allAccounts.ContainsKey(accountId))
                    {
                        Console.WriteLine("Account does not exist");
                    }
                    else
                    {
                        allAccounts[accountId].Deposit(amountToDeposit);
                    }
                }
                else if (mainCommand == "Withdraw")
                {
                    decimal amountToWithdraw = decimal.Parse(commandParameters[2]);
                    if (!allAccounts.ContainsKey(accountId))
                    {
                        Console.WriteLine("Account does not exist");
                    }
                    else
                    {
                        if (allAccounts[accountId].Balance < amountToWithdraw)
                        {
                            Console.WriteLine("Insufficient balance");
                        }
                        else
                        {
                            allAccounts[accountId].Withdraw(amountToWithdraw);
                        }                        
                    }
                }
                else if (mainCommand == "Print")
                {
                    if (!allAccounts.ContainsKey(accountId))
                    {
                        Console.WriteLine("Account does not exist");
                    }
                    else
                    {
                        Console.WriteLine($"Account ID {allAccounts[accountId].ID}, " +
                        $"balance = {allAccounts[accountId].Balance:f2}");
                    }
                    
                }
            }
        }
    }
}
