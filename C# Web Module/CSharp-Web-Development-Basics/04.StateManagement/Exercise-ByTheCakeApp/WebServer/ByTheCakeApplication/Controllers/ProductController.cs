namespace HTTPServer.ByTheCakeApplication.Controllers
{
    using HTTPServer.Server.Http;
    using Server.Http.Contracts;
    using Services;
    using Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ViewModels;

    public class ProductController : BaseController
    {
        private const string AddView = @"Product\Add";

        private IProductService productService;

        public ProductController()
        {
            this.productService = new ProductService();
        }

        public IHttpResponse Add()
        {
            this.ViewData[ShowResultKey] = "none";

            return this.FileViewResponse(AddView);
        }

        public IHttpResponse Add(IDictionary<string, string> formData)
        {
            if (!formData.ContainsKey("name") || !formData.ContainsKey("price"))
            {
                this.ShowError("Missing required data!");

                return this.FileViewResponse(AddView);
            }

            var model = new ProductViewModel(formData["name"], decimal.Parse(formData["price"]));
            if (!this.VerifyModelState(model))
            {
                this.ShowError("Product information is not valid");

                return this.FileViewResponse(AddView);
            }

            this.productService.Create(model.Name, model.Price);

            this.ViewData["name"] = model.Name;
            this.ViewData["price"] = model.Price.ToString("f2");
            this.ViewData[ShowResultKey] = "block";

            return this.FileViewResponse(AddView);
        }

        public IHttpResponse Search(IHttpRequest request)
        {
            var urlParams = request.UrlParameters;
            var shoppingCart = request
                .Session
                .Get<ShoppingCartViewModel>(SessionStore.CurrentShoppingCartSessionKey);

            if (!urlParams.ContainsKey("keyWord"))
            {
                urlParams["keyWord"] = string.Empty;
            }

            var keyWord = urlParams["keyWord"];

            var cakes = this.productService
                .GetAll()
                .Where(p => p.Name.ToLower()
                    .Contains(keyWord.ToLower()))
                .Select(p => this.GetForm(p.Name, p.Price));

            var allCakes = string.Join(Environment.NewLine, cakes);
            this.ViewData["all-cakes"] = allCakes;
            this.ViewData["showCart"] = "none";

            var shoppingCartItemsCount = shoppingCart.Products.Count();
            if (shoppingCartItemsCount > 0)
            {
                this.ViewData["showCart"] = "block";
                this.ViewData["productsCount"] = shoppingCartItemsCount.ToString();
            }

            return this.FileViewResponse(@"Product\Search");
        }

        private string GetForm(string name, decimal price)
            => $"<div>{name} ${price:f2} <a class='button' href='/shopping/add?name={name}&price={price}'>Order</a></div>";
    }
}
