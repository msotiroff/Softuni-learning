namespace KittenShop.App.Infrastructure.Extensions
{
    using KittenShop.Data;
    using KittenShop.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public static class DatabaseExtensions
    {
        internal static readonly string[] DefaultBreedsList = new string[]
            {
                "Street Transcended",
                "American Shorthair",
                "Munchkin",
                "Siamese"
            };

        public static KittenShopDbContext AddDefaultBreeds(this KittenShopDbContext context)
        {
            context.Database.Migrate();

            var breedsToBeSeeded = new List<Breed>();

            foreach (var breedName in DefaultBreedsList)
            {
                var exist = context.Breeds.Any(br => br.Name == breedName);

                if (!exist)
                {
                    breedsToBeSeeded.Add(new Breed { Name = breedName });
                }
            }

            context.Breeds.AddRange(breedsToBeSeeded);
            context.SaveChanges();

            return context;
        }
    }
}
