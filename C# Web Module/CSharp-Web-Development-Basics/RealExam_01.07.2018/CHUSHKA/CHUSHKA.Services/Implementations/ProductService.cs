namespace CHUSHKA.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using CHUSHKA.Data;
    using CHUSHKA.Models;
    using CHUSHKA.Services.Models.Product;
    using Contracts;

    public class ProductService : DataAccessService, IProductService
    {
        public ProductService(CHUSHKADbContext db) 
            : base(db)
        {
        }

        public IEnumerable<ProductListServiceModel> All()
        {
            return this.db
                .Products
                .ProjectTo<ProductListServiceModel>()
                .ToArray();
        }

        public int Create(string name, decimal price, string description, int productTypeId)
        {
            var product = new Product
            {
                Name = name,
                Price = price,
                Description = description,
                ProductTypeId = productTypeId
            };

            if (!this.ValidateModelState(product))
            {
                return default(int);
            }

            try
            {
                this.db.Products.Add(product);
                this.db.SaveChanges();
            }
            catch (System.Exception)
            {
                return default(int);
            }

            return product.Id;
        }

        public bool Delete(int id)
        {
            var product = this.db.Products.Find(id);
            if (product == null)
            {
                return false;
            }

            this.db.Products.Remove(product);
            this.db.SaveChanges();

            return true;
        }

        public IEnumerable<ProductType> GetAllProductTypes() => this.db.ProductTypes.ToArray();

        public ProductListServiceModel GetById(int id)
        {
            var product = this.db.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return null;
            }

            return Mapper.Map<ProductListServiceModel>(product);
        }

        public bool Update(int id, string name, decimal price, string description, int productTypeId)
        {
            var product = this.db.Products.Find(id);
            if (product == null)
            {
                return false;
            }

            product.Name = name;
            product.Price = price;
            product.Description = description;
            product.Name = name;
            product.ProductTypeId = productTypeId;

            if (!this.ValidateModelState(product))
            {
                return false;
            }

            try
            {
                this.db.Products.Update(product);
                this.db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
