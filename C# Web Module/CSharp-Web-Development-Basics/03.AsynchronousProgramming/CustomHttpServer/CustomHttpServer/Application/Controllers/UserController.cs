namespace CustomHttpServer.Application.Controllers
{
    using CustomHttpServer.Application.Views;
    using CustomHttpServer.Server.Http.Contracts;
    using CustomHttpServer.Server.Http.Enums;
    using CustomHttpServer.Server.Http.Response;
    using CustomHttpServer.Server.Models;

    public class UserController
    {
        public IHttpResponse RegisterGet()
            => new ViewResponse(HttpStatusCode.OK, new RegisterView());

        public IHttpResponse RegisterPost(string name)
            => new RedirectResponse($"/user/{name}");

        public IHttpResponse Details(string name)
        {
            UserModel userModel = new UserModel();
            userModel.Add("name", name);

            return new ViewResponse(HttpStatusCode.OK, new DetailsView(userModel));
        }
    }
}
