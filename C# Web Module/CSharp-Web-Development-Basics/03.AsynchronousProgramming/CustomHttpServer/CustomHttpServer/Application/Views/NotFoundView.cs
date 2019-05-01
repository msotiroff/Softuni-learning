using CustomHttpServer.Server.Http.Contracts;

namespace CustomHttpServer.Application.Views
{
    public class NotFoundView : IView
    {
        public string View()
        {
            return 
                "<body>" +
                "   <h1>Not Found!</h1>" +
                "</body>";
        }
    }
}
