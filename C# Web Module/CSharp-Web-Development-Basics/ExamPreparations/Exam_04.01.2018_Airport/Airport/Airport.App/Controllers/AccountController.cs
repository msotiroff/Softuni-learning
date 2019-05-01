namespace Airport.App.Controllers
{
    using AutoMapper;
    using Airport.App.Models.User;
    using Airport.Common.Notifications;
    using Airport.Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;
    using System.Linq;
    using System;
    using Airport.Services.Models.Flight;

    public class AccountController : BaseController
    {
        private readonly IUserService userService;
        private readonly IHashService hashService;
        private readonly IFlightService flightService;

        public AccountController(IUserService userService, IHashService hashService, IFlightService flightService)
        {
            this.userService = userService;
            this.hashService = hashService;
            this.flightService = flightService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (this.User.IsAuthenticated)
            {
                return RedirectToHome();
            }

            return View();
        }

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
            var loggedUser = this.userService.TryLogin(model.Email, passwordHash);
            if (loggedUser == null)
            {
                this.ShowNotification(NotificationMessages.InvalidLoginAttempt);
                return View();
            }

            this.SignIn(loggedUser.Name);
            this.SetUpUserDetailedSession(Mapper.Map<Identity>(loggedUser));

            return RedirectToHome();
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (this.User.IsAuthenticated)
            {
                return RedirectToHome();
            }

            return View();
        }

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
            var registeredUser = this.userService.Create(model.Email, model.Name, passwordHash);
            if (registeredUser == null)
            {
                this.ShowNotification(NotificationMessages.UserExist);
                return View();
            }

            this.SignIn(model.Name);
            this.SetUpUserDetailedSession(Mapper.Map<Identity>(registeredUser));

            return RedirectToHome();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            this.SignOut();
            this.DropDownUserDetailedSession();
            return RedirectToHome();
        }

        [HttpGet]
        public IActionResult Profile()
        {
            if (!this.User.IsAuthenticated)
            {
                this.ShowNotification("You have to be logged in, in order to see your flights!");
                return this.Login();
            }

            var userId = this.Identity.Id;

            var userFlights = this.flightService
                .All()
                .Where(f => f.Tickets.Any(t => t.CustomerId == userId));

            this.ViewModel["flights"] = string.Join(Environment.NewLine,
                userFlights.Select(f => this.BuildFlightListItem(f)));

            return View();
        }

        private string BuildFlightListItem(FlightListServiceModel flight)
        {
            var ticketsCount = flight.Tickets.Where(t => t.CustomerId == this.Identity.Id).Count();
            var ticketPrice = flight.Tickets.First().Price;
            var ticketClass = flight.Tickets.First().Class.ToString();

            var listItem = $@"<section class='purchased-ticket'>
                                <div class='purchased-left'>
                                    <img src='{flight.Image}' alt='{flight.Destination}'>
                                </div>
                                <div class='purchased-right'>
                                    <div>
                                        <h3>{flight.Destination}</h3><span>{flight.Date.ToShortDateString()}</span>
                                    </div>
                                    <div>
                                        from {flight.Origin} <span>{flight.Time.ToShortTimeString()}</span>
                                    </div>
                                    <p>{ticketsCount} x {ticketPrice}$({ticketClass}) </p>
                                </div>
                            </section>";

            return listItem;
        }
    }
}
