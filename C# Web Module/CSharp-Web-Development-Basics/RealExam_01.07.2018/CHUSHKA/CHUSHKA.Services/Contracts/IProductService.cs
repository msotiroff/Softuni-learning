namespace CHUSHKA.Services.Contracts
{
    using CHUSHKA.Models;
    using CHUSHKA.Services.Models.Product;
    using System.Collections.Generic;

    public interface IProductService
    {
        IEnumerable<ProductListServiceModel> All();

        ProductListServiceModel GetById(int id);

        int Create(string name, decimal price, string description, int productTypeId);

        bool Update(int id, string name, decimal price, string description, int productTypeId);

        bool Delete(int id);

        IEnumerable<ProductType> GetAllProductTypes();
    }
}
