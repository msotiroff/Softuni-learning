namespace SoftUniGameStore.App.Controllers
{
    using HTTPServer.Http.Contracts;
    using Infrastructure.Attributes;
    using Services.Contracts;
    using Services.Models;
    using System.Threading.Tasks;
    using static HTTPServer.Enums.HttpRequestMethod;

    public class GameController : BaseController
    {
        private const string DetailsView = @"Game\Details";

        private readonly IGameService gameService;

        public GameController(IHttpRequest request, IGameService gameService) 
            : base(request)
        {
            this.gameService = gameService;
        }

        [AllowAnonymous]
        [RequestMethod(Get)]
        public IHttpResponse Details()
        {
            var idIsAvailable = this.Request.UrlParameters.ContainsKey("id");

            if (!idIsAvailable)
            {
                return this.RedirectResponse("/");
            }

            var gameId = int.Parse(this.Request.UrlParameters["id"]);

            GameServiceModel game = null;

            Task.Run(async () =>
            {
                game = await this.gameService.GetById(gameId);
            })
            .Wait();

            if (game == null)
            {
                this.ShowError("An error occurred while getting this game!");

                return this.FileViewResponse("/");
            }

            this.SetAllViewDataForCurrentGame(game);

            return this.FileViewResponse(DetailsView);
        }

        private void SetAllViewDataForCurrentGame(GameServiceModel game)
        {
            this.ViewData["Id"] = game.Id.ToString();
            this.ViewData["Title"] = game.Title;
            this.ViewData["Description"] = game.Description.Length > 60 ? game.Description.Substring(0, 60) : game.Description;
            this.ViewData["Price"] = game.Price.ToString();
            this.ViewData["Size"] = game.Size.ToString();
            this.ViewData["Thumbnail"] = game.Thumbnail;
            this.ViewData["ReleaseDate"] = game.ReleaseDate.Date.ToString("yyyy-MM-dd");
            this.ViewData["Trailer"] = game.Trailer;
        }
    }
}
