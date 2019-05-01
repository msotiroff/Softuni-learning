namespace P02_BillsPaymentDbInitializer.Generators
{
    using P01_BillsPaymentSystem.Data;
    using P01_BillsPaymentSystem.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BankAccountGenerator
    {
        private static Random rnd = new Random();

        private static List<string> banks = new List<string>()
        {
            "Alianz Bank-BUINBGSF",
            "DSK-STSABGSF",
            "BNB-BNBGBGSD",
            "Invest Bank-IORTBGSF",
            "United Bulgarian Bank-UBBSBGSF",
            "ProCredit Bank-PRCBBGSF",
            "First Investment Bank-FINVBGSF",
            "Reiffeisen Bank-RZBBBGSF",
            "Unicredit BulBank-UNCRBGSF",
            "Central Cooperative Bank-CECBBGSF"
        };

        internal static void InitialBankAccountSeed(BillsPaymentSystemContext db, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var randomIndex = rnd.Next(0, banks.Count);
                var bankName = banks[randomIndex].Split('-').First();
                var bankSwift = banks[randomIndex].Split('-').Last();

                var currentBankAccount = 
                    new BankAccount(GenerateRandomBalance(), bankName, bankSwift);

                db.BankAcoounts.Add(currentBankAccount);
                db.SaveChanges();
            }
        }

        private static decimal GenerateRandomBalance()
        {
            var balance = rnd.NextDouble() * 1_000_000;

            return Convert.ToDecimal(balance);
        }
    }
}
