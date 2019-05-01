namespace P03_SalesDatabaseInitializer.Generators
{
    using P03_SalesDatabase.Data;
    using P03_SalesDatabase.Data.Models;
    using System;
    using System.Linq;

    public class SaleGenerator
    {
        private static Random rnd = new Random();

        internal static void InitialSalesSeed(SalesContext db, int count)
        {
            for (int i = 0; i < count; i++)
            {
                db.Sales.Add(NewSale(db));
                db.SaveChanges();
            }
        }

        private static Sale NewSale(SalesContext db)
        {
            Sale sale = new Sale()
            {
                Date = GenerateDate(),
                CustomerId = GetRandomCustomerFromDb(db),
                ProductId = GetRandomProductFromDb(db),
                StoreId = GetRandomStoreFromDb(db)
            };

            return sale;
        }

        private static int GetRandomStoreFromDb(SalesContext db)
        {
            var allStores = db.Stores.Select(s => s.StoreId).ToArray();

            var storeId = allStores[rnd.Next(0, allStores.Length)];

            return storeId;
        }

        private static int GetRandomProductFromDb(SalesContext db)
        {
            var allProducts = db.Products.Select(p => p.ProductId).ToArray();

            var productId = allProducts[rnd.Next(0, allProducts.Length)];

            return productId;
        }

        private static int GetRandomCustomerFromDb(SalesContext db)
        {
            var allCustomers = db.Customers.Select(c => c.CustomerId).ToArray();

            var customerId = allCustomers[rnd.Next(0, allCustomers.Length)];

            return customerId;
        }

        private static DateTime GenerateDate()
        {
            DateTime startDate = new DateTime(2000, 01, 01);
            DateTime today = DateTime.Now;

            int daysDifference = (today - startDate).Days;

            // returns a date in range [startDate, today]:
            var date = startDate.AddDays(rnd.Next(0, daysDifference));

            return date;
        }
    }
}
