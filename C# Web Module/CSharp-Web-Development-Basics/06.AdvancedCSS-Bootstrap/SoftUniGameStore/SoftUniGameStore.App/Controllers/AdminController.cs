namespace SoftUniGameStore.App.Controllers
{
    using HTTPServer.Http;
    using HTTPServer.Http.Contracts;
    using HTTPServer.Http.Response;
    using Infrastructure;
    using Infrastructure.Attributes;
    using Services.Contracts;
    using Services.Models;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using System.Threading.Tasks;
    using static HTTPServer.Enums.HttpRequestMethod;

    public class AdminController : BaseController
    {
        private const string CreateView = @"Admin\Create";
        private const string EditView = @"Admin\Edit";
        private const string DeleteView = @"Admin\Delete";
        private const string GameListView = @"Admin\GameList";
        private const string UserListView = @"Admin\UserList";

        private readonly IGameService gameService;
        private readonly IUserService userService;
        private bool isAdministrator;

        public AdminController(IHttpRequest request, IGameService gameService, IUserService userService)
            : base(request)
        {
            this.gameService = gameService;
            this.userService = userService;
            this.isAdministrator = (bool)request.Session[SessionStore.CurrentUserIsAdminKey];
        }
        
        [RequestMethod(Get)]
        public IHttpResponse UserList()
        {
            if (!this.isAdministrator)
            {
                return new RedirectResponse("/");
            }

            IEnumerable<UserDetailsServiceModel> allUsers = new List<UserDetailsServiceModel>();

            Task.Run(async () =>
            {
                allUsers = await this.userService.All();
            })
            .Wait();

            this.ViewData["user-list"] = this.BuildUserListAsHtmlText(allUsers);

            return this.FileViewResponse(UserListView);
        }
        
        [RequestMethod(Get)]
        public IHttpResponse GameList()
        {
            if (!this.isAdministrator)
            {
                return new RedirectResponse("/");
            }

            IEnumerable<GameServiceModel> allGames = new List<GameServiceModel>();

            Task.Run(async () =>
            {
                allGames = await this.gameService.All();
            })
            .Wait();

            this.ViewData["game-list"] = this.BuildGameListAsHtmlText(allGames);

            return this.FileViewResponse(GameListView);
        }
        
        [RequestMethod(Get)]
        public IHttpResponse Create()
        {
            if (!this.isAdministrator)
            {
                return new RedirectResponse("/");
            }

            return this.FileViewResponse(CreateView);
        }

        [RequestMethod(Post)]
        public IHttpResponse CreateConfirmed()
        {
            if (!this.isAdministrator)
            {
                return new RedirectResponse("/");
            }

            var formData = this.Request.FormData;

            var allDataAvailable = formData.ContainsKey("Title")
                && formData.ContainsKey("Description")
                && formData.ContainsKey("Thumbnail")
                && formData.ContainsKey("Size")
                && formData.ContainsKey("Date")
                && formData.ContainsKey("VideoUrl")
                && formData.ContainsKey("Price");

            if (!allDataAvailable)
            {
                this.ShowError("Missing required data!");

                return this.FileViewResponse(CreateView);
            }

            var isDateValid = DateTime.TryParse(formData["Date"], CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);

            if (!isDateValid)
            {
                this.ShowError("Invalid date format!");

                return this.FileViewResponse(CreateView);
            }

            var serviceModel = new GameCreateServiceModel
            {
                Title = formData["Title"],
                Description = formData["Description"],
                Price = decimal.Parse(formData["Price"]),
                Size = double.Parse(formData["Size"]),
                ImageThumbnail = formData["Thumbnail"],
                Trailer = formData["VideoUrl"],
                ReleaseDate = releaseDate
            };

            int newGameId = default(int);

            Task.Run(async () =>
            {
                newGameId = await this.gameService.Create(serviceModel);
            })
            .Wait();

            if (newGameId == default(int))
            {
                this.ShowError("An error occurred while creating your game!");

                return this.FileViewResponse(CreateView);
            }

            return this.RedirectResponse("/");
        }

        [RequestMethod(Get)]
        public IHttpResponse Edit()
        {
            if (!this.isAdministrator)
            {
                return new RedirectResponse("/");
            }

            var hasValidId = this.Request.UrlParameters.ContainsKey("id");

            if (!hasValidId)
            {
                return this.FileViewResponse("/");
            }

            var gameId = int.Parse(this.Request.UrlParameters["id"]);

            GameServiceModel gameToEdit = null;

            Task.Run(async () =>
            {
                gameToEdit = await this.gameService.GetById(gameId);
            })
            .Wait();

            this.SetAllViewDataForCurrentGame(gameToEdit);

            return this.FileViewResponse(EditView);
        }
        
        [RequestMethod(Post)]
        public IHttpResponse EditConfirmed()
        {
            if (!this.isAdministrator)
            {
                return new RedirectResponse("/");
            }

            var formData = this.Request.FormData;

            var allDataAvailable = formData.ContainsKey("Id")
                && formData.ContainsKey("Title")
                && formData.ContainsKey("Description")
                && formData.ContainsKey("Thumbnail")
                && formData.ContainsKey("Size")
                && formData.ContainsKey("ReleaseDate")
                && formData.ContainsKey("Trailer")
                && formData.ContainsKey("Price");

            if (!allDataAvailable)
            {
                this.ShowError("Missing required data!");

                return this.FileViewResponse(CreateView);
            }

            var isDateValid = DateTime.TryParse(formData["ReleaseDate"], CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);

            if (!isDateValid)
            {
                this.ShowError("Invalid date format!");

                return this.FileViewResponse(CreateView);
            }

            var serviceModel = new GameServiceModel
            {
                Id = int.Parse(formData["Id"]),
                Title = formData["Title"],
                Description = formData["Description"],
                Price = decimal.Parse(formData["Price"]),
                Size = double.Parse(formData["Size"]),
                Thumbnail = formData["Thumbnail"],
                Trailer = formData["Trailer"],
                ReleaseDate = releaseDate
            };

            var success = false;

            Task.Run(async () =>
            {
                success = await this.gameService.Update(serviceModel);
            })
            .Wait();

            if (!success)
            {
                this.ShowError("An error occurred while updating your game!");

                return this.FileViewResponse(EditView);
            }

            return this.RedirectResponse("GameList");
        }

        [RequestMethod(Get)]
        public IHttpResponse Delete()
        {
            if (!this.isAdministrator)
            {
                return new RedirectResponse("/");
            }

            var parameters = this.Request.UrlParameters;

            if (!parameters.ContainsKey("id"))
            {
                return this.RedirectResponse("/");
            }

            var gameId = int.Parse(parameters["id"]);

            GameServiceModel gameToDelete = null;

            Task.Run(async () =>
            {
                gameToDelete = await this.gameService.GetById(gameId);
            })
            .Wait();

            if (gameToDelete == null)
            {
                return this.RedirectResponse("GameList");
            }

            this.SetAllViewDataForCurrentGame(gameToDelete);

            return this.FileViewResponse(DeleteView);
        }

        [RequestMethod(Post)]
        public IHttpResponse DeleteConfirmed()
        {
            if (!this.isAdministrator)
            {
                return new RedirectResponse("/");
            }

            var gameId = int.Parse(this.Request.FormData["id"]);

            var success = false;

            Task.Run(async () =>
            {
                success = await this.gameService.Delete(gameId);
            })
            .Wait();

            if (!success)
            {
                this.ShowError("An error occurred while deleting this game!");

                return this.FileViewResponse("Delete");
            }

            return this.RedirectResponse("GameList");
        }

        [RequestMethod(Post)]
        public IHttpResponse AddToRole()
        {
            var data = this.Request.FormData;

            var isDataAvailable = data.ContainsKey("userId") && data.ContainsKey("roleName");

            if (!isDataAvailable)
            {
                return this.RedirectResponse("/");
            }

            var roleName = data["roleName"];
            var userId = int.Parse(data["userId"]);

            var success = false;

            Task.Run(async () =>
            {
                success = await this.userService.AddToRole(roleName, userId);
            })
            .Wait();

            if (!success)
            {
                this.ShowError("Unable to add this user to the specified role!");
            }

            IEnumerable<UserDetailsServiceModel> allUsers = new List<UserDetailsServiceModel>();

            Task.Run(async () =>
            {
                allUsers = await this.userService.All();
            })
            .Wait();

            this.ViewData["user-list"] = this.BuildUserListAsHtmlText(allUsers);

            return FileViewResponse(UserListView);
        }

        private string BuildGameListAsHtmlText(IEnumerable<GameServiceModel> allGames)
        {
            var builder = new StringBuilder();

            var counter = 1;
            
            foreach (var game in allGames)
            {
                var row = $@"<tr>
                                <th scope=""row"">{counter++}</th>
                                <td>{game.Title}</td>
                                <td> {game.Size} GB </td>
                                <td> {game.Size:f2} &euro;</td>
                                <td>
                                    <a href = ""/Admin/Edit?id={game.Id}"" class=""btn btn-warning btn-sm"">Edit</a>
                                    <a href=""/Admin/Delete?id={game.Id}"" class=""btn btn-danger btn-sm"">Delete</a>
                                </td>
                            </tr>";

                builder.AppendLine(row);
            }

            return builder.ToString();
        }

        private string BuildUserListAsHtmlText(IEnumerable<UserDetailsServiceModel> allUsers)
        {
            var builder = new StringBuilder();
            
            foreach (var user in allUsers)
            {
                var actionButton = !user.IsAdmin
                    ? this.BuildAdminButton(user)
                    : !user.IsModerator
                        ? this.BuildModButton(user)
                        : string.Empty;

                var row = $@"<tr>
                                <th scope=""row"">{user.Id}</th>
                                <td>{user.Email}</td>
                                <td> {user.FullName}</td>
                                <td>
                                    {actionButton}
                                </td>
                            </tr>";

                builder.AppendLine(row);
            }

            return builder.ToString();
        }

        private string BuildModButton(UserDetailsServiceModel user)
        {
            return $"<form method='post' action='/Admin/AddToRole'> <input name = 'roleName' value = '{AppConstants.ModeratorRole}' hidden = 'hidden' /><input name = 'userId' value = '{user.Id}' hidden = 'hidden' /><input type = 'submit' class='btn btn-success btn-sm' value='Add to role {AppConstants.ModeratorRole}' /></form>";
        }

        private string BuildAdminButton(UserDetailsServiceModel user)
        {
            return $"<form method='post' action='/Admin/AddToRole'> <input name = 'roleName' value = '{AppConstants.AdministratorRole}' hidden = 'hidden' /><input name = 'userId' value = '{user.Id}' hidden = 'hidden' /><input type = 'submit' class='btn btn-primary btn-sm' value='Add to role {AppConstants.AdministratorRole}' /></form>";
        }

        private void SetAllViewDataForCurrentGame(GameServiceModel game)
        {
            this.ViewData["Id"] = game.Id.ToString();
            this.ViewData["Title"] = game.Title;
            this.ViewData["Description"] = game.Description;
            this.ViewData["Price"] = game.Price.ToString();
            this.ViewData["Size"] = game.Size.ToString();
            this.ViewData["Thumbnail"] = game.Thumbnail;
            this.ViewData["ReleaseDate"] = game.ReleaseDate.Date.ToString("yyyy-MM-dd");
            this.ViewData["Trailer"] = game.Trailer;
        }
    }
}
