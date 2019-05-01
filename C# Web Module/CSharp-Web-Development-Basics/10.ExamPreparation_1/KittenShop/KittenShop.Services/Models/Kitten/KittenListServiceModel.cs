namespace KittenShop.Services.Models.Kitten
{
    using KittenShop.Common.AutoMapping;
    using KittenShop.Models;

    public class KittenListServiceModel : IMapWith<Kitten>
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int Age { get; set; }
        
        public string BreedName { get; set; }
        
        public string OwnerUsername { get; set; }        
    }
}
