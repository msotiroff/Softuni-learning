namespace Airport.App.Models.Flight
{
    using System;

    public class FlightEditViewModel
    {
        public int Id { get; set; }

        public string Destination { get; set; }

        public string Origin { get; set; }

        public DateTime Date { get; set; }

        public DateTime Time { get; set; }

        public string Image { get; set; }
    }
}
