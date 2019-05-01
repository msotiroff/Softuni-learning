namespace ModPanel.App.Controllers
{
    using ModPanel.Services.Contracts;
    using ModPanel.Services.Models.Log;
    using ModPanel.Services.Models.Post;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class HomeController : BaseController
    {
        protected IPostService postService;
        protected ILogger logger;

        public HomeController(IPostService postService, ILogger logger)
        {
            this.postService = postService;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            this.Model["renderedHomeView"] = this.User.IsAuthenticated
                ? this.Identity.IsAdmin
                    ? this.BuildAdminHtml()
                    : this.BuildUserHtml()
                : File.ReadAllText(@"..\..\..\Views\Home\Rendered\Guest.html");
            
                return View();
        }

        protected IEnumerable<PostServiceModel> GetPostsFromDb() => this.postService.All();
        
        protected string GetAllLogsViewTemplate()
        {
            var builder = new StringBuilder();

            var allLogs = this.GetLogsFromDb();

            var logTemplate = File.ReadAllText(@"..\..\..\Views\Log\Rendered\SingleLogIndexView.html");

            foreach (var log in allLogs)
            {
                builder
                    .AppendLine(string.Format(logTemplate, log.LogType.ToString().ToLower(), log.Activity));
            }

            return builder.ToString();
        }

        private string GetAllPostsViewTemplate()
        {
            var builder = new StringBuilder();

            var allPosts = this.GetPostsFromDb();
            this.Request.UrlParameters.TryGetValue("searchTerm", out string searchTerm);
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                allPosts = allPosts.Where(p => p.Title.ToLower().Contains(searchTerm.ToLower()));
            }

            var postTemplate = File.ReadAllText(@"..\..\..\Views\Post\Rendered\SinglePostIndexView.html");

            foreach (var post in allPosts)
            {
                builder
                    .AppendLine(string.Format(postTemplate,
                    post.Title,
                    post.Content.Length > 100 ? post.Content.Substring(0, 100) + "..." : post.Content,
                    post.CreatedOn.ToShortDateString(),
                    post.AuthorEmail));
            }

            return builder.ToString();
        }

        private string BuildAdminHtml()
        {
            var allPosts = this.GetAllPostsViewTemplate();
            var allLogs = this.GetAllLogsViewTemplate();

            var adminTemplate = File.ReadAllText(@"..\..\..\Views\Home\Rendered\Admin.html");
            var viewModel = string.Format(adminTemplate, allPosts, allLogs);

            return viewModel;
        }

        private string BuildUserHtml()
        {
            var allPosts = this.GetAllPostsViewTemplate();

            var userTemplate = File.ReadAllText(@"..\..\..\Views\Home\Rendered\User.html");
            var viewModel = string.Format(userTemplate, allPosts);

            return viewModel;
        }
        
        private IEnumerable<LogServiceModel> GetLogsFromDb() => this.logger.All();
    }
}
