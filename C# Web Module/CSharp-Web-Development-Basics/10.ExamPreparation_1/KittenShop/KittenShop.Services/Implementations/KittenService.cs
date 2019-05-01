namespace KittenShop.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using KittenShop.Models;
    using KittenShop.Services.Models.Kitten;

    public class KittenService : DataAccessService, IKittenService
    {
        public bool Add(string name, string breed, int age, int ownerId)
        {
            var kitten = new Kitten
            {
                Name = name,
                Breed = this.db.Breeds.FirstOrDefault(br => br.Name == breed),
                Age = age,
                OwnerId = ownerId
            };

            if (!this.ValidateModelState(kitten))
            {
                return false;
            }

            this.db.Kittens.Add(kitten);
            this.db.SaveChanges();

            return true;
        }

        public IEnumerable<KittenListServiceModel> All()
        {
            var kittens = this.db
                .Kittens
                .ProjectTo<KittenListServiceModel>()
                .ToArray();

            return kittens;
        }
    }
}
