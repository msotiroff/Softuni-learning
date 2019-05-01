namespace Airport.Services.Models.Ticket
{
    using Airport.Common.AutoMapping;
    using Airport.Models;

    public class TicketListServiceModel : IMapWith<Ticket>
    {
        public int Id { get; set; }
        
        public decimal Price { get; set; }
        
        public Class Class { get; set; }

        public string FlightImage { get; set; }

        public string FlightDestination { get; set; }

        public string FlightOrigin { get; set; }

        public string FlightDate { get; set; }

        public string FlightTime { get; set; }

        public int CustomerId { get; set; }
    }
}
