namespace SoftUniClone.Web.Controllers
{
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Models.Home;
    using Services.Contracts;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly ICourseService courseService;

        public HomeController(IUserService userService, ICourseService courseService)
        {
            this.userService = userService;
            this.courseService = courseService;
        }

        public IActionResult Index()
        {
            HomeIndexViewModel model = new HomeIndexViewModel();

            return View(model);
        }

        public async Task<IActionResult> Search(SearchViewModel model)
        {
            if (model.SearchInUsers)
            {
                model.Users = await this.userService.GetAllSearchListingAsync(model.SearchToken);
            }

            if (model.SearchInCourses)
            {
                model.Courses = await this.courseService.GetAllSearchListingAsync(model.SearchToken);
            }
            
            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}