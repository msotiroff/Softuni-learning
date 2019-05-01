namespace HTTPServer.ByTheCakeApplication.Controllers
{
    using System;
    using Server.Http;
    using Server.Http.Contracts;
    using ViewModels;

    public class AccountController : BaseController
    {
        private const string LoginView = @"Account\Login";
        private const string Username = "Username";
        private const string Password = "Password";
        
        public IHttpResponse Login()
        {
            this.ViewData[AuthenticatedKey] = "none";

            return this.FileViewResponse(LoginView);
        }
            

        public IHttpResponse Login(IHttpRequest request)
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

            this.LoginUser(request, model.Username);

            return RedirectResponse("/");
        }

        private void LoginUser(IHttpRequest request, string username)
        {
            request.Session.Add(SessionStore.CurrentUserKey, username);
            request.Session.Add(SessionStore.CurrentShoppingCartSessionKey, new ShoppingCartViewModel());
        }

        public IHttpResponse Logout(IHttpRequest request)
        {
            request.Session.Clear();

            return this.RedirectResponse("/");
        }
    }
}
