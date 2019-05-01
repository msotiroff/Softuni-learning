using System;
using Stations.Data;
using System.Globalization;
using System.Linq;
using Stations.Models.Enums;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Stations.DataProcessor
{
	public class Serializer
	{
		public static string ExportDelayedTrains(StationsDbContext context, string dateAsString)
		{
            var inputDate = DateTime.ParseExact(dateAsString, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            var trains = context
                .Trains
                .Where(t => t.Trips
                    .Any(trip => trip.Status.ToString() == "Delayed"
                            && trip.DepartureTime <= inputDate))
                .Select(t => new
                {
                    TrainNumber = t.TrainNumber,
                    DelayedTimes = t.Trips.Count(tr => tr.Status == TripStatus.Delayed),
                    MaxDelayedTime = t.Trips.Max(tr => tr.TimeDifference)
                })
                .OrderByDescending(x => x.DelayedTimes)
                .ThenByDescending(x => x.MaxDelayedTime)
                .ThenBy(x => x.TrainNumber)
                .ToArray();

            var result = JsonConvert.SerializeObject(trains, Formatting.Indented);

            return result;
		}

		public static string ExportCardsTicket(StationsDbContext context, string cardType)
		{
            var cards = context
                .Cards
                .Where(c => c.Type.ToString() == cardType && c.BoughtTickets.Any())
                .Select(c => new
                {
                    CardName = c.Name,
                    CardType = cardType,
                    Tickets = c.BoughtTickets
                        .Select(bt => new
                        {
                            OriginStation = bt.Trip.OriginStation.Name,
                            DestinationStation = bt.Trip.DestinationStation.Name,
                            DepartureTime = bt.Trip.DepartureTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)
                        })
                        .ToArray()
                })
                .OrderBy(a => a.CardName)
                .ToArray();

            var xmlDoc = new XDocument(new XElement("Cards"));

            foreach (var card in cards)
            {
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
                                    new XAttribute("name", card.CardName),
                                    new XAttribute("type", card.CardType),
                                    new XElement("Tickets", tickets)));
            }

            var result = xmlDoc.ToString();

            return result;
		}
	}
}