namespace CHUSHKA.Services.Models.Product
{
    using CHUSHKA.Common.AutoMapping;
    using CHUSHKA.Models;

    public class ProductListServiceModel : IMapWith<Product>
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public decimal Price { get; set; }
        
        public string Description { get; set; }
        
        public string ProductTypeName { get; set; }
    }
}
