namespace Library.Web.Controllers
{
    using Library.Data;
    using Library.Web.Infrastructure.Extensions.Enums;
    using Library.Web.Models.Director;
    using Library.Web.Models.Movie;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    public class DirectorController : BaseController
    {
        public DirectorController(LibraryDbContext dbContext) 
            : base(dbContext) { }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await this.DbContext
                 .Directors
                 .Where(d => d.Id == id)
                 .Select(a => new DirectorDetailsViewModel
                 {
                     Name = a.Name,
                     Movies = a.Movies
                     .Select(b => new MovieConciseViewModel
                     {
                         Id = b.MovieId,
                         Title = b.Movie.Title,
                         Status = b.Movie.IsBorrowed ? "Borrowed" : "At home"
                     })
                     .ToArray()
                 })
                 .FirstOrDefaultAsync();

            if (model == null)
            {
                return RedirectToHome();
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                this.ShowNotification("Director name can not be empty!");
                return View();
            }

            var directorExist = await this.DbContext.Directors.AnyAsync(a => a.Name == name);
            if (directorExist)
            {
                this.ShowNotification("Director already exist!");
                return RedirectToAction("Create", "Movie");
            }

            await this.DbContext.Directors.AddAsync(new Library.Models.Director { Name = name });
            await this.DbContext.SaveChangesAsync();

            this.ShowNotification($"Director {name} created successfully!", NotificationType.Success);

            return RedirectToAction("Create", "Movie");
        }
    }
}