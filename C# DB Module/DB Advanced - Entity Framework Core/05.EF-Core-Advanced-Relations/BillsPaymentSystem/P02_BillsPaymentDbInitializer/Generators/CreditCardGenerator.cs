namespace P02_BillsPaymentDbInitializer.Generators
{
    using P01_BillsPaymentSystem.Data;
    using P01_BillsPaymentSystem.Data.Models;
    using System;

    public class CreditCardGenerator
    {
        private static Random rnd = new Random();

        internal static void InitialCreditCardSeed(BillsPaymentSystemContext db, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var limit = GenerateRandomLimit();
                var owedMoney = GenerateRandomOwedMoney(limit);
                var limitLeft = limit - owedMoney;

                var currentCard = new CreditCard(limit, owedMoney, GenerateDate());

                db.CreditCards.Add(currentCard);
                db.SaveChanges();
            }
        }

        private static decimal GenerateRandomLimit()
        {
            var limit = rnd.NextDouble() * 50_000;

            return Convert.ToDecimal(limit);
        }

        private static decimal GenerateRandomOwedMoney(decimal limit)
        {
            var moneyOwed = limit - (decimal)rnd.NextDouble() * limit;

            return moneyOwed;
        }
        

        private static DateTime GenerateDate()
        {
            var date = DateTime.Now;

            return date.AddDays(rnd.Next(1, 730));
        }
    }
}
