namespace SoftUniGameStore.App.Controllers
{
    using HTTPServer.Http;
    using HTTPServer.Http.Contracts;
    using Infrastructure.Attributes;
    using Models.Shopping;
    using Services.Contracts;
    using Services.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static HTTPServer.Enums.HttpRequestMethod;

    public class ShoppingController : BaseController
    {
        private const string CartView = @"Shopping\Cart";
        private const string CartDetailsRedirect = @"\Shopping\CartDetails";

        private readonly IGameService gameService;
        private readonly IShoppingService shoppingService;

        public ShoppingController(IHttpRequest request, IGameService gameService, IShoppingService shoppingService) 
            : base(request)
        {
            this.gameService = gameService;
            this.shoppingService = shoppingService;
        }

        [AllowAnonymous]
        [RequestMethod(Get)]
        public IHttpResponse AddtoCart()
        {
            var isIdAvailable = this.Request.UrlParameters.ContainsKey("id");

            if (!isIdAvailable)
            {
                this.ShowError("Something went wrong!");
                
                return this.RedirectResponse(CartDetailsRedirect);
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
                this.ShowError("Game not available for ordering!");
                
                return this.RedirectResponse(CartDetailsRedirect);
            }

            if (this.Request.Session.Contains(SessionStore.CurrentUserKey))
            {
                var userId = (int)this.Request.Session[SessionStore.CurrentUserKey];
                var alreadyBought = false;

                Task.Run(async () =>
                {
                    alreadyBought = await this.shoppingService.IsUserBoughtGame(userId, gameId);
                })
                .Wait();

                if (alreadyBought)
                {
                    this.ShowError("You had already bought this game!");

                    return this.RedirectResponse(CartDetailsRedirect);
                }
            }

            this.AddToSessionCart(gameId);
            
            return this.RedirectResponse(CartDetailsRedirect);
        }

        [AllowAnonymous]
        [RequestMethod(Get)]
        public IHttpResponse CartDetails()
        {
            var gamesInCart =this.GetAllGamesInSessionCart();

            var gameCartList = this.BuildGameCartListAsHtml(gamesInCart);

            this.ViewData["game-cart-list"] = gameCartList;
            this.ViewData["TotalPrice"] = gamesInCart.Sum(g => g.Price).ToString("f2");

            return this.FileViewResponse(CartView);
        }

        [RequestMethod(Get)]
        public IHttpResponse RemoveFromCart()
        {
            var isIdAvailable = this.Request.UrlParameters.ContainsKey("id");

            if (!isIdAvailable)
            {
                this.ShowError("No available game to remove from cart!");

                this.GetAllGamesInSessionCart();
                
                return RedirectResponse("/");
            }

            this.RemoveFromShoppingCart();

            return this.RedirectResponse("/Shopping/CartDetails");
        }

        [AllowAnonymous]
        [RequestMethod(Get)]
        public IHttpResponse Order()
        {
            if (!this.Request.Session.Contains(SessionStore.CurrentUserKey))
            {
                return this.RedirectResponse("/Account/Login");
            }

            var gamesIds = this.GetAllGamesInSessionCart().Select(g => g.Id).ToList();
            var userId = (int)this.Request.Session[SessionStore.CurrentUserKey];

            if (gamesIds.Count == 0)
            {
                this.ShowError("You do not have any games in your shopping cart!");
                return this.FileViewResponse(CartView);
            }

            var success = false;

            Task.Run(async () =>
            {
                success = await this.shoppingService.Order(userId, gamesIds);
            })
            .Wait();

            if (!success)
            {
                this.ShowError("Order is not available right now!");

                return this.FileViewResponse(CartView);
            }

            this.ClearSessionCart();

            return this.RedirectResponse("/Shopping/Thanks");
        }

        [RequestMethod(Get)]
        public IHttpResponse Thanks()
            => this.FileViewResponse("Shopping/Thanks");

        private void ClearSessionCart()
        {
            var cart = (ShoppingCartSessionModel)this.Request.Session[SessionStore.CurrentShoppingCartSessionKey];

            cart.ProductsIds.Clear();
        }

        private string BuildGameCartListAsHtml(IEnumerable<GameCartServiceModel> gamesInCart)
        {
            var builder = new StringBuilder();

            foreach (var game in gamesInCart)
            {
                var shortDescription = game.Description.Length > 60
                    ? game.Description.Substring(0, 60)
                    : game.Description;


                var line = $@"<div class=""media"">
                                <a class=""btn btn-outline-danger btn-lg align-self-center mr-3"" href=""/Shopping/RemoveFromCart?id={game.Id}"">X</a>
                                <img class=""d-flex mr-4 align-self-center img-thumbnail"" height=""127"" src=""{game.Thumbnail}""
                                     width=""227"" alt=""Generic placeholder image"">
                                <div class=""media-body align-self-center"">
                                    <a href = ""/Game/Details?id={game.Id}"" >
                                        <h4 class=""mb-1 list-group-item-heading"">{game.Title}</h4>
                                    </a>
                                    <p>
                                        {shortDescription}
                                    </p>
                                </div>
                                <div class=""col-md-2 text-center align-self-center mr-auto"">
                                    <h2> {game.Price:f2}&euro; </h2>
                                </div>
                            </div>";

                builder.AppendLine(line);
            }

            return builder.ToString();
        }

        private void AddToSessionCart(int gameId)
        {
            var cart = (ShoppingCartSessionModel)this
                            .Request
                            .Session[SessionStore.CurrentShoppingCartSessionKey];

            cart.ProductsIds.Add(gameId);
        }

        private void RemoveFromShoppingCart()
        {
            var gameId = int.Parse(this.Request.UrlParameters["id"]);

            var cart = (ShoppingCartSessionModel)this.Request.Session[SessionStore.CurrentShoppingCartSessionKey];

            cart.ProductsIds.Remove(gameId);
        }

        private IEnumerable<GameCartServiceModel> GetAllGamesInSessionCart()
        {
            IEnumerable<GameCartServiceModel> gamesInCart = new List<GameCartServiceModel>();

            var cart = (ShoppingCartSessionModel)this.Request.Session[SessionStore.CurrentShoppingCartSessionKey];

            Task.Run(async () =>
            {
                gamesInCart = await this.gameService.GetAllByIds(cart.ProductsIds);
            })
            .Wait();

            return gamesInCart;
        }
    }
}
