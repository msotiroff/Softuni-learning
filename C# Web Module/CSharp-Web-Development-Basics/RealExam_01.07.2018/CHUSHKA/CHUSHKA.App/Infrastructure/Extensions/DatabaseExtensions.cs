namespace CHUSHKA.App.Infrastructure.Extensions
{
    using CHUSHKA.Data;
    using CHUSHKA.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public static class DatabaseExtensions
    {
        public static CHUSHKADbContext SeedData(this CHUSHKADbContext context)
        {
            context.Database.Migrate();

            SeedProductTypes(context);

            return context;
        }

        private static void SeedProductTypes(CHUSHKADbContext context)
        {
            var availableProductTypes = new string[]
            {
                "Food", "Domestic", "Health", "Cosmetic", "Other"
            };

            var productTypesToSeed = new HashSet<ProductType>();

            foreach (var typeName in availableProductTypes)
            {
                if (!context.ProductTypes.Any(pt => pt.Name == typeName))
                {
                    productTypesToSeed.Add(new ProductType { Name = typeName });
                }
            }

            context.ProductTypes.AddRange(productTypesToSeed);
            context.SaveChanges();
        }
    }
}
