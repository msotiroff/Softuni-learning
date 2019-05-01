namespace Airport.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Flight
    {
        public Flight()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        public string Origin { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public string Image { get; set; }

        public bool Flag { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}