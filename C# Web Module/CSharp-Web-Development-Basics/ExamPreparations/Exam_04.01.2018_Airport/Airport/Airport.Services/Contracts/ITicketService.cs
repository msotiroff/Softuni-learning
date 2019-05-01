namespace Airport.Services.Contracts
{
    using Airport.Models;
    using System.Collections.Generic;

    public interface ITicketService
    {
        bool Create(int flightId, int amount, string @class, decimal price);

        IEnumerable<Ticket> ReserveTickets(int flightId, string type, int amount, int userId);

        void Release(IEnumerable<Ticket> ticketstToRemove);
    }
}
