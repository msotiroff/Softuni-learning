namespace Notes.App.Controllers
{
    using AutoMapper;
    using Notes.App.Models.Note;
    using Notes.App.Models.User;
    using Notes.Common.Notifications;
    using Notes.Services.Models.Note;
    using Notes.Services.Models.User;
    using Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;
    using System;
    using System.Linq;

    public class AccountController : BaseController
    {
        private readonly IUserService userService;
        private readonly IHashService hashService;
        private readonly INoteService noteService;

        public AccountController(
            IUserService userService, 
            IHashService hashService, 
            INoteService noteService)
        {
            this.userService = userService;
            this.hashService = hashService;
            this.noteService = noteService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var allUsers = this.userService.All();

            this.ViewModel["users"] = string
                .Join(Environment.NewLine, 
                    allUsers.Select(u => this.BuildUserListHtml(u)));

            return View();
        }
        
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var modelStateError = this.ValidateModelState(model);
            if (modelStateError != null)
            {
                this.ShowNotification(modelStateError);
                return View();
            }

            var passwordHash = this.hashService.ComputeHash(model.Password);

            var user = this.userService.TryLogin(model.Username, passwordHash);

            if (user == null)
            {
                this.ShowNotification(NotificationMessages.InvalidLoginAttempt);
                return View();
            }

            this.SignIn(model.Username);
            this.SetUserDetailedSession(Mapper.Map<Identity>(user));

            return RedirectToHome();
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            var modelStateError = this.ValidateModelState(model);

            if (modelStateError != null)
            {
                this.ShowNotification(modelStateError);
                return View();
            }

            var passwordHash = this.hashService.ComputeHash(model.Password);

            var newUserId = this.userService.Create(model.Username, passwordHash);

            if (newUserId < 1)
            {
                this.ShowNotification("Username already taken!");
                return View();
            }
            
            this.SignIn(model.Username);
            this.SetUserDetailedSession(new Identity
            {
                Id = newUserId,
                Username = model.Username
            });

            return RedirectToHome();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            this.SignOut();
            return RedirectToHome();
        }

        [HttpGet]
        public IActionResult Profile(int id)
        {
            var user = this.userService.GetById(id);

            var isUserAuthorized = this.User.IsAuthenticated && this.Identity.Id == id;

            this.ViewModel["userDisplayName"] = user.Username;
            this.ViewModel["authorizedDisplay"] = isUserAuthorized ? "block" : "none";
            this.ViewModel["notes"] = string.Join(Environment.NewLine, user.Notes.Select(n => this.BuildNoteListHtml(n)));

            return View();
        }

        [HttpPost]
        public IActionResult Profile(NoteCreateViewModel model)
        {
            var loggedUserId = this.Identity.Id;

            var modelStateError = this.ValidateModelState(model);
            if (modelStateError != null)
            {
                this.ShowNotification(modelStateError);
                return this.Profile(loggedUserId);
            }

            var success = this.noteService.Create(model.Title, model.Content, loggedUserId);
            if (!success)
            {
                this.ShowNotification(NotificationMessages.InvalidOperation);
                return this.Profile(loggedUserId);
            }

            this.ShowNotification("Note added successfully", NotificationType.success);
            return this.Profile(loggedUserId);
        }

        private string BuildUserListHtml(UserListServiceModel user)
        {
            return $"<li><a href='/account/profile?id={user.Id}'>{user.Username}</a></li>";
        }

        private string BuildNoteListHtml(NoteListSericeModel note)
        {
            return $"<li class='card bg-faded'><p><strong>{note.Title}</strong>:</p><p>{note.Content}</p></li>";
        }

    }
}
