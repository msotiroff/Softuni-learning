using System;
using System.Linq;
using System.Web.Mvc;
using TeisterMask.Models;

namespace TeisterMask.Controllers
{
        [ValidateInput(false)]
	public class TaskController : Controller
	{
	    [HttpGet]
            [Route("")]
	    public ActionResult Index()
	    {
            // TODO: Implement me...

            using (var db = new TeisterMaskDbContext())
            {
                var allTasks = db.Tasks.ToList();

                return View(allTasks);
            }
		}

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
		{
            // TODO: Implement me...

            return View();
		}

		[HttpPost]
		[Route("create")]
        [ValidateAntiForgeryToken]
		public ActionResult Create(Task taskToCreate)
		{
            // TODO: Implement me...

            if (taskToCreate == null)
            {
                return RedirectToAction("Index");
            }

            if (string.IsNullOrWhiteSpace(taskToCreate.Title) || string.IsNullOrEmpty(taskToCreate.Status))
            {
                return RedirectToAction("Index");
            }

            using (var db = new TeisterMaskDbContext())
            {
                db.Tasks.Add(taskToCreate);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

		[HttpGet]
		[Route("edit/{id}")]
        public ActionResult Edit(int id)
		{
            // TODO: Implement me...
            
            using (var db = new TeisterMaskDbContext()) 
            {
                var taskToEdit = db.Tasks.Find(id);

                if (taskToEdit == null)
                {
                    return RedirectToAction("Index");
                }

                return View(taskToEdit);
            }
        }

		[HttpPost]
		[Route("edit/{id}")]
        [ValidateAntiForgeryToken]
		public ActionResult EditConfirm(int id, Task taskModel)
		{
            // TODO: Implement me...
            using (var db = new TeisterMaskDbContext())
            {
                var taskToEdit = db.Tasks.Find(id);

                if (taskToEdit == null)
                {
                    return RedirectToAction("Index");
                }

                if (string.IsNullOrWhiteSpace(taskToEdit.Title) || string.IsNullOrEmpty(taskToEdit.Status))
                {
                    return RedirectToAction("Index");
                }

                db.Tasks.Find(id).Title = taskModel.Title;
                db.Tasks.Find(id).Status = taskModel.Status;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
	}
}