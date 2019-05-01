namespace P02_BillsPaymentDbInitializer.Generators
{
    using P01_BillsPaymentSystem.Data;
    using P01_BillsPaymentSystem.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PaymentMethodsGenerator
    {
        private static Random rnd = new Random();

        private static PaymentType[] paymentTypes =
        {
            PaymentType.BankAccount,
            PaymentType.CreditCard
        };

        internal static void InitialPaymentMethodsSeed(BillsPaymentSystemContext db)
        {
            var allUsersIds = db.Users.Select(u => u.UserId).ToArray();
            var allCreditCardsIds = db.CreditCards.Select(cc => cc.CreditCardId).ToArray();
            var allBankAccIds = db.BankAcoounts.Select(ba => ba.BankAccountId).ToArray();

            Stack<int> creditCards = new Stack<int>(allCreditCardsIds);
            Stack<int> bankAccounts = new Stack<int>(allBankAccIds);

            var allPaymentMethods = new List<PaymentMethod>();

            for (int i = 0; i < allUsersIds.Count(); i++)
            {
                var currentPaymentMethod = new PaymentMethod();
                currentPaymentMethod.UserId = allUsersIds[i];

                if (i % 2 == 0)
                {
                    currentPaymentMethod.PaymentType = PaymentType.BankAccount;
                    currentPaymentMethod.BankAccountId = bankAccounts.Pop();
                }
                else
                {
                    currentPaymentMethod.PaymentType = PaymentType.CreditCard;
                    currentPaymentMethod.CreditCardId = creditCards.Pop();
                }

                allPaymentMethods.Add(currentPaymentMethod);
            }

            db.PaymentMethods.AddRange(allPaymentMethods);
            
            db.SaveChanges();
        }
    }
}
