namespace MvcFramework.Interfaces
{
    using WebServer.Http.Contracts;

    public interface IActionResult
    {
        IHttpResponse Invoke();
    }
}
