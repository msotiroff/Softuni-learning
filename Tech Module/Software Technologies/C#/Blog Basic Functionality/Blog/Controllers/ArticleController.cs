using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        private bool IsUserAuthorizedToEdit (Article currentArticle)
        {
            bool isAdmin = this.User.IsInRole("Admin");
            bool isAuthor = currentArticle.IsAuthor(this.User.Identity.Name);

            return isAdmin || isAuthor;
        }

        // GET: Article/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new BlogDbContext())
            {
                var articleToEdit = database
                    .Articles
                    .Where(a => a.Id == id)
                    .Include(a => a.Author)
                    .First();

                if (!IsUserAuthorizedToEdit(articleToEdit))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }

                if (articleToEdit == null)
                {
                    return HttpNotFound();
                }


                var model = new ArticleViewModel()
                {
                    Id = articleToEdit.Id,
                    Title = articleToEdit.Title,
                    Content = articleToEdit.Content
                };
                
                return View(model);
            }
        }


        // POST: Article/Edit
        [HttpPost]
        public ActionResult Edit(ArticleViewModel currentModel)
        {
            if (ModelState.IsValid)
            {
                using (var database = new BlogDbContext())
                {
                    var articleToEdit = database
                        .Articles
                        .FirstOrDefault(a => a.Id == currentModel.Id);

                    articleToEdit.Title = currentModel.Title;
                    articleToEdit.Content = currentModel.Content;

                    database.Entry(articleToEdit).State = EntityState.Modified;
                    database.SaveChanges();
                }

            }

            return RedirectToAction("Index");
        }

        // GET: Article/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new BlogDbContext())
            {
                var articleToDelete = database
                    .Articles
                    .Where(a => a.Id == id)
                    .Include(a => a.Author)
                    .First();

                if (! IsUserAuthorizedToEdit(articleToDelete))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }

                if (articleToDelete == null)
                {
                    return HttpNotFound();
                }

                return View(articleToDelete);
            }
        }

        // POST: Article/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new BlogDbContext())
            {
                var articleToDelete = database
                    .Articles
                    .Where(a => a.Id == id)
                    .Include(a => a.Author)
                    .First();

                if (articleToDelete == null)
                {
                    return HttpNotFound();
                }

                database.Articles.Remove(articleToDelete);
                database.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        // GET: Article/Create
        [Authorize]
        public ActionResult Create ()
        {
            return View();
        }

        // POST: Article/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(Article currentArticle)
        {
            if (ModelState.IsValid)
            {
                using (var database = new BlogDbContext())
                {
                    currentArticle.AuthorId = database
                        .Users
                        .Where(u => u.UserName == this.User.Identity.Name)
                        .First()
                        .Id;

                    database.Articles.Add(currentArticle);
                    database.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        // GET: Article/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new BlogDbContext())
            {
                var currentArticle = database
                    .Articles
                    .Where(a => a.Id == id)
                    .Include(a => a.Author)
                    .First();

                if (currentArticle == null)
                {
                    return HttpNotFound();
                }

                return View(currentArticle);
            }
        }

        // GET: Article
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        // GET: Article/List
        public ActionResult List()
        {
            using (var database = new BlogDbContext())
            {
                var allArticles = database.Articles.Include(a => a.Author).ToList();

                return View(allArticles);
            }

            
        }
    }
}