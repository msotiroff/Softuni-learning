namespace Airport.Services.Implementations
{
    using Airport.Data;
    using Airport.Models;
    using Contracts;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TicketService : DataAccessService, ITicketService
    {
        public TicketService(AirportDbContext db) 
            : base(db)
        {
        }

        public bool Create(int flightId, int amount, string @class, decimal price)
        {
            var flight = this.db.Flights.FirstOrDefault(f => f.Id == flightId);
            if (flight == null)
            {
                return false;
            }

            var tickets = this.SeedTicketsToCollection(amount, @class, price, flightId);
            if (!tickets.Any())
            {
                return false;
            }

            this.db.Tickets.AddRange(tickets);
            this.db.SaveChanges();

            return true;
        }

        public void Release(IEnumerable<Ticket> ticketstToRemove)
        {
            var tickets = this.db
                .Tickets
                .Where(t => ticketstToRemove.Select(tick => tick.Id)
                    .Contains(t.Id))
                .ToList();

            tickets
                .ForEach(t => t.CustomerId = null);

            this.db.UpdateRange(tickets);
            this.db.SaveChanges();
        }

        public IEnumerable<Ticket> ReserveTickets(int flightId, string ticketClass, int amount, int userId)
        {
            var tickets = this.db
                .Tickets
                .Include(t => t.Flight)
                .Where(t => t.FlightId == flightId && t.Class.ToString() == ticketClass && t.CustomerId == null)
                .Take(amount)
                .ToList();

            if (tickets.Count < amount)
            {
                return null;
            }

            tickets
                .ForEach(t => t.CustomerId = userId);

            this.db.Tickets.UpdateRange(tickets);
            this.db.SaveChanges();

            return tickets;          
        }

        private IEnumerable<Ticket> SeedTicketsToCollection(int amount, string type, decimal price, int flightId)
        {
            var tickets = new List<Ticket>();
            Class @class;
            if (!Enum.TryParse<Class>(type, out @class))
            {
                return tickets;
            }

            for (int i = 0; i < amount; i++)
            {
                tickets.Add(new Ticket
                {
                    Price = price,
                    Class = @class,
                    FlightId = flightId
                });
            }

            return tickets;
        }
    }
}
