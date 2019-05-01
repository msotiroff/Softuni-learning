namespace P03_SalesDatabaseInitializer
{
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data;
    using P03_SalesDatabaseInitializer.Generators;
    using System;

    public class DatabaseInitializer
    {
        private static Random rnd = new Random();

        public static void ResetDatabase()
        {
            using (var db = new SalesContext())
            {
                db.Database.EnsureDeleted();

                db.Database.Migrate();

                InitialSeed(db);
            }
        }

        public static void InitialSeed(SalesContext db)
        {
            SeedProducts(db, 100);

            SeedStores(db);

            SeedCustomers(db, 80);

            SeedSales(db, 120);
        }

        private static void SeedCustomers(SalesContext db, int count)
        {
            CustomerGenerator.InitialCustomersSeed(db, count);
        }

        private static void SeedStores(SalesContext db)
        {
            StoreGenerator.InitialStoresSeed(db);
        }

        private static void SeedSales(SalesContext db, int count)
        {
            SaleGenerator.InitialSalesSeed(db, count);
        }

        private static void SeedProducts(SalesContext db, int count)
        {
            ProductGenerator.InitialProductsSeed(db, count);
        }
    }
}
