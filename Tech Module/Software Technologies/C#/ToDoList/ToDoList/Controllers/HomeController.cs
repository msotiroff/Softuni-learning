using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var dataBase = new TaskDbContext())
            {
                var tasks = dataBase.Tasks.ToList();

                return View(tasks);
            }
        }
    }
}