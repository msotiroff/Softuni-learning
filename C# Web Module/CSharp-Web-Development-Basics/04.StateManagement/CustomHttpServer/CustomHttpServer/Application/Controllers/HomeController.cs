namespace CustomHttpServer.Application.Controllers
{
    using Server.Http.Contracts;
    using Server.Http.Enums;
    using Server.Http.Response;
    using Views;

    public class HomeController
    {
        public IHttpResponse Index()
            => new ViewResponse(HttpStatusCode.OK, new HomeViewIndex());
    }
}
