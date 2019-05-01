namespace Library.Web.Controllers
{
    using Infrastructure.Collections;
    using Library.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Models.Author;
    using Models.Director;
    using Models.Interfaces;
    using Models.Movie;
    using Models.Search;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using static WebConstants;

    public class HomeController : BaseController
    {
        public HomeController(LibraryDbContext dbContext)
            : base(dbContext) { }

        [HttpGet]
        public IActionResult Index() => RedirectToAction("index", "book");

        [HttpGet]
        public async Task<IActionResult> Search(string searchTerm = "", int pageIndex = 1)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return RedirectToHome();
            }

            pageIndex = Math.Max(1, pageIndex);
            List<ILibraryEntry> books = await this.GetMatchedBooks(searchTerm);
            List<ILibraryEntry> movies = await this.GetMatchedMovies(searchTerm);
            
            var entries = books.Concat(movies).ToList();

            var totalPages = (int)Math.Ceiling(entries.Count() / (double)IndexEntryCountOnPage);
            pageIndex = Math.Min(pageIndex, Math.Max(1, totalPages));

            var entriesToShow = entries
                .Skip((pageIndex - 1) * IndexEntryCountOnPage)
                .Take(IndexEntryCountOnPage)
                .Select(e => e = this.MarkSearchedResults(e, searchTerm))
                .ToList();

            var searchEntries = new PaginatedList<ILibraryEntry>(entriesToShow, pageIndex, totalPages);

            var model = new SearchResultViewModel
            {
                SearchTerm = searchTerm,
                Entries = searchEntries,
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private ILibraryEntry MarkSearchedResults(ILibraryEntry entry, string searchTerm)
        {
            var replaceFormat = "<span class='marked'>{0}</span>";

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var titleMatch = Regex.Match(entry.Title, searchTerm, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                if (titleMatch.Success)
                {
                    var markedTitle = Regex.Replace(entry.Title, titleMatch.Value, string.Format(replaceFormat, titleMatch));
                    entry.Title = markedTitle;
                }

                foreach (var originator in entry.Originators)
                {
                    var originatorName = originator.Name;
                    var nameMatch = Regex.Match(originatorName, searchTerm, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                    if (nameMatch.Success)
                    {
                        var markedName = Regex.Replace(originatorName, nameMatch.Value, string.Format(replaceFormat, nameMatch));
                        originator.Name = markedName;
                    }
                }
            }

            return entry;
        }

        private async Task<List<ILibraryEntry>> GetMatchedMovies(string searchTerm) => await this.DbContext
                            .Movies
                            .Where(m => m.Title.ToLower().Contains(searchTerm.ToLower())
                                || m.Directors.Any(a => a.Director.Name.ToLower().Contains(searchTerm.ToLower())))
                            .Select(b => new MovieIndexViewModel
                            {
                                Id = b.Id,
                                Title = b.Title,
                                Status = b.IsBorrowed ? "Borrowed" : "At home",
                                Originators = b.Directors
                                .Select(a => new DirectorViewModel
                                {
                                    Id = a.DirectorId,
                                    Name = a.Director.Name
                                })
                                .Cast<IOriginator>()
                                .ToList()
                            })
                            .Cast<ILibraryEntry>()
                            .ToListAsync();

        private async Task<List<ILibraryEntry>> GetMatchedBooks(string searchTerm) => await this.DbContext
                            .Books
                            .Where(b => b.Title.ToLower().Contains(searchTerm.ToLower())
                                || b.Authors.Any(a => a.Author.Name.ToLower().Contains(searchTerm.ToLower())))
                            .Select(b => new BookIndexViewModel
                            {
                                Id = b.Id,
                                Title = b.Title,
                                Status = b.IsBorrowed ? "Borrowed" : "At home",
                                Originators = b.Authors
                                .Select(a => new AuthorViewModel
                                {
                                    Id = a.AuthorId,
                                    Name = a.Author.Name
                                })
                                .Cast<IOriginator>()
                                .ToList()
                            })
                            .Cast<ILibraryEntry>()
                            .ToListAsync();
    }
}
