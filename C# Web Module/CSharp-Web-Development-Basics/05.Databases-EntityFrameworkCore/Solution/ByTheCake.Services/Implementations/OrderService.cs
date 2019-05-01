namespace ByTheCake.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ByTheCake.Models;
    using ByTheCake.Services.Models;
    using Contracts;
    using Microsoft.EntityFrameworkCore;

    public class OrderService : DataAccessService, IOrderService
    {
        public async Task<int> Create(OrderCreateServiceModel model)
        {
            var products = await this.db
                .Products
                .Where(p => model.ProductsIds.Contains(p.Id))
                .Select(p => new OrderProduct
                {
                    ProductId = p.Id
                })
                .ToListAsync();

            var order = new Order
            {
                CreationDate = model.CreationDate,
                UserId = model.UserId,
                TotalSum = model.TotalSum,
                Products = products
            };

            await this.db.AddAsync(order);
            await this.db.SaveChangesAsync();

            return order.Id;
        }

        public async Task<OrderListServiceModel> GetById(int orderId)
        {
            var order = await this.db
                .Orders
                .Where(o => o.Id == orderId)
                .Select(o => new OrderListServiceModel
                {
                    Id = o.Id,
                    CreationDate = o.CreationDate,
                    Products = o.Products
                        .Select(op => new ProductListServiceModel
                        {
                            Id = op.ProductId,
                            Name = op.Product.Name,
                            ImageUrl = op.Product.ImageUrl,
                            Price = op.Product.Price
                        }).ToList()
                })
                .FirstOrDefaultAsync();

            return order;
        }

        public async Task<IEnumerable<OrderListServiceModel>> GetByUserId(int userId)
        {
            var orders = await this.db
                .Orders
                .Where(o => o.UserId == userId)
                .Select(o => new OrderListServiceModel
                {
                    Id = o.Id,
                    CreationDate = o.CreationDate,
                    TotalSum = o.TotalSum,
                    Products = o.Products
                        .Select(op => new ProductListServiceModel
                        {
                            Id = op.ProductId,
                            Name = op.Product.Name,
                            ImageUrl = op.Product.ImageUrl,
                            Price = op.Product.Price
                        })
                        .ToList()
                }).ToListAsync();

            return orders;
        }
    }
}
