using FDMC.Data;
using FDMC.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace FDMC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly FdmcDbContext db;

        public HomeController(FdmcDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var model = this.db
                .Cats
                .OrderByDescending(c => c.DateAdded)
                .Select(c => new CatListingViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Breed = c.Breed.Name,
                    ImageUrl = c.ImageUrl
                })
                .ToArray();

            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
