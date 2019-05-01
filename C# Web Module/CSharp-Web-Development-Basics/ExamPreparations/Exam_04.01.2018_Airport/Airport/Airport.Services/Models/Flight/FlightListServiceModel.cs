namespace Airport.Services.Models.Flight
{
    using Airport.Common.AutoMapping;
    using Airport.Models;
    using Airport.Services.Models.Ticket;
    using System;
    using System.Collections.Generic;

    public class FlightListServiceModel : IMapWith<Flight>
    {
        public int Id { get; set; }
        
        public string Destination { get; set; }
        
        public string Origin { get; set; }
        
        public DateTime Date { get; set; }
        
        public DateTime Time { get; set; }
        
        public string Image { get; set; }

        public IEnumerable<Models.Ticket.TicketListServiceModel> Tickets { get; set; }
    }
}
