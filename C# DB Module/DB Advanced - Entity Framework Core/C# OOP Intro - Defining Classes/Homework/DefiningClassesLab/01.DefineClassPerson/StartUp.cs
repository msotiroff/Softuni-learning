using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class StartUp
{
    static void Main(string[] args)
    {
        BankAccount currentAccount = new BankAccount();

        currentAccount.ID = 1;
        currentAccount.Balance = 1000.00m;

        Console.WriteLine($"Account number: {currentAccount.ID}, Balance: {currentAccount.Balance:f2}");
    }
}
