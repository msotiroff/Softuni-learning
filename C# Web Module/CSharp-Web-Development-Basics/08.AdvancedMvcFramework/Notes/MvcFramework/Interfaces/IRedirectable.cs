namespace MvcFramework.Interfaces
{
    public interface IRedirectable : IActionResult
    {
        string RedirectUrl { get; }
    }
}
