namespace WizMail.App.Controllers
{
    using Infrastructure.Attributes;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;

    public class HomeController : BaseController
    {
        [HttpGet]
        [AuthorizedOnly]
        public IActionResult Index() => this.RedirectToAction("/mail/box");
    }
}
