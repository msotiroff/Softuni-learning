namespace Airport.App.Controllers
{
    using Airport.App.Models.Flight;
    using Airport.App.Models.Ticket;
    using Airport.Common.Notifications;
    using Airport.Models;
    using Airport.Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;
    using System.Globalization;
    using System.Linq;

    public class FlightController : BaseController
    {
        private readonly IFlightService flightService;
        private readonly ITicketService ticketService;

        public FlightController(IFlightService flightService, ITicketService ticketService)
        {
            this.flightService = flightService;
            this.ticketService = ticketService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            if (!this.Identity.IsAdmin)
            {
                return RedirectToHome();
            }

            return View();
        }

        [HttpPost]
        public IActionResult Add(FlightCreateViewModel model)
        {
            var modelStateError = this.ValidateModelState(model);
            if (modelStateError != null)
            {
                this.ShowNotification(modelStateError);
                return View();
            }

            var date = model.Date.Date;
            var time = model.Time.ToUniversalTime();

            var success = this.flightService.Create(model.Destination, model.Origin, date, time, model.Image);
            if (!success)
            {
                this.ShowNotification(NotificationMessages.InvalidOperation);
                return View();
            }

            return RedirectToHome();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToLogin();
            }

            if (!this.Identity.IsAdmin)
            {
                this.ShowNotification(NotificationMessages.AccessDenied);
                return this.Details(id);
            }

            var flight = this.flightService.GetById(id);

            this.ViewModel["id"] = id.ToString();
            this.ViewModel["destination"] = flight.Destination;
            this.ViewModel["origin"] = flight.Origin;
            this.ViewModel["date"] = flight.Date.Date.ToString(CultureInfo.CurrentCulture);
            this.ViewModel["time"] = flight.Time.ToUniversalTime().ToLongTimeString();
            this.ViewModel["image"] = flight.Image;
            
            return View();
        }

        [HttpPost]
        public IActionResult Edit(FlightEditViewModel model)
        {
            var modelStateError = this.ValidateModelState(model);
            if (modelStateError != null)
            {
                this.ShowNotification(modelStateError);
                return this.Edit(model.Id);
            }

            var updated = this.flightService.Update(model.Id, model.Destination, model.Origin, model.Image, model.Date, model.Time);
            if (!updated)
            {
                this.ShowNotification("Something went wrong!");
                return this.Edit(model.Id);
            }

            this.ShowNotification("Flight successfully updated!", NotificationType.success);
            return this.Details(model.Id);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToLogin();
            }

            var flight = this.flightService.GetById(id);

            this.ViewModel["flight-destination"] = flight.Destination;
            this.ViewModel["flight-origin"] = flight.Origin;
            this.ViewModel["flight-datetime"] = flight.Date.ToShortDateString() + " " + flight.Time.ToShortTimeString();
            this.ViewModel["flight-id"] = flight.Id.ToString();
            this.ViewModel["business-price"] = flight.Tickets.FirstOrDefault(t => t.Class == Class.Business)?.Price.ToString();
            this.ViewModel["economy-price"] = flight.Tickets.FirstOrDefault(t => t.Class == Class.Economy)?.Price.ToString();
            this.ViewModel["show-business"] = ViewModel["business-price"] != null ? "flex" : "none";
            this.ViewModel["show-economy"] = ViewModel["economy-price"] != null ? "flex" : "none";

            return View();
        }

        [HttpPost]
        public IActionResult AddSeat(TicketCreateViewModel model)
        {
            if (!this.Identity.IsAdmin)
            {
                return RedirectToHome();
            }

            if (this.ValidateModelState(model) != null)
            {
                return RedirectToHome();
            }

            var ticketsAdded = this.ticketService.Create(model.FlightId, model.Amount, model.Type, model.Price);
            if (!ticketsAdded)
            {
                this.ShowNotification("Something went wrong! Tickets not added!");
                return this.Details(model.FlightId);
            }

            this.ShowNotification("Tickets added successfully", NotificationType.success);
            return this.Details(model.FlightId);
        }
    }
}
