namespace Notes.App.Controllers
{
    using MvcFramework.Attributes.Methods;
    using MvcFramework.Controllers;
    using MvcFramework.Interfaces;

    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index() => View();
    }
}
