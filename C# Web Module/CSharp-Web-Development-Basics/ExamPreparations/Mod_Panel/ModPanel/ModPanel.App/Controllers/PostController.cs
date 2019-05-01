namespace ModPanel.App.Controllers
{
    using ModPanel.App.Infrastructure.Attributes;
    using ModPanel.App.Models.Post;
    using ModPanel.Common.Notifications;
    using Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;

    public class PostController : BaseController
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet]
        [AuthorizedOnly]
        public IActionResult Create()
        {
            this.Model["controller"] = this.Identity.IsAdmin ? "admin" : "post";

            return View();
        }

        [HttpPost]
        [AuthorizedOnly]
        public IActionResult Create(PostCreateViewModel model)
        {
            var modelStateError = this.ValidateModelState(model);
            if (modelStateError != null)
            {
                this.ShowNotification(modelStateError);
                return View();
            }

            var success = this.postService.Create(model.Title, model.Content, this.Identity.Id);
            if (!success)
            {
                this.ShowNotification(NotificationMessages.InvalidOperation);
                return View();
            }

            return RedirectToHome();
        }
    }
}
