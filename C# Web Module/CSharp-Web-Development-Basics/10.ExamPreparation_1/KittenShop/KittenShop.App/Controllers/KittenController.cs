namespace KittenShop.App.Controllers
{
    using KittenShop.App.Infrastructure.Extensions;
    using KittenShop.App.Models.Kitten;
    using KittenShop.Common.Notifications;
    using KittenShop.Services.Contracts;
    using KittenShop.Services.Implementations;
    using KittenShop.Services.Models.Kitten;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Attributes.Security;
    using SimpleMvc.Framework.Interfaces;
    using System;
    using System.Linq;

    public class KittenController : BaseController
    {
        private IKittenService kittenService;

        public KittenController()
        {
            this.kittenService = new KittenService();
        }

        [HttpGet]
        [PreAuthorize]
        public IActionResult Add()
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToLogin();
            }

            var breeds = DatabaseExtensions.DefaultBreedsList;

            this.Model["breeds"] = string.Join(Environment.NewLine,
                breeds.Select(br => $"<input type='radio' name='Breed' value='{br}' /> {br} <br />"));

            return View();
        }

        [HttpPost]
        [PreAuthorize]
        public IActionResult Add(KittenCreateViewModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToLogin();
            }

            var modelStateError = this.ValidateModelState(model);
            if (modelStateError != null)
            {
                this.ShowNotification(modelStateError);
                return this.Add();
            }

            var success = this.kittenService.Add(model.Name, model.Breed, model.Age, this.Identity.Id);
            if (!success)
            {
                this.ShowNotification(NotificationMessages.InvalidOperation);
                return this.Add();
            }

            this.ShowNotification("Kitten added successfully!", NotificationType.success);
            return this.All();
        }

        [HttpGet]
        [PreAuthorize]
        public IActionResult All()
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToLogin();
            }

            var allKitens = this.kittenService.All();

            this.Model["all-kittens"] = string.Join(Environment.NewLine,
                allKitens.Select(k => this.BuildKttenListItem(k)));

            return View();
        }

        private string BuildKttenListItem(KittenListServiceModel kitten)
        {
            var listItem = $@"<div class=""card rounded thumbnail col-md-4"">
                                <img src=""https://www.catster.com/wp-content/uploads/2017/11/A-Siamese-cat.jpg"" style=""height: 150px;"" class=""card-image-top img-fluid img-thumbnail"">
                                <div class="" card-body"">
                                    <h4 class="" card-title"">{kitten.Name}</h4>
                                    <p class="" card-text"">Age - {kitten.Age}</p>
                                    <p class="" card-text"">{kitten.BreedName}</p>
                                </div>
                            </div>";

            return listItem;
        }
    }
}
