namespace P03_UserDetailsMenu
{
    using Microsoft.EntityFrameworkCore;
    using P01_BillsPaymentSystem.Data;
    using System;
    using System.Globalization;
    using System.Linq;

    public class UserDeatailsRetriever
    {
        public static void Run()
        {
            Console.Write("Enter user id: ");
            string input = Console.ReadLine();
            Console.WriteLine(new string('-', 20));
            int userId;
            if (!int.TryParse(input, out userId))
            {
                Console.Clear();
                Console.WriteLine($"{input} is not a valid number!");
                Console.WriteLine("Please, enter a valid number!");
                Console.WriteLine(new string('-', 20));
                Run();
            }

            using (var db = new BillsPaymentSystemContext())
            {
                var neededUserId = db.Users
                                    .Where(u => u.UserId == userId)
                                    .Select(u => u.UserId)
                                    .FirstOrDefault();

                if (neededUserId != 0)
                {
                    PrintUserDetails(neededUserId, db);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"User with id {userId} not found!");
                    Console.WriteLine(new string('-', 20));
                }
            }
        }

        private static void PrintUserDetails(int neededUserId, BillsPaymentSystemContext db)
        {
            var userToPrint = db
                .Users
                .FirstOrDefault(u => u.UserId == neededUserId);

            var userBankAccounts = db
                .BankAcoounts
                .Include(ba => ba.PaymentMethod)
                .ThenInclude(pm => pm.User)
                .Where(ba => ba.PaymentMethod.UserId == neededUserId)
                .ToList();

            var userCreditCards = db
                .CreditCards
                .Include(cc => cc.PaymentMethod)
                .ThenInclude(pm => pm.User)
                .Where(cc => cc.PaymentMethod.UserId == neededUserId)
                .ToList();

            Console.WriteLine($"User: {userToPrint.FirstName} {userToPrint.LastName}");
            if (userBankAccounts.Any())
            {
                Console.WriteLine("Bank Accounts:");

                foreach (var bankAcc in userBankAccounts)
                {
                    Console.WriteLine($"-- ID: {bankAcc.BankAccountId}");
                    Console.WriteLine($"--- Balance: {bankAcc.Balance:f2}");
                    Console.WriteLine($"--- Bank: {bankAcc.BankName}");
                    Console.WriteLine($"--- SWIFT: {bankAcc.SWIFTCode}");
                }
            }
            else
            {
                Console.WriteLine($"User {userToPrint.FirstName} {userToPrint.LastName} doesn't have any bank accounts");
            }
            if (userCreditCards.Any())
            {
                Console.WriteLine("Credit Cards:");

                foreach (var card in userCreditCards)
                {
                    Console.WriteLine($"-- ID: {card.CreditCardId}");
                    Console.WriteLine($"--- Limit: {card.Limit:f2}");
                    Console.WriteLine($"--- Money Owed: {card.MoneyOwed:f2}");
                    Console.WriteLine($"--- Limit Left:: {card.GetLimitLeft():f2}");
                    Console.WriteLine($"--- Expiration Date: {card.ExpirationDate.ToString("yyyy/MM", CultureInfo.InvariantCulture)}");
                }
            }
            else
            {
                Console.WriteLine($"User {userToPrint.FirstName} {userToPrint.LastName} doesn't have any credit cards");
            }

            Console.WriteLine(new string('-', 20));
        }
    }
}
