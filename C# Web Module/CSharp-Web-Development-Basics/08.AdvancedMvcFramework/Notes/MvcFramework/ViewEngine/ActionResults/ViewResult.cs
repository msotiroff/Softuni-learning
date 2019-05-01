namespace MvcFramework.ViewEngine.ActionResults
{
    using MvcFramework.Interfaces;
    using WebServer.Enums;
    using WebServer.Http.Contracts;
    using WebServer.Http.Response;

    public class ViewResult : IViewable
    {
        public ViewResult(IRenderable view)
        {
            this.View = view;
        }

        public IRenderable View { get; }

        public IHttpResponse Invoke() => new ContentResponse(HttpStatusCode.Ok, this.View.Render());
    }
}
