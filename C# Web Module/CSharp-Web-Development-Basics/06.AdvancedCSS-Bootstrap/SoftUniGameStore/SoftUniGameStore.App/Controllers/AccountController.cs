namespace SoftUniGameStore.App.Controllers
{
    using HTTPServer.Http;
    using HTTPServer.Http.Contracts;
    using HTTPServer.Http.Response;
    using Infrastructure;
    using Infrastructure.Attributes;
    using Models.Account;
    using Services.Contracts;
    using Services.Models;
    using System.Threading.Tasks;
    using static HTTPServer.Enums.HttpRequestMethod;

    public class AccountController : BaseController
    {
        private const string RegisterView = @"Account\Register";
        private const string LoginView = @"Account\Login";

        private IUserService userService;
        private IHashService hashService;

        public AccountController(IHttpRequest request, IUserService userService, IHashService hashService)
            : base(request)
        {
            this.userService = userService;
            this.hashService = hashService;

            this.ViewData[AuthenticatedKey] = "none";
            this.ViewData[AnonymousKey] = "block";
        }

        [AllowAnonymous]
        [RequestMethod(Get)]
        public IHttpResponse Register()
            => this.FileViewResponse(RegisterView);

        [AllowAnonymous]
        [RequestMethod(Post)]
        public IHttpResponse RegisterConfirmed()
        {
            var formData = this.Request.FormData;

            var allDataAvailable = formData.ContainsKey("Email")
                && formData.ContainsKey("FullName")
                && formData.ContainsKey("Password")
                && formData.ContainsKey("ConfirmPassword");

            if (!allDataAvailable)
            {
                this.ShowError("Missing required data!");

                return this.FileViewResponse(RegisterView);
            }

            string email = formData["Email"];
            string fullName = formData["FullName"];
            string password = formData["Password"];
            string confirmPassword = formData["ConfirmPassword"];

            if (password != confirmPassword)
            {
                this.ShowError("Password confirmation does not match!");

                return this.FileViewResponse(RegisterView);
            }

            var viewModel = new RegisterViewModel
            {
                Email = email,
                FullName = fullName,
                Password = password,
                ConfirmPassword = confirmPassword,
            };

            if (!this.VerifyModelState(viewModel))
            {
                return this.FileViewResponse(RegisterView);
            }

            var serviceModel = new UserRegisterServiceModel
            {
                Email = viewModel.Email,
                FullName = viewModel.FullName,
                PasswordHash = this.hashService.ComputeHash(viewModel.Password)
            };

            if (!this.VerifyModelState(serviceModel))
            {
                return this.FileViewResponse(RegisterView);
            }

            int newUserId = default(int);

            Task.Run(async () =>
            {
                newUserId = await this.userService.Create(serviceModel);
            })
            .Wait();

            if (newUserId > 0)
            {
                this.SetUserSession(newUserId);

                return this.RedirectResponse("/");
            }
            else
            {
                this.ShowError("An error occurred while processing your registration!");

                return this.FileViewResponse(RegisterView);
            }
        }

        [AllowAnonymous]
        [RequestMethod(Get)]
        public IHttpResponse Login()
            => this.FileViewResponse(LoginView);

        [AllowAnonymous]
        [RequestMethod(Post)]
        public IHttpResponse LoginConfirmed()
        {
            const string InvalidLoginErrorMsg = "Invalid login attempt!";

            var formData = this.Request.FormData;

            var allDataAvailable = formData.ContainsKey("Email")
                && formData.ContainsKey("Password");

            if (!allDataAvailable)
            {
                this.ShowError("Missing required data!");

                return this.FileViewResponse(LoginView);
            }

            string email = formData["Email"];
            string password = formData["Password"];

            var viewModel = new LoginViewModel
            {
                Email = email,
                Password = password
            };

            var serviceModel = new UserLoginServiceModel
            {
                Email = viewModel.Email,
                PasswordHash = this.hashService.ComputeHash(viewModel.Password)
            };

            if (!this.VerifyModelState(serviceModel))
            {
                this.ShowError(InvalidLoginErrorMsg);

                return this.FileViewResponse(LoginView);
            }

            var loggedUserId = default(int);

            Task.Run(async () =>
            {
                loggedUserId = await this.userService.TryLogin(serviceModel);
            })
            .Wait();

            if (loggedUserId > 0)
            {
                this.SetUserSession(loggedUserId);

                return new RedirectResponse("/");
            }
            else
            {
                this.ShowError(InvalidLoginErrorMsg);

                return this.FileViewResponse(LoginView);
            }
        }

        [RequestMethod(Get)]
        public IHttpResponse Logout()
        {
            this.ResetSession();

            return new RedirectResponse("/");
        }

        private void ResetSession()
            => this.Request.Session.Clear();

        private void SetUserSession(int userId)
        {
            this.Request.Session.Add(SessionStore.CurrentUserKey, userId);

            this.SetUserAdminSession(userId);
        }

        private void SetUserAdminSession(int userId)
        {
            bool isAdmin = false;

            Task.Run(async () =>
            {
                isAdmin = await this.userService.UserIsInRole(AppConstants.AdministratorRole, userId);
            })
            .Wait();

            if (isAdmin)
            {
                this.Request.Session.Add(SessionStore.CurrentUserIsAdminKey, true);
            }
            else
            {
                this.Request.Session.Add(SessionStore.CurrentUserIsAdminKey, false);
            }
        }
    }
}
