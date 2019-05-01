namespace Airport.App.Models.Flight
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class FlightCreateViewModel
    {
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
    }
}
