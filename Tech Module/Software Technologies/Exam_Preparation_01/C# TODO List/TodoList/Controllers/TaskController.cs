using System;
using System.Linq;
using System.Web.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
        [ValidateInput(false)]
	public class TaskController : Controller
	{
	    [HttpGet]
        [Route("")]
	    public ActionResult Index()
	    {
	        //TODO: Implement me...

            using (var db = new TodoListDbContext())
            {
                var allTasks = db.Tasks.ToList();

                return View(allTasks);
            }
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
		{
			//TODO: Implement me...
            
		    return View();
		}

		[HttpPost]
		[Route("create")]
        [ValidateAntiForgeryToken]
		public ActionResult Create(Task task)
		{
            //TODO: Implement me...

            if (task == null)
            {
                return RedirectToAction("Index");
            }

            if (string.IsNullOrWhiteSpace(task.Title) || string.IsNullOrWhiteSpace(task.Comments))
            {
                return RedirectToAction("Index");
            }
            
            using (var db = new TodoListDbContext())
            {
                db.Tasks.Add(task);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

		[HttpGet]
		[Route("delete/{id}")]
        public ActionResult Delete(int id)
		{
		    //TODO: Implement me...

            using (var db = new TodoListDbContext())
            {
                Task taskToDelete = db.Tasks.Find(id);

                if (taskToDelete == null)
                {
                    return RedirectToAction("index");
                }

                return View(taskToDelete);
            }
		    
        }

		[HttpPost]
		[Route("delete/{id}")]
        [ValidateAntiForgeryToken]
		public ActionResult DeleteConfirm(int id)
		{
		    //TODO: Implement me...

            using (var db = new TodoListDbContext())
            {
                Task taskToDelete = db.Tasks.Find(id);

                if (taskToDelete == null)
                {
                    return RedirectToAction("Index");
                }

                db.Tasks.Remove(taskToDelete);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

		    
        }
	}
}