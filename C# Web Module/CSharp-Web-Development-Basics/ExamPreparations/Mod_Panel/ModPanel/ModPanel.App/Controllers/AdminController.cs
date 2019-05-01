namespace ModPanel.App.Controllers
{
    using ModPanel.App.Infrastructure.Attributes;
    using ModPanel.App.Models.Post;
    using ModPanel.Common.Notifications;
    using ModPanel.Models.Common;
    using ModPanel.Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class AdminController : HomeController
    {
        private IUserService userService;

        public AdminController(IUserService userService,IPostService postService, ILogger logger)
            : base(postService, logger)
        {
            this.userService = userService;
        }

        [HttpGet]
        [AuthorizedOnly]
        public IActionResult Logs()
        {
            if (!this.Identity.IsAdmin)
            {
                return RedirectToHome();
            }

            this.logger.Create(this.Identity.Id, $"{this.Identity.Email} opened Log Menu", LogType.Info);

            this.Model["all-logs"] = this.GetAllLogsViewTemplate();
            return View();
        }

        [HttpGet]
        [AuthorizedOnly]
        public IActionResult Users()
        {
            if (!this.Identity.IsAdmin)
            {
                return RedirectToHome();
            }

            this.logger.Create(this.Identity.Id, $"{this.Identity.Email} opened Users Menu", LogType.Info);

            this.Model["all-users"] = this.GetAllUsersViewTemplate();

            return View();
        }

        [HttpGet]
        [AuthorizedOnly]
        public IActionResult Posts()
        {
            if (!this.Identity.IsAdmin)
            {
                return RedirectToHome();
            }

            this.logger.Create(this.Identity.Id, $"{this.Identity.Email} opened Posts Menu", LogType.Info);
            this.Model["all-posts"] = this.GetAllPostsViewTemplate();

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

            this.logger.Create(this.Identity.Id, $"{this.Identity.Email} created the post \"{model.Title}\"", LogType.Success);

            return RedirectToHome();
        }

        [HttpGet]
        [AuthorizedOnly]
        public IActionResult EditPost(int id)
        {
            if (!this.Identity.IsAdmin)
            {
                return RedirectToHome();
            }

            var post = this.postService.GetById(id);

            this.Model["post-id"] = post.Id.ToString();
            this.Model["post-title"] = post.Title;
            this.Model["post-content"] = post.Content;
            return View();
        }

        [HttpPost]
        [AuthorizedOnly]
        public IActionResult EditPost(PostUpdateViewModel model)
        {
            if (!this.Identity.IsAdmin)
            {
                return RedirectToHome();
            }

            var modelStateError = this.ValidateModelState(model);
            if (modelStateError != null)
            {
                this.ShowNotification(modelStateError);
                return View();
            }

            var success = this.postService.Update(model.Id, model.Title, model.Content);
            if (!success)
            {
                this.ShowNotification(NotificationMessages.InvalidOperation);
                return View();
            }

            this.logger.Create(this.Identity.Id, $"{this.Identity.Email} edited the post \"{model.Title}\"", LogType.Warning);

            this.ShowNotification("Post \"{model.Title}\" updated successfully!", NotificationType.Success);
            return this.Posts();
        }

        [HttpGet]
        [AuthorizedOnly]
        public IActionResult DeletePost(int id)
        {
            if (!this.Identity.IsAdmin)
            {
                return RedirectToHome();
            }

            var post = this.postService.GetById(id);

            this.Model["post-id"] = post.Id.ToString();
            this.Model["post-title"] = post.Title;
            this.Model["post-content"] = post.Content;
            return View();
        }

        [HttpPost]
        [AuthorizedOnly]
        public IActionResult DeletePost(PostDeleteViewModel model)
        {
            if (!this.Identity.IsAdmin)
            {
                return RedirectToHome();
            }
            
            bool success = this.postService.Delete(model.Id);
            if (!success)
            {
                this.ShowNotification(NotificationMessages.InvalidOperation);
                return View();
            }

            this.logger.Create(this.Identity.Id, $"{this.Identity.Email} deleted the post \"{model.Title}\"", LogType.Danger);

            return RedirectToAction("/admin/posts");
        }

        [HttpGet]
        [AuthorizedOnly]
        public IActionResult Approve(int id)
        {
            if (!this.Identity.IsAdmin)
            {
                return RedirectToHome();
            }

            var approvedUser = this.userService.Approve(id);
            if (approvedUser == null)
            {
                this.ShowNotification("No such a user exist or the user is already approved!", NotificationType.Info);
                return this.Users();
            }

            this.logger.Create(this.Identity.Id, $"{this.Identity.Email} approved the registration of {approvedUser}", LogType.Success);

            this.ShowNotification("Approval successful", NotificationType.Success);
            return this.Users();
        }

        private string GetAllUsersViewTemplate()
        {
            var builder = new StringBuilder();

            var allUsers = this.userService.All().ToArray();

            var userTemplate = File.ReadAllText(@"..\..\..\Views\Account\Rendered\SingleUserAdminView.html");

            for (int i = 1; i <= allUsers.Length; i++)
            {
                var user = allUsers[i - 1];
                var forApprovingDisplay = user.IsApproved ? "none" : "inline";

                builder
                    .AppendLine(string.Format(userTemplate,
                    i,
                    user.Email,
                    user.PositionName,
                    user.PostsCount,
                    user.Id,
                    forApprovingDisplay));
            }

            return builder.ToString();
        }

        private string GetAllPostsViewTemplate()
        {
            var builder = new StringBuilder();

            var allPosts = this.GetPostsFromDb().ToArray();

            var postTemplate = File.ReadAllText(@"..\..\..\Views\Post\Rendered\SinglePostAdminView.html");

            for (int i = 1; i <= allPosts.Length; i++)
            {
                var post = allPosts[i - 1];

                builder
                    .AppendLine(string.Format(postTemplate,
                    i,
                    post.Title,
                    post.Id));
            }

            return builder.ToString();
        }
    }
}
