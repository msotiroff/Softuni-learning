﻿namespace Notes.App.Controllers
{
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;

    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Index() => View();
    }
}
