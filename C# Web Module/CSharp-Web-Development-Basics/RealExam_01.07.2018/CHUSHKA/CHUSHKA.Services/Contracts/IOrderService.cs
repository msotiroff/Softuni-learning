namespace CHUSHKA.Services.Contracts
{
    using CHUSHKA.Services.Models.Order;
    using System.Collections.Generic;

    public interface IOrderService
    {
        bool Create(int productId, int userId);

        IEnumerable<OrderListServiceModel> All();
    }
}
