namespace ByTheCake.Services.Contracts
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductService
    {
        Task<int> Create(ProductCreateServiceModel model);

        Task<IEnumerable<ProductListServiceModel>> GetAll();

        Task<ProductListServiceModel> GetById(int id);

        Task<decimal> GetProductsPricesSum(ICollection<int> productsIds);
    }
}
