namespace ByTheCake.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ByTheCake.Models;
    using ByTheCake.Services.Models;
    using Contracts;
    using Microsoft.EntityFrameworkCore;

    public class ProductService : DataAccessService, IProductService
    {
        public async Task<int> Create(ProductCreateServiceModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                ImageUrl = model.ImageUrl
            };

            await this.db.Products.AddAsync(product);
            await this.db.SaveChangesAsync();

            return product.Id;
        }

        public async Task<IEnumerable<ProductListServiceModel>> GetAll()
        {
            var allProducts = await this.db
                .Products
                .Select(p => new ProductListServiceModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                })
                .ToListAsync();

            return allProducts;
        }

        public async Task<ProductListServiceModel> GetById(int id)
        {
            var product = await this.db
                .Products
                .Where(p => p.Id == id)
                .Select(p => new ProductListServiceModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl
                })
                .FirstOrDefaultAsync();

            return product;
        }

        public async Task<decimal> GetProductsPricesSum(ICollection<int> productsIds)
        {
            var products = await this.db
                .Products
                .Where(p => productsIds.Contains(p.Id))
                .Select(p => p.Price)
                .ToListAsync();

            return products.Sum();
        }
    }
}
