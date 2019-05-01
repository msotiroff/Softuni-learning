namespace ByTheCake.App.Controllers
{
    using HTTPServer.Http;
    using HTTPServer.Http.Contracts;
    using HTTPServer.Http.Response;
    using Services.Contracts;
    using Services.Implementations;
    using Services.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ViewModels;

    public class ShoppingController : BaseController
    {
        private const string ProductIdKey = "id";
        private const string ShowSuccessKey = "showSuccess";
        private const string CartItemsKey = "cartItems";
        private const string TotalCostKey = "totalCost";

        private IProductService productService;
        private IOrderService orderService;

        public ShoppingController()
        {
            this.productService = new ProductService();
            this.orderService = new OrderService();
        }

        public async Task<IHttpResponse> AddToCart(IHttpRequest request)
        {
            var urlParams = request.UrlParameters;

            if (!urlParams.ContainsKey(ProductIdKey))
            {
                return new NotFoundResponse();
            }

            var productId = int.Parse(urlParams[ProductIdKey]);
            
            var productExist = await this.productService.GetById(productId) != null;

            if (!productExist)
            {
                return new NotFoundResponse();
            }

            var shoppingCart = request
                .Session
                .Get<ShoppingCartSessionModel>(SessionStore.CurrentShoppingCartSessionKey);

            shoppingCart.ProductsIds.Add(productId);

            return new RedirectResponse("/search");
        }
        
        public IHttpResponse CartDetails(IHttpRequest request)
        {
            var shoppingCart = request
                .Session
                .Get<ShoppingCartSessionModel>(SessionStore.CurrentShoppingCartSessionKey);

            if (!shoppingCart.ProductsIds.Any())
            {
                this.ViewData[ShowSuccessKey] = "none";
                this.ViewData[CartItemsKey] = "You have no cakes in your cart!";
                this.ViewData[TotalCostKey] = "0.00";
            }
            else
            {
                var productsInCart = shoppingCart.ProductsIds;

                var productsData = this.productService
                    .GetAll()
                    .Result
                    .Where(p => productsInCart.Contains(p.Id))
                    .Select(p => new ProductViewModel(p.Id, p.Name, p.Price));

                var items = productsData
                    .Select(pr => $"<div>{pr.Name} - ${pr.Price:f2}</div><br />");

                var totalPrice = productsData
                    .Sum(pr => pr.Price);
                
                this.ViewData[CartItemsKey] = string.Join(string.Empty, items);
                this.ViewData[TotalCostKey] = $"{totalPrice:f2}";
            }

            return this.FileViewResponse(@"Shopping\Cart");
        }

        public async Task<IHttpResponse> OrderDetails(IDictionary<string, string> urlParams)
        {
            if (!urlParams.ContainsKey("id"))
            {
                return new NotFoundResponse();
            }

            var orderId = urlParams["id"];
            if (orderId == null)
            {
                return new NotFoundResponse();
            }

            var orderDetails = await this.orderService.GetById(int.Parse(orderId));

            var productsRows = this.GenerateProductHtmlTableRows(orderDetails.Products);

            this.ViewData["creation-date"] = orderDetails.CreationDate.ToShortDateString();
            this.ViewData["products-rows"] = productsRows;
            this.ViewData["order-id"] = orderDetails.Id.ToString();

            return this.FileViewResponse(@"Shopping\OrderDetails");
        }
        
        public async Task<IHttpResponse> UserOrders(IHttpRequest request)
        {
            var userId = (int)request.Session[SessionStore.CurrentUserKey];

            var orders = await this.orderService.GetByUserId(userId);

            var tableRows = this.GenerateOrderHtmlTableRows(orders);

            this.ViewData["orders-rows"] = tableRows;

            return this.FileViewResponse(@"Shopping\UserOrders");
        }
        
        public async Task<IHttpResponse> FinishOrder(IHttpRequest request)
        {
            var shoppingCart = request
                .Session
                .Get<ShoppingCartSessionModel>(SessionStore.CurrentShoppingCartSessionKey);

            if (!shoppingCart.ProductsIds.Any())
            {
                this.ViewData[ShowSuccessKey] = "none";
                this.ShowError("You do not have any cakes in your shopping cart!");
            }
            else
            {
                var totalSum = await this.productService
                    .GetProductsPricesSum(shoppingCart.ProductsIds);

                var order = new OrderCreateServiceModel
                {
                    CreationDate = DateTime.UtcNow,
                    TotalSum = totalSum,
                    UserId = (int)request.Session[SessionStore.CurrentUserKey],
                    ProductsIds = shoppingCart.ProductsIds
                };

                var newOrderId = await this.orderService.Create(order);
                
                this.ViewData[ShowSuccessKey] = "block";
                shoppingCart.ProductsIds.Clear();
            }

            return this.FileViewResponse(@"Shopping\FinishOrder");
        }

        private string GenerateOrderHtmlTableRows(IEnumerable<OrderListServiceModel> orders)
        {
            var builder = new StringBuilder();

            foreach (var order in orders.OrderByDescending(o => o.CreationDate))
            {
                var orderId = order.Id;
                var orderCreationDate = order.CreationDate.ToShortDateString();
                var orderTotalSum = order.Products.Sum(p => p.Price).ToString("f2");

                builder
                    .AppendLine($"<tr><td><a href='orderDetails?id={orderId}'>{orderId}</a></td><td>{orderCreationDate}</td><td>{orderTotalSum}</td></tr>");
            }

            var result = builder.ToString().TrimEnd();

            return result;
        }

        private string GenerateProductHtmlTableRows(ICollection<ProductListServiceModel> products)
        {
            var builder = new StringBuilder();

            foreach (var product in products.OrderBy(o => o.Price))
            {
                var productId = product.Id;
                var productName = product.Name;
                var productPrice = product.Price.ToString("f2");

                builder
                    .AppendLine($"<tr><td><a href='product/details?id={productId}'>{productName}</a></td><td>{productPrice}</td></tr>");
            }

            var result = builder.ToString().TrimEnd();

            return result;
        }
    }
}
