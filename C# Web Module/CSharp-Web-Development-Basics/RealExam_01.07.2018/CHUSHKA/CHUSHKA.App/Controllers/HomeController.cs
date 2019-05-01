namespace CHUSHKA.App.Controllers
{
    using CHUSHKA.Services.Contracts;
    using CHUSHKA.Services.Models.Product;
    using SoftUni.WebServer.Mvc.Attributes.HttpMethods;
    using SoftUni.WebServer.Mvc.Interfaces;
    using System.Collections.Generic;
    using System.Text;

    public class HomeController : BaseController
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (!this.User.IsAuthenticated)
            {
                this.ViewData["products"] = string.Empty;
                return View();
            }

            var allProducts = this.productService.All();

            this.ViewData["products"] = this.BuildProductsList(allProducts);
            this.ViewData["regards"] = this.User.IsInRole("Admin") 
                ? "Enjoy your work today!" 
                : "Feel free to view and order any of our products.";

            return View();
        }

        private string BuildProductsList(IEnumerable<ProductListServiceModel> allProducts)
        {
            var builder = new StringBuilder();

            foreach (var product in allProducts)
            {
                var shortDescription = product.Description.Length > 50 ? product.Description.Substring(0, 50) + "..." : product.Description;

                var item = $@"<a href='/product/details?id={product.Id}' class='col-md-2 m-2'>
                                <div class='product p-1 chushka-bg-color rounded-top rounded-bottom'>
                                    <h5 class='text-center mt-3'>{product.Name}</h5>
                                    <hr class='hr-1 bg-white' />
                                    <p class='text-white text-center'>
                                        {shortDescription}
                                    </p>
                                    <hr class='hr-1 bg-white' />
                                    <h6 class='text-center text-white mb-3'>${product.Price:f2}</h6>
                                </div>
                            </a>";

                builder.AppendLine(item);
            }

            return builder.ToString();
        }
    }
}
