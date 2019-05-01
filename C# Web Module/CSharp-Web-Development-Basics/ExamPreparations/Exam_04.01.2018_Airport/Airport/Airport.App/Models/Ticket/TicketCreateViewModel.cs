namespace Airport.App.Models.Ticket
{
    using System.ComponentModel.DataAnnotations;
    
    public class TicketCreateViewModel
    {
        [Required]
        public int Amount { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int FlightId { get; set; }
    }
}
