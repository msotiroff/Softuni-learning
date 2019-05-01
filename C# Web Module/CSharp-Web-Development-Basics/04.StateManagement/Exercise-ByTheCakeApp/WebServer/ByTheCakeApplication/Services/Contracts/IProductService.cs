namespace HTTPServer.ByTheCakeApplication.Services.Contracts
{
    using System.Collections.Generic;
    using ViewModels;

    public interface IProductService
    {
        void Create(string name, decimal price);
        IEnumerable<ProductViewModel> GetAll();
        ProductViewModel Get(string name);
    }
}
