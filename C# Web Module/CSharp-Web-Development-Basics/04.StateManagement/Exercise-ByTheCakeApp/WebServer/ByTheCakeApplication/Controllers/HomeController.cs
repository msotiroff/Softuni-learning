namespace HTTPServer.ByTheCakeApplication.Controllers
{
    using Server.Http.Contracts;

    public class HomeController : BaseController
    {
        public IHttpResponse Index()
            => this.FileViewResponse(@"Home\Index");

        public IHttpResponse About()
            => this.FileViewResponse(@"Home\About");
    }
}
