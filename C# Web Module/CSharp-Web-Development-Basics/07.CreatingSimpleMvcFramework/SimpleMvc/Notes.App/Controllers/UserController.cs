namespace Notes.App.Controllers
{
    using Models.User;
    using Notes.App.Models.Note;
    using Notes.Services;
    using Notes.Services.Models;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Interfaces;
    using SimpleMvc.Framework.Interfaces.Generic;
    using System.Collections;
    using System.Collections.Generic;

    public class UserController : Controller
    {
        private readonly UserService userService;
        private readonly NoteService noteService;

        public UserController()
        {
            this.userService = new UserService();
            this.noteService = new NoteService();
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            var success = this.userService.Register(model.Username, model.Password);

            if (!success)
            {
            }

            return this.View("All");
        }

        [HttpGet]
        public IActionResult<IEnumerable<UserViewModel>> All()
        {
            var allUsers = this.userService.All();

            return View(allUsers);
        }

        [HttpGet]
        public IActionResult<UserViewModel> Profile(int id)
        {
            var model = this.userService.GetById(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult<UserViewModel> Profile(NoteCreateModel model)
        {
            this.noteService.Add(model.Title, model.Content, model.UserId);

            return this.Profile(model.UserId);
        }
    }
}
