namespace CustomHttpServer.Application.Views
{
    using Server.Http.Contracts;

    public class HomeViewIndex : IView
    {
        public string View()
        {
            return 
                "<body>" +
                "   <h1>Welcome</h1>" +
                "</body>";
        }
    }
}
