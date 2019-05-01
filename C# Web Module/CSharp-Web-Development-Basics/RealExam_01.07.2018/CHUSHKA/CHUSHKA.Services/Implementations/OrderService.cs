namespace CHUSHKA.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using CHUSHKA.Data;
    using CHUSHKA.Models;
    using CHUSHKA.Services.Models.Order;
    using Contracts;

    public class OrderService : DataAccessService, IOrderService
    {
        public OrderService(CHUSHKADbContext db)
            : base(db)
        {
        }

        public IEnumerable<OrderListServiceModel> All()
        {
            return this.db
                .Orders
                .ProjectTo<OrderListServiceModel>()
                .OrderByDescending(o => o.OrderedOn)
                .ToArray();
        }

        public bool Create(int productId, int userId)
        {
            try
            {
                var order = new Order
                {
                    ClientId = userId,
                    ProductId = productId,
                };

                this.db.Orders.Add(order);
                this.db.SaveChanges();

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
