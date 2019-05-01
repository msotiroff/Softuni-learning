namespace Judge.App.Controllers
{
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;

    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            //if (this.User.IsAuthenticated)
            //{
            //    this.ViewModel["username"] = this.User.Name;
            //}

            return View();
        }
    }
}
