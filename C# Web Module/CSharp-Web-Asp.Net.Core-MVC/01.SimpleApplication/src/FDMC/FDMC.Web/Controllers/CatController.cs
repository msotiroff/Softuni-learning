namespace FDMC.Web.Controllers
{
    using FDMC.Data;
    using FDMC.Models;
    using FDMC.Web.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    public class CatController : Controller
    {
        private readonly FdmcDbContext db;

        public CatController(FdmcDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CatCreateViewModel
            {
                Breeds = this.db
                    .Breeds
                    .OrderBy(b => b.Name)
                    .Select(b => 
                        new SelectListItem(b.Name, b.Id.ToString()))
                        .ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CatCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            var cat = new Cat
            {
                Name = model.Name,
                Age = model.Age,
                ImageUrl = model.ImageUrl,
                BreedId = int.Parse(model.BreedId),
                DateAdded = DateTime.UtcNow
            };

            this.db.Add(cat);
            this.db.SaveChanges();

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var cat = this.db.Cats
                .Include(c => c.Breed)
                .FirstOrDefault(c => c.Id == id);

            if (cat == null)
            {
                return NotFound(id);
            }

            var model = new CatDetailsViewModel
            {
                Id = cat.Id,
                Breed = cat.Breed.Name,
                Age = cat.Age,
                Name = cat.Name,
                ImageUrl = cat.ImageUrl
            };

            return View(model);
        }
    }
}