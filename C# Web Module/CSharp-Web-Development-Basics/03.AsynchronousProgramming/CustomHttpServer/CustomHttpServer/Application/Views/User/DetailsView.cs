namespace CustomHttpServer.Application.Views
{
    using Server.Http.Contracts;
    using Server.Models;

    public class DetailsView : IView
    {
        private readonly UserModel userModel;

        public DetailsView(UserModel userModel)
        {
            this.userModel = userModel;
        }

        public string View()
        {
            return
                "<body>" +
                    $"<h1>Hello, {this.userModel["name"]}!</h1>" +
                "</body>";
        }
    }
}
