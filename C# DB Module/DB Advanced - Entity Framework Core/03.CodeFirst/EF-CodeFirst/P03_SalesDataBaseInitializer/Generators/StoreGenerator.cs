namespace P03_SalesDatabaseInitializer.Generators
{
    using P03_SalesDatabase.Data;
    using P03_SalesDatabase.Data.Models;
    using System;

    public class StoreGenerator
    {
        private static Random rnd = new Random();

        private static string[] storeNames = new string[]
                        {
                            "Billa",
                            "Lidl",
                            "Kaufland",
                            "Tesco",
                            "Asda",
                            "Fantastiko",
                            "CBA"
                        };

        internal static void InitialStoresSeed(SalesContext db)
        {
            for (int i = 0; i < storeNames.Length; i++)
            {
                Store currentStore = new Store()
                {
                    Name = storeNames[i]
                };

                db.Stores.Add(currentStore);
                db.SaveChanges();
            }
        }

        public Store NewStore()
        {
            Store store = new Store()
            {
                Name = GenerateStoreName()
            };

            return store;
        }

        private string GenerateStoreName()
        {
            return storeNames[rnd.Next(0, storeNames.Length)];
        }
    }
}
