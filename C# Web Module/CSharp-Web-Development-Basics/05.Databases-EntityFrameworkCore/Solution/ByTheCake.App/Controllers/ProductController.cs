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
    using System.Threading.Tasks;
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

        public async Task<IHttpResponse> Add(IDictionary<string, string> formData)
        {
            if (!formData.ContainsKey("name") 
                || !formData.ContainsKey("price")
                || !formData.ContainsKey("image-url"))
            {
                this.ShowError("Missing required data!");

                return this.FileViewResponse(AddView);
            }

            var name = formData["name"];
            var price = decimal.Parse(formData["price"]);
            var imageUrl = formData["image-url"];

            var model = new ProductCreateServiceModel
            {
                Name = name,
                Price = price,
                ImageUrl = imageUrl
            };

            if (!this.VerifyModelState(model))
            {
                this.ShowError("Product information is not valid");

                return this.FileViewResponse(AddView);
            }

            var newProductId = await this.productService.Create(model);

            this.ViewData["name"] = model.Name;
            this.ViewData["price"] = model.Price.ToString("f2");
            this.ViewData["image-url"] = model.ImageUrl;
            this.ViewData[ShowResultKey] = "block";

            return this.FileViewResponse(AddView);
        }

        public async Task<IHttpResponse> Details(IDictionary<string, string> queryParameters)
        {
            if (!queryParameters.ContainsKey("id"))
            {
                return new NotFoundResponse();
            }

            var id = int.Parse(queryParameters["id"]);

            var product = await this.productService.GetById(id);

            if (product == null)
            {
                this.ShowError("No such a product exist!");
                this.FileViewResponse(@"Product\Search");
            }

            this.ViewData["name"] = product.Name;
            this.ViewData["price"] = product.Price.ToString("f2");
            this.ViewData["image-url"] = product.ImageUrl;

            return this.FileViewResponse(@"Product\Details");
        }

        public IHttpResponse Search(IHttpRequest request)
        {
            var urlParams = request.UrlParameters;
            var shoppingCart = request
                .Session
                .Get<ShoppingCartSessionModel>(SessionStore.CurrentShoppingCartSessionKey);

            if (!urlParams.ContainsKey("keyWord"))
            {
                urlParams["keyWord"] = string.Empty;
            }

            var keyWord = urlParams["keyWord"];

            var cakes = this.productService
                .GetAll()
                .Result
                .Where(p => p.Name.ToLower()
                    .Contains(keyWord.ToLower()))
                .Select(p => this.GetForm(p.Id, p.Name, p.Price));

            var allCakes = string.Join(Environment.NewLine, cakes);
            this.ViewData["all-cakes"] = allCakes;
            this.ViewData["showCart"] = "none";

            var shoppingCartItemsCount = shoppingCart.ProductsIds.Count();
            if (shoppingCartItemsCount > 0)
            {
                this.ViewData["showCart"] = "block";
                this.ViewData["productsCount"] = shoppingCartItemsCount.ToString();
            }

            return this.FileViewResponse(@"Product\Search");
        }

        private string GetForm(int id, string name, decimal price)
            => $"<div><a href='product/details?id={id}'>{name}</a> ${price:f2} " +
            $"<a class='button' href='/shopping/add?id={id}'>Order</a></div>";
    }
}
