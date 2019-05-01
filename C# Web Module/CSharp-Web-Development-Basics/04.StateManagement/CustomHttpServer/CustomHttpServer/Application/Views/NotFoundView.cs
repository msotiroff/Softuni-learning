using CustomHttpServer.Server.Http.Contracts;

namespace CustomHttpServer.Application.Views
{
    public class NotFoundView : IView
    {
        public string View()
        {
            return 
                "<body>" +
                "   <h1>You are trying to access a non-existing route!</h1>" +
                "</body>";
        }
    }
}
