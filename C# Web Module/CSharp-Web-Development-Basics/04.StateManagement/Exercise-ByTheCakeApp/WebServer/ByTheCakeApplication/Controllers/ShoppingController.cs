namespace HTTPServer.ByTheCakeApplication.Controllers
{
    using Server.Http;
    using Server.Http.Contracts;
    using Server.Http.Response;
    using Services;
    using Services.Contracts;
    using System.Linq;
    using ViewModels;

    public class ShoppingController : BaseController
    {
        private const string ProductNameKey = "name";
        private const string ProductPriceKey= "price";
        private const string ShowSuccessKey = "showSuccess";
        private const string CartItemsKey = "cartItems";
        private const string TotalCostKey = "totalCost";

        private IProductService productService;

        public ShoppingController()
        {
            this.productService = new ProductService();
        }

        public IHttpResponse Add(IHttpRequest request)
        {
            var urlParams = request.UrlParameters;

            if (!urlParams.ContainsKey(ProductNameKey) || !urlParams.ContainsKey(ProductPriceKey))
            {
                return new NotFoundResponse();
            }

            var productName = urlParams[ProductNameKey];
            var productPrice = decimal.Parse(urlParams[ProductPriceKey]);

            var product = new ProductViewModel(productName, productPrice);

            var productExist = this.productService.Get(productName) != null;

            if (!productExist)
            {
                return new NotFoundResponse();
            }

            var shoppingCart = request
                .Session
                .Get<ShoppingCartViewModel>(SessionStore.CurrentShoppingCartSessionKey);

            shoppingCart.Products.Add(product);

            return new RedirectResponse("/search");
        }
        
        public IHttpResponse CartDetails(IHttpRequest request)
        {
            var shoppingCart = request
                .Session
                .Get<ShoppingCartViewModel>(SessionStore.CurrentShoppingCartSessionKey);

            if (!shoppingCart.Products.Any())
            {
                this.ViewData[ShowSuccessKey] = "none";
                this.ViewData[CartItemsKey] = "You have no cakes in your cart!";
                this.ViewData[TotalCostKey] = "0.00";
            }
            else
            {
                var productsInCart = shoppingCart.Products;

                var items = productsInCart
                    .Select(pr => $"<div>{pr.Name} - ${pr.Price:f2}</div><br />");

                var totalPrice = productsInCart
                    .Sum(pr => pr.Price);

                this.ViewData[CartItemsKey] = string.Join(string.Empty, items);
                this.ViewData[TotalCostKey] = $"{totalPrice:f2}";
            }

            return this.FileViewResponse(@"Shopping\Cart");
        }

        public IHttpResponse FinishOrder(IHttpRequest request)
        {
            var shoppingCart = request
                .Session
                .Get<ShoppingCartViewModel>(SessionStore.CurrentShoppingCartSessionKey);

            if (!shoppingCart.Products.Any())
            {
                this.ViewData[ShowSuccessKey] = "none";
                this.ShowError("You do not have any cakes in your shopping cart!");
            }
            else
            {
                this.ViewData[ShowSuccessKey] = "block";
                shoppingCart.Products.Clear();
            }

            return this.FileViewResponse(@"Shopping\FinishOrder");
        }
    }
}
