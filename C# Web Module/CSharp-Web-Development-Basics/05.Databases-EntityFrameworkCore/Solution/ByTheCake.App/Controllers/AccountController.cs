namespace ByTheCake.App.Controllers
{
    using HTTPServer.Http;
    using HTTPServer.Http.Contracts;
    using Services.Contracts;
    using Services.Implementations;
    using Services.Models;
    using System;
    using System.Threading.Tasks;
    using ViewModels;

    public class AccountController : BaseController
    {
        private const string RegisterView = @"Account\Register";
        private const string LoginView = @"Account\Login";
        private const string ProfileView = @"Account\Profile";
        private const string Username = "Username";
        private const string FullName = "FullName";
        private const string Password = "Password";
        private const string ConfirmPassword = "ConfirmPassword";

        private IUserService userService;

        public AccountController()
        {
            this.userService = new UserService();
        }

        public IHttpResponse Login()
        {
            this.ViewData[AuthenticatedKey] = "none";

            return this.FileViewResponse(LoginView);
        }
            
        public async Task<IHttpResponse> Login(IHttpRequest request)
        {
            var formData = request.FormData;

            if (!formData.ContainsKey(Username) || !formData.ContainsKey(Password))
            {
                this.ShowError("Missing required data!");

                return this.FileViewResponse(LoginView);
            }

            var model = new LoginViewModel(formData[Username], formData[Password]);

            if (!this.VerifyModelState(model))
            {
                this.ShowError("Invalid required data!");

                return this.FileViewResponse(LoginView);
            }
            
            var userId = await this.userService.TrySignIn(model.Username, model.Password);

            if (userId == default(int))
            {
                this.ShowError("Invalid login attempt!");

                return this.FileViewResponse(LoginView);
            }

            this.SetUserSession(request, userId);

            return RedirectResponse("/");
        }

        public async Task<IHttpResponse> Profile(IHttpSession session)
        {
            var userId = (int)session[SessionStore.CurrentUserKey];
            var user = await this.userService.GetById(userId);

            if (user == null)
            {
                return this.FileViewResponse(LoginView);
            }

            this.ViewData["fullname"] = user.FullName;
            this.ViewData["registrationDate"] = user.RegistrationDate.ToShortDateString();
            this.ViewData["ordersCount"] = user.OrdersCount.ToString();

            return this.FileViewResponse(ProfileView);
        }

        public IHttpResponse Logout(IHttpRequest request)
        {
            request.Session.Clear();

            return this.RedirectResponse("/");
        }

        public IHttpResponse Register()
        {
            this.ViewData[AuthenticatedKey] = "none";

            return this.FileViewResponse(RegisterView);
        }

        public async Task<IHttpResponse> Register(IHttpRequest request)
        {
            var formData = request.FormData;

            var isFormDataValid = formData.ContainsKey(Username)
                && formData.ContainsKey(FullName)
                && formData.ContainsKey(Password)
                && formData.ContainsKey(ConfirmPassword);

            if (!isFormDataValid)
            {
                this.ShowError("Missing required data!");

                return this.FileViewResponse(RegisterView);
            }

            var userName = formData[Username];
            var fullName = formData[FullName];
            var password = formData[Password];
            var confirmPassword = formData[ConfirmPassword];

            if (password != confirmPassword)
            {
                this.ShowError("Password confirmation does not match!");

                return this.FileViewResponse(RegisterView);
            }

            var serviceModel = new UserCreateServiceModel()
            {
                Username = userName,
                Name = fullName,
                Password = password,
                RegistrationDate = DateTime.UtcNow
            };

            var userExist = await this.userService.Exist(userName);

            if (userExist)
            {
                this.ShowError("This username is already taken!");

                return this.FileViewResponse(RegisterView);
            }
            
            var newUserId = await this.userService.Create(serviceModel);
            
            this.SetUserSession(request, newUserId);
            
            return this.RedirectResponse("/");
        }
        
        private void SetUserSession(IHttpRequest request, int userId)
        {
            request.Session.Add(SessionStore.CurrentUserKey, userId);
            request.Session.Add(SessionStore.CurrentShoppingCartSessionKey, new ShoppingCartSessionModel());
        }
    }
}
