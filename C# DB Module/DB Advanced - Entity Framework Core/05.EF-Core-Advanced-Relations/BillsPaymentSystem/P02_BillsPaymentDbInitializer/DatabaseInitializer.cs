namespace P02_BillsPaymentDbInitializer
{
    using System;
    using P02_BillsPaymentDbInitializer.Generators;
    using P01_BillsPaymentSystem.Data;
    using Microsoft.EntityFrameworkCore;

    public class DatabaseInitializer
    {
        private static Random rnd = new Random();

        public static void ResetDatabase()
        {
            using (var db = new BillsPaymentSystemContext())
            {
                db.Database.EnsureDeleted();

                db.Database.Migrate();

                InitialSeed(db);
            }
        }

        public static void InitialSeed(BillsPaymentSystemContext db)
        {
            SeedUsers(db);

            SeedBankAccounts(db, 150);

            SeedCreditCards(db, 150);

            SeedPayments(db);
        }

        private static void SeedPayments(BillsPaymentSystemContext db)
        {
            PaymentMethodsGenerator.InitialPaymentMethodsSeed(db);
        }

        private static void SeedCreditCards(BillsPaymentSystemContext db, int count)
        {
            CreditCardGenerator.InitialCreditCardSeed(db, count);
        }

        private static void SeedBankAccounts(BillsPaymentSystemContext db, int count)
        {
            BankAccountGenerator.InitialBankAccountSeed(db, count);
        }

        private static void SeedUsers(BillsPaymentSystemContext db)
        {
            UserGenerator.InitialUserSeed(db);
        }
    }
}
