namespace P03_SalesDatabaseInitializer.Generators
{
    using P03_SalesDatabase.Data;
    using P03_SalesDatabase.Data.Models;
    using System;

    public class ProductGenerator
    {
        private static Random rnd = new Random();

        private static string[] productNames = new string[]
            {
                "apples",
                "bacon",
                "baked beans",
                "basil",
                "beer",
                "biscuits",
                "bloody mary",
                "burritos",
                "cake",
                "calzone",
                "cheese",
                "chicken",
                "chinese food",
                "chips",
                "chocolate",
                "cider",
                "coffee",
                "cola",
                "cornettos",
                "cottage pie",
                "courgettes",
                "couscous",
                "cream",
                "crisps",
                "crumbs off of the floor",
                "curry",
                "custard",
                "dried fruit",
                "fish fingers",
                "ginger",
                "ham",
                "jam",
                "lamb",
                "lasagna",
                "leeks",
                "lemondade",
                "lobster thermadore",
                "marshmallows",
                "mushrooms",
                "mussels",
                "oysters",
                "pasta",
                "peanuts",
                "pears",
                "pizza",
                "popcorn",
                "pork",
                "potatoes",
                "puff pastry",
                "risotto",
                "rum",
                "salami",
                "salmon",
                "spaghetti",
                "steak",
                "stew",
                "tea",
                "tomatoes",
                "veal",
                "vodka"
            };

        internal static void InitialProductsSeed(SalesContext db, int count)
        {
            for (int i = 0; i < count; i++)
            {
                db.Products.Add(NewProduct());
                db.SaveChanges();
            }
        }

        public static Product NewProduct()
        {
            Product product = new Product
            {
                Name = GenerateProductName(),
                Price = GeneratePrice(),
                Quantity = GenerateQuantity()
            };

            return product;
        }

        private static double GenerateQuantity()
        {
            double maxQuantity = 50.00;
            double minQuantity = 1.00;

            // returns random real number in range [minQuantity - maxQuantity]:
            double quantity = rnd.NextDouble() * (maxQuantity - minQuantity);

            return Math.Round(quantity, 2);
        }

        private static decimal GeneratePrice()
        {
            double maxPrice = 100.00;
            double minPrice = 0.05;

            // returns random real number in range [minPrice - maxPrice]:
            double result = rnd.NextDouble() * (maxPrice - minPrice);

            return Convert.ToDecimal(result);
        }

        private static string GenerateProductName()
        {
            return productNames[rnd.Next(0, productNames.Length)];
        }
    }
}
