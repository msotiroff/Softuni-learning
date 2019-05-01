using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class TaskController : Controller
    {
        [HttpPost]
        public ActionResult Create(Task currentTask)
        {
            if (currentTask == null)
            {
                return RedirectToAction("Index", "Home");
            }

            using (var dataBase = new TaskDbContext())
            {
                dataBase.Tasks.Add(currentTask);
                dataBase.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            using (var dataBase = new TaskDbContext())
            {
                var currentTask = dataBase.Tasks.Find(id);

                if (currentTask == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                dataBase.Tasks.Remove(currentTask);
                dataBase.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}