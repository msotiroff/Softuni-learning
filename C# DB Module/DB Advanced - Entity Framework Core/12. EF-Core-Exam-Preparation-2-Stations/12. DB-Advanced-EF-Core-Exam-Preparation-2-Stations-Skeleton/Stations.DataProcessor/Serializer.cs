namespace Stations.DataProcessor
{
    using System;
    using Stations.Data;
    using System.Globalization;
    using System.Linq;
    using Stations.Models;
    using Newtonsoft.Json;
    using System.Xml.Linq;
    using System.Collections.Generic;

    public class Serializer
	{
		public static string ExportDelayedTrains(StationsDbContext context, string dateAsString)
		{
            DateTime givenDate = DateTime.ParseExact(dateAsString, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            var trains = context
                .Trains
                .Where(t => t.Trips
                    .Any(trip => trip.Status == TripStatus.Delayed && trip.DepartureTime <= givenDate))
                .Select(t => new
                {
                    TrainNumber = t.TrainNumber,
                    DelayedTimes = t.Trips
                        .Where(trip => trip.Status == TripStatus.Delayed && trip.DepartureTime <= givenDate)
                        .Count(),
                    MaxDelayedTime = t.Trips.Max(trip => trip.TimeDifference)
                })
                .OrderByDescending(x => x.DelayedTimes)
                .ThenByDescending(x => x.MaxDelayedTime)
                .ThenBy(x => x.TrainNumber)
                .ToArray();

            string result = JsonConvert.SerializeObject(trains, Formatting.Indented);

            return result;
		}

		public static string ExportCardsTicket(StationsDbContext context, string cardType)
		{
            CardType givenType = Enum.Parse<CardType>(cardType);

            var cards = context
                .Cards
                .Where(c => c.Type == givenType && c.BoughtTickets.Count > 0)
                .Select(c => new
                {
                    name = c.Name,
                    type = cardType,
                    Tickets = c.BoughtTickets
                        .Select(t => new
                        {
                            OriginStation = t.Trip.OriginStation.Name,
                            DestinationStation = t.Trip.DestinationStation.Name,
                            DepartureTime = t.Trip.DepartureTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)
                        })
                        .ToArray()
                })
                .OrderBy(x => x.name)
                .ToArray();

            var xmlDoc = new XDocument(new XElement("Cards"));

            foreach (var card in cards)
            {
                string cardName = card.name;
                string type = card.type;

                var tickets = new List<XElement>();

                foreach (var ticket in card.Tickets)
                {
                    var currentTicket = new XElement("Ticket",
                                                new XElement("OriginStation", ticket.OriginStation),
                                                new XElement("DestinationStation", ticket.DestinationStation),
                                                new XElement("DepartureTime", ticket.DepartureTime));

                    tickets.Add(currentTicket);
                }

                xmlDoc.Root.Add(new XElement("Card",
                                    new XAttribute("name", cardName),
                                    new XAttribute("type", type),
                                    new XElement("Tickets", tickets)));
            }

            string xmlResult = xmlDoc.ToString();

            return xmlResult;
        }
	}
}