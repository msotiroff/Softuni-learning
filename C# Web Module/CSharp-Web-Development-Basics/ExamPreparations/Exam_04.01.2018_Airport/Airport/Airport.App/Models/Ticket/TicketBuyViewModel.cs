namespace Airport.App.Models.Ticket
{
    using System.ComponentModel.DataAnnotations;

    public class TicketBuyViewModel
    {
        [Required]
        public int Amount { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Class { get; set; }

        [Required]
        public int FlightId { get; set; }
    }
}
