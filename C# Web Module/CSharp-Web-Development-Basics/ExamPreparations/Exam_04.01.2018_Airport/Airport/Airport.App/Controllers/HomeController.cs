namespace Airport.App.Controllers
{
    using Airport.Services.Contracts;
    using Airport.Services.Models.Flight;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class HomeController : BaseController
    {
        private const string DestinationKey = "Destination";
        private const string DepartureTimeKey = "Departure";
        private const string OriginKey = "Origin";

        private readonly IFlightService flightService;

        public HomeController(IFlightService flightService)
        {
            this.flightService = flightService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var allFlights = this.FilterFlightsBySearchTerms()
                .OrderByDescending(f => f.Date)
                .ThenByDescending(f => f.Time);

            var flightsForView = string
                .Join(Environment.NewLine,
                    allFlights
                        .Select(f => this.BuildFlightView(f)));

            this.ViewModel["flights"] = flightsForView;

            return View();
        }

        private IEnumerable<FlightListServiceModel> FilterFlightsBySearchTerms()
        {
            var allFlights = this.flightService.All();

            var urlParams = this.Request.UrlParameters;
            if (urlParams.ContainsKey(DestinationKey) && !string.IsNullOrWhiteSpace(urlParams[DestinationKey]))
            {
                allFlights = allFlights.Where(f => f.Destination.ToLower() == urlParams[DestinationKey].ToLower());
            }
            if (urlParams.ContainsKey(OriginKey) && !string.IsNullOrWhiteSpace(urlParams[OriginKey]))
            {
                allFlights = allFlights.Where(f => f.Origin.ToLower() == urlParams[OriginKey].ToLower());
            }
            if (urlParams.ContainsKey(DepartureTimeKey) && !string.IsNullOrWhiteSpace(urlParams[DepartureTimeKey]))
            {
                if (DateTime.TryParse(urlParams[DepartureTimeKey], CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime departureTime))
                {
                    allFlights = allFlights.Where(f => f.Date.Date == departureTime.Date);
                }
            }

            return allFlights.ToList();
        }

        private string BuildFlightView(FlightListServiceModel flight)
        {
            var row = $@"<a href='/flight/details?id={flight.Id}' class='added-flight'>
                            <img src='{flight.Image}' alt = '{flight.Destination}' class='picture-added-flight'>
                            <h3>{flight.Destination}</h3>
                            <span>from {flight.Origin}</span><span>{flight.Date.ToShortDateString()}</span>
                        </a>";
            return row;
        }
    }
}
