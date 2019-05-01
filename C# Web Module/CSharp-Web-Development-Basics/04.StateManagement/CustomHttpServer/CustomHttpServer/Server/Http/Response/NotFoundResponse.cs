namespace CustomHttpServer.Server.Http.Response
{
    using Application.Views;
    using Enums;

    public class NotFoundResponse : ViewResponse
    {
        public NotFoundResponse()
            : base(HttpStatusCode.NotFound, new NotFoundView())
        {
        }
    }
}
