namespace ByTheCake.Services.Contracts
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IOrderService
    {
        Task<int> Create(OrderCreateServiceModel model);

        Task<IEnumerable<OrderListServiceModel>> GetByUserId(int userId);

        Task<OrderListServiceModel> GetById(int orderId);
    }
}
