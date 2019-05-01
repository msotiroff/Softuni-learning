namespace KittenShop.Services.Contracts
{
    using Models.Kitten;
    using System.Collections.Generic;

    public interface IKittenService
    {
        bool Add(string name, string breed, int age, int ownerId);

        IEnumerable<KittenListServiceModel> All();
    }
}
