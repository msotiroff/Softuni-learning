namespace Library.Web.Controllers
{
    using Library.Data;
    using Library.Models;
    using Library.Web.Infrastructure.Collections;
    using Library.Web.Infrastructure.Extensions.Enums;
    using Library.Web.Infrastructure.Filters;
    using Library.Web.Models.Director;
    using Library.Web.Models.Interfaces;
    using Library.Web.Models.Movie;
    using Library.Web.Models.Status;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using static WebConstants;

    public class MovieController : BaseController
    {
        public MovieController(LibraryDbContext dbContext) 
            : base(dbContext) { }

        [HttpGet]
        public IActionResult Index(int pageIndex = 1)
        {
            pageIndex = Math.Max(1, pageIndex);

            var movies = this.DbContext
                .Movies
                .Select(m => new MovieIndexViewModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    Status = m.IsBorrowed ? "Borrowed" : "At home",
                    Originators = m.Directors
                        .Select(a => new DirectorViewModel
                        {
                            Id = a.DirectorId,
                            Name = a.Director.Name,
                        })
                        .Cast<IOriginator>()
                        .ToList()
                })
                .OrderBy(m => m.Title);

            var totalPages = Math.Max(1, (int)Math.Ceiling(movies.Count() / (double)MoviesCountOnPage));
            pageIndex = Math.Min(pageIndex, totalPages);

            var moviesToShow = movies
                .Skip((pageIndex - 1) * MoviesCountOnPage)
                .Take(MoviesCountOnPage)
                .ToList();

            var model = new PaginatedList<MovieIndexViewModel>(moviesToShow, pageIndex, totalPages);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await this.DbContext
                .Movies
                .Where(m => m.Id == id)
                .Select(m => new MovieDetailsViewModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    YouTubeTrailerId = m.YouTubeTrailerId,
                    IsBorrowed = m.IsBorrowed,
                    Status = m.IsBorrowed ? "Borrowed" : "At home",
                    Directors = m.Directors
                        .Select(a => new DirectorViewModel
                        {
                            Id = a.DirectorId,
                            Name = a.Director.Name
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
        [AuthorizedOnly]
        public async Task<IActionResult> Create()
        {
            var allDirectors = await GetAllDirectors();

            var model = new MovieCreateViewModel
            {
                AllDirectors = allDirectors
            };

            return View(model);
        }

        [HttpPost]
        [AuthorizedOnly]
        public async Task<IActionResult> Create(MovieCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.AllDirectors = await this.GetAllDirectors();
                this.ShowModelStateError();
                return View(model);
            }

            if (!model.SelectedDirectors.Any())
            {
                model.AllDirectors = await this.GetAllDirectors();
                this.ShowNotification("You have to choose minimum one director!");
                return View(model);
            }

            var directors = await this.GetDirectors(model.SelectedDirectors);
            var youTubeId = this.GetYouTubeLinkId(model.YouTubeLink);
            if (youTubeId == null)
            {
                this.ShowNotification("Invalid you tube link!");
                return View(model);
            }

            var movie = new Movie
            {
                Title = model.Title,
                Description = model.Description,
                YouTubeTrailerId = youTubeId,
                Directors = directors.Select(d => new MovieDirector { DirectorId = d.Id }).ToList()
            };

            await this.DbContext.Movies.AddAsync(movie);
            await this.DbContext.SaveChangesAsync();

            this.ShowNotification($"Movie {model.Title} created successfully", NotificationType.Success);

            return RedirectToAction("Details", "Movie", new { id = movie.Id });
        }

        [HttpGet]
        [AuthorizedOnly]
        public async Task<IActionResult> Borrow(int id)
        {
            var allRegisteredBorrowers = await this.GetAllRegisteredBorrowers();

            var model = await this.DbContext
                .Movies
                .Where(m => m.Id == id)
                .Select(m => new MovieBorrowingViewModel
                {
                    Id = m.Id,
                    MovieTitle = m.Title,
                    DateBorrowed = DateTime.Today,
                    ExpirationDate = DateTime.Today.AddMonths(1),
                    Borrowers = allRegisteredBorrowers
                })
                .FirstOrDefaultAsync();

            return View(model);
        }

        [HttpPost]
        [AuthorizedOnly]
        public async Task<IActionResult> Borrow(MovieBorrowingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Borrowers = await this.GetAllRegisteredBorrowers();
                this.ShowModelStateError();
                return View(model);
            }

            if (model.ExpirationDate != null)
            {
                if (model.ExpirationDate <= model.DateBorrowed)
                {
                    model.Borrowers = await this.GetAllRegisteredBorrowers();
                    this.ShowNotification("Expiration date should be after date of borrowing!");
                    return View(model);
                }
            }

            var movie = await this.DbContext.Movies.FirstOrDefaultAsync(b => b.Id == model.Id);
            movie.IsBorrowed = true;

            var status = new MovieStatus
            {
                MovieId = model.Id,
                BorrowerId = int.Parse(model.SelectedBorrowerId),
                DateBorrowed = model.DateBorrowed,
                ExpirationDate = model.ExpirationDate
            };

            await this.DbContext.AddAsync(status);
            await this.DbContext.SaveChangesAsync();

            this.ShowNotification($"Movie {movie.Title} borrowed successfully", NotificationType.Success);

            return RedirectToHome();
        }

        [HttpPost]
        [AuthorizedOnly]
        public async Task<IActionResult> Return(int movieId)
        {
            if (movieId == default(int))
            {
                this.ShowNotification("Missing Movie identifier!");
                return View();
            }

            var movie = await this.DbContext
                .Movies
                .Where(b => b.Id == movieId)
                .Include(b => b.Statuses)
                .FirstOrDefaultAsync(b => b.Id == movieId);

            movie.IsBorrowed = false;

            var status = movie.Statuses.Last();
            status.DateReturned = DateTime.Today;

            this.DbContext.Update(movie);
            this.DbContext.Update(status);

            await this.DbContext.SaveChangesAsync();

            this.ShowNotification($"Movie {movie.Title} returned successfully", NotificationType.Success);

            return RedirectToHome();
        }

        [HttpGet]
        [AuthorizedOnly]
        public async Task<IActionResult> History(int id)
        {
            var statuses = await this.DbContext
                .MovieStatuses
                .Where(s => s.MovieId == id)
                .OrderByDescending(s => s.DateBorrowed)
                .ThenBy(s => s.ExpirationDate)
                .Select(s => new MovieStatusViewModel
                {
                    MovieTitle = s.Movie.Title,
                    BorrowerName = s.Borrower.Name,
                    BorrowerAddress = s.Borrower.Address,
                    DateBorrowed = s.DateBorrowed.ToShortDateString(),
                    ExpirationDate = s.ExpirationDate != null ? s.ExpirationDate.Value.ToShortDateString() : "No expiration date",
                    DateReturned = s.DateReturned != null ? s.DateReturned.Value.ToShortDateString() : "Not returned yet"
                })
                .ToListAsync();

            return View(statuses);
        }

        private async Task<IEnumerable<Director>> GetDirectors(IEnumerable<string> directorNames)
        {
            var directors = new HashSet<Director>();

            foreach (var directorName in directorNames)
            {
                var director = await this.DbContext.Directors.FirstOrDefaultAsync(a => a.Name == directorName);

                directors.Add(director);
            }

            return directors;
        }

        private string GetYouTubeLinkId(string youTubeLink)
        {
            try
            {
                var youTubeUri = new Uri(youTubeLink);

                if (youTubeLink.Contains("youtu.be"))
                {
                    return youTubeUri.AbsolutePath.Substring(1);
                }

                var id = HttpUtility.ParseQueryString(youTubeUri.Query)["v"];

                return id.Length == 11 ? id : null;
            }
            catch (UriFormatException)
            {
                return null;
            }
        }

        private async Task<List<SelectListItem>> GetAllDirectors()
        {
            return await this.DbContext
                            .Directors
                            .OrderBy(d => d.Name)
                            .Select(d => new SelectListItem(d.Name, d.Name))
                            .ToListAsync();
        }

        private async Task<List<SelectListItem>> GetAllRegisteredBorrowers()
        {
            return await this
                            .DbContext
                            .Borrowers
                            .Select(b => new SelectListItem { Text = b.Name, Value = b.Id.ToString() })
                            .ToListAsync();
        }
    }
}