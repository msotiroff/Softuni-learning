namespace Notes.App.Controllers
{
    using MvcFramework.Attributes.Methods;
    using MvcFramework.Controllers;
    using MvcFramework.Interfaces;
    using Notes.App.Infrastructure.Helpers;
    using Notes.App.Models.Note;
    using Notes.App.Models.User;
    using Notes.Models;
    using Notes.Repositories.Contracts;
    using System;
    using System.Linq;

    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly INoteRepository noteRepository;

        public UserController(IUserRepository userRepository, INoteRepository noteRepository)
        {
            this.userRepository = userRepository;
            this.noteRepository = noteRepository;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!this.IsValidModel(model))
            {
                return View();
            }

            var username = model.Username;
            var passwordHash = HashProvider.ComputeHash(model.Password);

            var success = this.userRepository.TryLogin(username, passwordHash);

            if (!success)
            {
                return View();
            }

            this.SignIn(model.Username);

            return RedirectToAction("/home/index");
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!this.IsValidModel(model))
            {
                return View();
            }

            var user = new User
            {
                Username = model.Username,
                Password = HashProvider.ComputeHash(model.Password)
            };

            this.userRepository.Add(user);
            var success = this.userRepository.Commit() > 0;

            if (!success)
            {
                return View();
            }

            this.SignIn(model.Username);

            return RedirectToAction("/home/index");
        }

        [HttpGet]
        public IActionResult All()
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToAction("/user/login");
            }

            var users = this.userRepository
                .All()
                .ToDictionary(k => k.Id, v => v.Username);

            this.Model["users"] = users.Any()
                ? string.Join(string.Empty, users.Select(u => $"<li><a href='/user/profile?id={u.Key}'>{u.Value}</a></li>"))
                : string.Empty;

            return View();
        }

        [HttpGet]
        public IActionResult Profile(int id)
        {
            var user = this.userRepository.GetWithNotes(id);

            this.Model["username"] = user.Username;
            this.Model["userId"] = user.Id.ToString();
            this.Model["notes"] = string.Join(Environment.NewLine,
                user.Notes
                .Select(n => $"<li>{n.Title} - {n.Content}</li>"));

            return View();
        }

        [HttpPost]
        public IActionResult Profile(NoteCreateViewModel model)
        {
            if (!this.IsValidModel(model))
            {
                return View();
            }

            var note = new Note
            {
                Title = model.Title,
                Content = model.Content,
                UserId = model.UserId
            };

            this.noteRepository.Add(note);
            this.noteRepository.Commit();

            return this.Profile(model.UserId);
        }
    }
}
