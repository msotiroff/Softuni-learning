namespace CHUSHKA.App.Controllers
{
    using CHUSHKA.App.Models.Product;
    using CHUSHKA.Common.Notifications;
    using CHUSHKA.Services.Contracts;
    using CHUSHKA.Services.Models.Product;
    using SoftUni.WebServer.Mvc.Attributes.HttpMethods;
    using SoftUni.WebServer.Mvc.Attributes.Security;
    using SoftUni.WebServer.Mvc.Interfaces;
    using System.Text;

    public class ProductController : BaseController
    {
        private readonly IProductService productService;
        private readonly IOrderService orderService;

        public ProductController(IProductService productService, IOrderService orderService)
        {
            this.productService = productService;
            this.orderService = orderService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Details(int id)
        {
            var product = this.productService.GetById(id);
            if (product == null)
            {
                return RedirectToHome();
            }

            this.SetProductDetailsInViewData(product);

            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            if (!this.IsUserInRoleAdmin())
            {
                return RedirectToHome();
            }

            this.ViewData["product-types"] = this.GetAvailableProductTypes(string.Empty);

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(ProductCreateViewModel model)
        {
            if (!this.IsUserInRoleAdmin())
            {
                return RedirectToHome();
            }

            var modelStateError = this.ValidateModelState(model);
            if (modelStateError != null)
            {
                this.ShowNotification(modelStateError);
                return this.Create();
            }

            var newProductId = this.productService.Create(model.Name, model.Price, model.Description, model.ProductTypeId);
            if (newProductId == default(int))
            {
                this.ShowNotification(NotificationMessages.InvalidOperation);
                return this.Create();
            }

            this.ShowNotification(NotificationMessages.ProductCreatedSuccessfull, NotificationType.Success);
            return this.Details(newProductId);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            if (!this.IsUserInRoleAdmin())
            {
                return RedirectToHome();
            }

            var productToEdit = this.productService.GetById(id);
            if (productToEdit == null)
            {
                return RedirectToHome();
            }
            
            this.SetProductDetailsInViewData(productToEdit);

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(ProductEditViewModel model)
        {
            if (!this.IsUserInRoleAdmin())
            {
                return RedirectToHome();
            }

            var modelStateError = this.ValidateModelState(model);
            if (modelStateError != null)
            {
                this.ShowNotification(modelStateError);
                return this.Edit(model.Id);
            }

            var success = this.productService.Update(model.Id, model.Name, model.Price, model.Description, model.ProductTypeId);
            if (!success)
            {
                this.ShowNotification(NotificationMessages.InvalidOperation);
                return this.Edit(model.Id);
            }

            this.ShowNotification(NotificationMessages.ProductEditedSuccessfull, NotificationType.Success);
            return this.Details(model.Id);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Delete(int id)
        {
            if (!this.IsUserInRoleAdmin())
            {
                return RedirectToHome();
            }

            var productToDelete = this.productService.GetById(id);
            if (productToDelete == null)
            {
                return RedirectToHome();
            }

            this.SetProductDetailsInViewData(productToDelete);

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(ProductEditViewModel model)
        {
            if (!this.IsUserInRoleAdmin())
            {
                return RedirectToHome();
            }

            var success = this.productService.Delete(model.Id);
            if (!success)
            {
                this.ShowNotification(NotificationMessages.InvalidOperation);
                return this.Delete(model.Id);
            }

            this.ShowNotification(NotificationMessages.ProductDeletedSuccessfull, NotificationType.Success);
            return RedirectToHome();
        }


        [HttpGet]
        [Authorize]
        public IActionResult Order(int id)
        {
            var clientId = this.User.Id;
            var success = this.orderService.Create(id, clientId);

            if (!success)
            {
                this.ShowNotification(NotificationMessages.InvalidOperation);
                return this.Details(id);
            }

            this.ShowNotification(NotificationMessages.ProductOrderedSuccessfull, NotificationType.Success);
            return this.Details(id);
        }


        private void SetProductDetailsInViewData(ProductListServiceModel product)
        {
            this.ViewData["product-id"] = product.Id.ToString();
            this.ViewData["product-name"] = product.Name;
            this.ViewData["product-description"] = product.Description;
            this.ViewData["product-price"] = product.Price.ToString("f2");
            this.ViewData["product-type"] = product.ProductTypeName;
            this.ViewData["product-types"] = this.GetAvailableProductTypes(product.ProductTypeName);
        }

        private string GetAvailableProductTypes(string productTypeName)
        {
            var builder = new StringBuilder();

            var availableTypes = this.productService.GetAllProductTypes();

            foreach (var type in availableTypes)
            {
                var isChecked = type.Name == productTypeName ? "checked" : string.Empty;

                var radioButton = $@"<input type='radio' name='ProductTypeId' value='{type.Id}' {isChecked}> {type.Name}";
                builder.AppendLine(radioButton);
            }

            return builder.ToString();
        }
    }
}
