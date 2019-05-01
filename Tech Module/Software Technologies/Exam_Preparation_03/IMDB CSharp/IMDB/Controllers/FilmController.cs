using System.Linq;
using System.Net;
using System.Web.Mvc;
using IMDB.Models;

namespace IMDB.Controllers
{
    [ValidateInput(false)]
    public class FilmController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var db = new IMDBDbContext())
            {
                var allFilms = db.Films.ToList();

                return View(allFilms);
            }
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film filmToCreate)
        {
            if (filmToCreate == null)
            {
                return RedirectToAction("Index");
            }

            if (string.IsNullOrWhiteSpace(filmToCreate.Name) ||
                string.IsNullOrWhiteSpace(filmToCreate.Genre) ||
                string.IsNullOrWhiteSpace(filmToCreate.Director))
            {
                return RedirectToAction("Index");
            }

            using (var db = new IMDBDbContext())
            {
                db.Films.Add(filmToCreate);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            using (var db = new IMDBDbContext())
            {
                var filmToEdit = db.Films.Find(id);

                if (filmToEdit == null)
                {
                    return RedirectToAction("Index");
                }

                return View(filmToEdit);
            }
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, Film filmModel)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            using (var db = new IMDBDbContext())
            {
                var filmToEdit = db.Films.Find(id);

                if (filmToEdit == null)
                {
                    return RedirectToAction("Index");
                }

                if (string.IsNullOrWhiteSpace(filmToEdit.Name) ||
                string.IsNullOrWhiteSpace(filmToEdit.Genre) ||
                string.IsNullOrWhiteSpace(filmToEdit.Director))
                {
                    return RedirectToAction("Index");
                }

                db.Films.Find(id).Name = filmModel.Name;
                db.Films.Find(id).Genre = filmModel.Genre;
                db.Films.Find(id).Director = filmModel.Director;
                db.Films.Find(id).Year = filmModel.Year;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            using (var db = new IMDBDbContext())
            {
                var filmToDelete = db.Films.Find(id);

                if (filmToDelete == null)
                {
                    return RedirectToAction("Index");
                }

                return View(filmToDelete);
            }
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            using (var db = new IMDBDbContext())
            {
                var filmToDelete = db.Films.Find(id);

                if (filmToDelete == null)
                {
                    return RedirectToAction("Index");
                }

                db.Films.Remove(filmToDelete);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            
        }
    }
}