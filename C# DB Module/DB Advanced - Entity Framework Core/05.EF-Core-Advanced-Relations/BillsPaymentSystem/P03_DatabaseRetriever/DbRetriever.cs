namespace P03_DatabaseRetriever
{
    using System;
    using P01_BillsPaymentSystem.Data;
    using P01_BillsPaymentSystem.Data.Models;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public class DbRetriever
    {
        public void RetrieveUserDetails()
        {
            while (true)
            {
                Console.WriteLine("To exit this menu just press enter");
                Console.WriteLine("Enter an user id:");

                string input = Console.ReadLine();
                int userId;

                if (int.TryParse(Console.ReadLine(), out userId))
                {
                    using (var db = new BillsPaymentSystemContext())
                    {
                        var allUsers = db.Users
                            .Include(u => u.PaymentMethods)
                            .ToList();

                        var neededUser = allUsers.FirstOrDefault(u => u.UserId == userId);

                        if (neededUser != null)
                        {
                            PrintDetails(neededUser);
                        }
                        else
                        {
                            Console.WriteLine($"User with id {userId} not found!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input!");
                }
            }
        }

        private void PrintDetails(User neededUser)
        {
            throw new NotImplementedException();
        }
    }
}
