namespace MvcFramework.Interfaces
{
    public interface IViewable : IActionResult
    {
        IRenderable View { get; }
    }
}
