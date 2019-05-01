namespace SoftUniGameStore.App.Controllers
{
    using HTTPServer.Http;
    using HTTPServer.Http.Contracts;
    using Infrastructure.Attributes;
    using Services.Contracts;
    using Services.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static HTTPServer.Enums.HttpRequestMethod;

    public class HomeController : BaseController
    {
        private IGameService gameService;

        public HomeController(IHttpRequest request, IGameService gameService)
            : base(request)
        {
            this.gameService = gameService;
        }

        [AllowAnonymous]
        [RequestMethod(Get)]
        public IHttpResponse Index()
        {
            IEnumerable<GameServiceModel> allGames = new List<GameServiceModel>();

            Task.Run(async () =>
            {
                allGames = await this.gameService.All();
            })
            .Wait();

            var urlParams = this.Request.UrlParameters;

            if (urlParams.ContainsKey("filter") && urlParams["filter"] == "Owned")
            {
                var userId = (int)this.Request.Session[SessionStore.CurrentUserKey];

                Task.Run(async () =>
                {
                    allGames = await this.gameService.GetAllByUser(userId);
                })
                .Wait();
            }
            
            this.ViewData["game-list"] = this.BuildGameListAsHtmlText(allGames);

            return this.FileViewResponse("Home\\Index");
        }

        private string BuildGameListAsHtmlText(IEnumerable<GameServiceModel> allGames)
        {
            var adminDisplay = this.ViewData["adminDisplay"] == "none"
                ? "none"
                : "inline-block";

            var builder = new StringBuilder();

            var counter = 1;

            foreach (var game in allGames)
            {
                var shortDescription = game.Description.Length > 300
                    ? game.Description.Substring(0, 300) + "..."
                    : game.Description;

                if (counter % 3 == 1)
                {
                    builder.AppendLine(@"<div class=""card-group"">");
                }

                builder.AppendLine(
                    $@"<div class=""card rounded thumbnail"">
                            <img style=""width: 400px; height: 400px;"" class=""card-image-top img-fluid img-thumbnail"" onerror=""this.src='https://i.ytimg.com/vi/{game.Trailer}/maxresdefault.jpg';"" src=""{game.Thumbnail}"">
                            <div class=""card-body"">
                                <h4 class=""card-title"">{game.Title}</h4>
                                <p class=""card-text""><strong>Price</strong> - {game.Price:F2}&euro;</p>
                                <p class=""card-text""><strong>Size</strong> - {game.Size:F2} GB</p>
                                <p class=""card-text"">{shortDescription}</p>
                            </div>
                            <div class=""card-footer"">
                                <a class=""card-button btn btn-warning"" style=""display:{adminDisplay}"" href=""/Admin/Edit?id={game.Id}"">Edit</a>
                                <a class=""card-button btn btn-danger"" style=""display:{adminDisplay}"" href=""/Admin/Delete?id={game.Id}"">Delete</a>
                                <a class=""card-button btn btn-outline-primary"" href=""/Game/Details?id={game.Id}"">Info</a>
                                <a class=""card-button btn btn-primary"" href=""/Shopping/AddtoCart?id={game.Id}"">Buy</a>
                            </div>
                       </div>
                    ");

                if (counter % 3 == 0)
                {
                    builder.AppendLine("</div>");
                }

                counter++;
            }

            return builder.ToString();
        }
    }
}
