namespace P04_BillPayer
{
    using Microsoft.EntityFrameworkCore;
    using P01_BillsPaymentSystem.Data;
    using P01_BillsPaymentSystem.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BillPayer
    {
        public static void Run()
        {
            Console.WriteLine("For exit enter 'e'");
            Console.Write("Enter user id: ");
            string inputUserId = Console.ReadLine();
            if (inputUserId == "e")
            {
                Console.Clear();
                return;
            }
            int userId;
            if (!int.TryParse(inputUserId, out userId))
            {
                Console.Clear();
                Console.WriteLine($"{inputUserId} is not a valid number!");
                Console.WriteLine("Please, enter a valid number!");
                Console.WriteLine(new string('-', 20));
                Run();
                return;
            }

            using (var db = new BillsPaymentSystemContext())
            {
                var neededUserId = db.Users
                                    .Where(u => u.UserId == userId)
                                    .Select(u => u.UserId)
                                    .FirstOrDefault();

                if (neededUserId == 0)
                {
                    Console.Clear();
                    Console.WriteLine($"User with id {userId} not found!");
                    Run();
                    return;
                }
            }

            Console.Write("Enter Bill amount: ");
            string inputAmount = Console.ReadLine();
            decimal amount;

            if (!decimal.TryParse(inputAmount, out amount))
            {
                Console.Clear();
                Console.WriteLine($"{inputAmount} is not valid!");
                Console.Write("Please, enter valid amount");
                Run();
                return;
            }

            if (amount <= 0)
            {
                Console.Clear();
                Console.WriteLine("Amount can not be negative or zero!");
                Run();
                return;
            }


            PayBills(userId, amount);
        }

        private static void PayBills(int userId, decimal amount)
        {
            using (var db = new BillsPaymentSystemContext())
            {
                var paymentMethods = db
                    .PaymentMethods
                    .Where(pm => pm.UserId == userId)
                    .ToList();

                var userBankAccountsIds = new List<int>();
                var userCreditCardsIds = new List<int>();

                foreach (var method in paymentMethods)
                {
                    if (method.PaymentType == PaymentType.BankAccount && method.BankAccountId != null)
                    {
                        userBankAccountsIds.Add(method.BankAccountId.Value);
                    }
                    else if (method.PaymentType == PaymentType.CreditCard && method.CreditCardId != null)
                    {
                        userCreditCardsIds.Add(method.CreditCardId.Value);
                    }
                }

                foreach (var bankAccId in userBankAccountsIds.OrderBy(id => id))
                {
                    var currentAccountToWithdraw = db.BankAcoounts.Find(bankAccId);
                    var balance = currentAccountToWithdraw.Balance;

                    if (amount <= balance)
                    {
                        currentAccountToWithdraw.Withdraw(amount);
                        db.SaveChanges();
                        Console.Clear();
                        Console.WriteLine("The bill's paid success!");
                        Console.WriteLine(new string('-', 20));
                        break;
                    }
                    else
                    {
                        currentAccountToWithdraw.Withdraw(balance);
                        amount -= balance;
                    }
                }

                foreach (var crCardId in userCreditCardsIds)
                {
                    if (amount <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("The bill's paid success!");
                        Console.WriteLine(new string('-', 20));
                        break;
                    }

                    var curentCardToWithdraw = db.CreditCards.Find(crCardId);
                    var limitLeft = curentCardToWithdraw.LimitLeft;

                    if (amount <= limitLeft)
                    {
                        curentCardToWithdraw.Withdraw(amount);
                        db.SaveChanges();
                        Console.Clear();
                        Console.WriteLine("The bill's paid success!");
                        Console.WriteLine(new string('-', 20));
                        break;
                    }
                    else
                    {
                        curentCardToWithdraw.Withdraw(limitLeft);
                        amount -= limitLeft;
                    }
                }
            }
        }
    }
}
