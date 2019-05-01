namespace Airport.App.Controllers
{
    using Airport.App.Models.Shopping;
    using Airport.App.Models.Ticket;
    using Airport.Common.Notifications;
    using Airport.Models;
    using Airport.Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ShoppingController : BaseController
    {
        private readonly ITicketService ticketService;

        public ShoppingController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        [HttpGet]
        public IActionResult Cart()
        {
            var shoppingCart = this.Request.Session.Get<ShoppingCart>(ShoppingCartKey);
            var tickets = shoppingCart.Tickets.GroupBy(t => t.FlightId).ToDictionary(k => k.First(), v => v.Count());

            this.ViewModel["tickets"] = string.Join(Environment.NewLine,
                tickets.Select(kvp => this.BuildTicketListItem(kvp)));

            return View();
        }

        [HttpGet]
        public IActionResult RemoveFromCart(int flightId)
        {
            var cart = this.Request.Session.Get<ShoppingCart>(ShoppingCartKey);
            var ticketsToRemove = cart.Tickets.Where(t => t.FlightId == flightId);
            var ticketsToRemoveCount = ticketsToRemove.Count();
            cart.Tickets.RemoveAll(t => t.FlightId == flightId);

            this.ticketService.Release(ticketsToRemove);

            this.ShowNotification($"You have successfully removed {ticketsToRemoveCount} tickets from your shopping cart!", NotificationType.success);
            return this.Cart();
        }
        
        [HttpPost]
        public IActionResult AddToCart(TicketBuyViewModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToLogin();
            }

            var modelStateError = this.ValidateModelState(model);
            if (modelStateError != null)
            {
                this.ShowNotification(modelStateError);
                return this.Cart();
            }

            var reservedTickets = this.ticketService.ReserveTickets(model.FlightId, model.Class, model.Amount, this.Identity.Id);
            if (reservedTickets == null)
            {
                this.ShowNotification(NotificationMessages.InvalidOperation);
                return this.Cart();
            }

            this.Request
                .Session
                .Get<ShoppingCart>(ShoppingCartKey)
                .Tickets
                .AddRange(reservedTickets);
            
            this.ShowNotification($"You have successfully added {model.Amount} tickets to your shopping cart!", NotificationType.success);
            return this.Cart();
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            var cart = this.Request.Session.Get<ShoppingCart>(ShoppingCartKey);

            this.ShowNotification($"You successfully bought {cart.Tickets.Count} tickets!", NotificationType.success);
            cart.Tickets.Clear();

            return this.Cart();
        }
        
        private string BuildTicketListItem(KeyValuePair<Ticket, int> kvp)
        {
            var ticketsCount = kvp.Value;
            var ticket = kvp.Key;

            var listItem = $@"<section class='single-ticket'>
                                      <div class='left-ticket-container'>
                                        <img src = '{ticket.Flight.Image}' alt='{ticket.Flight.Destination}' class='destination-img'>
                                        <div class='flight-parameters'>
                                            <span class='ticket-price'>Price: {ticket.Price}$</span>
                                            <span class='ticket-class'>Class: {ticket.Class.ToString()}</span>
                                        </div>
                                    </div>
                                    <div class='right-ticket-container'>
                                        <h2>{ticket.Flight.Destination}</h2>
                                        <p>from {ticket.Flight.Origin}</p>
                                        <p>{ticket.Flight.Date.ToShortDateString()}</p>
                                        <p>{ticket.Flight.Time.ToShortTimeString()}</p>
                                        <div>
                                            <span class='number-of-tickets'>{ticketsCount}</span>
                                            <a href='/shopping/RemoveFromCart?flightId={ticket.FlightId}' class='remove'>REMOVE</a>
                                        </div>
                                    </div>
                                </section>
                                <section class='ticket-checkout'>
                                    <div class='total'>Sub total: {(ticket.Price * ticketsCount):f2}$</div>
                                </section>";

            return listItem;
        }
    }
}
