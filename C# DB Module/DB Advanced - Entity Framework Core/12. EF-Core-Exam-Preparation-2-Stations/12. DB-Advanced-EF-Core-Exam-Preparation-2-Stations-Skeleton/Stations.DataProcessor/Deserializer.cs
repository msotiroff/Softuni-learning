namespace Stations.DataProcessor
{
    using System;
    using Stations.Data;
    using System.Globalization;
    using Newtonsoft.Json;
    using Stations.Models;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Stations.DataProcessor.Dto;
    using System.Xml.Linq;
    using Microsoft.EntityFrameworkCore;

    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportStations(StationsDbContext context, string jsonString)
        {
            var stationsFromJson = JsonConvert.DeserializeObject<Station[]>(jsonString);

            var result = new StringBuilder();

            var validStations = new List<Station>();

            foreach (var station in stationsFromJson)
            {
                string name = station.Name;
                string town = station.Town ?? station.Name;

                var isNameValid = !String.IsNullOrWhiteSpace(name) && !validStations.Any(s => s.Name == name) && name?.Length <= 50;

                if (isNameValid && town.Length <= 50)
                {
                    var currentStation = new Station()
                    {
                        Name = name,
                        Town = town
                    };

                    validStations.Add(currentStation);
                    result.AppendLine(string.Format(SuccessMessage, name));
                }
                else
                {
                    result.AppendLine(FailureMessage);
                }
            }

            context.AddRange(validStations);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportClasses(StationsDbContext context, string jsonString)
        {
            var classesFromJson = JsonConvert.DeserializeObject<SeatingClass[]>(jsonString);

            var result = new StringBuilder();

            var validClasses = new List<SeatingClass>();

            foreach (var seatClass in classesFromJson)
            {
                string name = seatClass.Name;
                string abbreviation = seatClass.Abbreviation;

                var isNameValid = !String.IsNullOrWhiteSpace(name)
                    && name?.Length <= 30
                    && !validClasses.Any(c => c.Name == name);

                var isAbbreviationValid = !String.IsNullOrWhiteSpace(abbreviation)
                    && abbreviation?.Length == 2
                    && !validClasses.Any(c => c.Abbreviation == abbreviation);

                if (isNameValid && isAbbreviationValid)
                {
                    var currentSeatClass = new SeatingClass()
                    {
                        Name = name,
                        Abbreviation = abbreviation
                    };

                    validClasses.Add(currentSeatClass);
                    result.AppendLine(string.Format(SuccessMessage, name));
                }
                else
                {
                    result.AppendLine(FailureMessage);
                }
            }

            context.AddRange(validClasses);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportTrains(StationsDbContext context, string jsonString)
        {
            var trainsFromJson = JsonConvert.DeserializeObject<TrainForImportDto[]>(jsonString);

            var result = new StringBuilder();

            var validTrains = new List<Train>();

            foreach (var train in trainsFromJson)
            {
                string trainNumber = train.TrainNumber;
                var type = Enum.Parse<TrainType>(train.Type ?? "HighSpeed");
                var seats = train.Seats;

                var isTrainNumberValid = !String.IsNullOrWhiteSpace(trainNumber)
                    && trainNumber?.Length <= 10
                    && !validTrains.Any(t => t.TrainNumber == trainNumber);

                var areSeatsValid = seats
                    .All(s => context.SeatingClasses
                        .Any(sc => sc.Name == s.Name && sc.Abbreviation == s.Abbreviation)
                        && s.Quantity != null
                        && s.Quantity >= 0);

                if (!isTrainNumberValid || !areSeatsValid)
                {
                    result.AppendLine(FailureMessage);
                    continue;
                }

                var currentTrain = new Train()
                {
                    TrainNumber = trainNumber,
                    Type = type,
                    TrainSeats = new List<TrainSeat>()
                };

                foreach (var seat in train.Seats)
                {
                    var currentSeat = new TrainSeat()
                    {
                        Train = currentTrain,
                        SeatingClass = context.SeatingClasses.SingleOrDefault(sc => sc.Name == seat.Name && sc.Abbreviation == seat.Abbreviation),
                        Quantity = seat.Quantity.Value
                    };

                    currentTrain.TrainSeats.Add(currentSeat);
                }

                validTrains.Add(currentTrain);
                result.AppendLine(string.Format(SuccessMessage, train.TrainNumber));
            }

            context.AddRange(validTrains);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportTrips(StationsDbContext context, string jsonString)
        {
            var tripsFromJson = JsonConvert.DeserializeObject<TripForImportDto[]>(jsonString);

            var result = new StringBuilder();

            var validTrips = new List<Trip>();

            foreach (var trip in tripsFromJson)
            {
                var isCurrentTripValid = trip.DestinationStation != null
                    && trip.OriginStation != null
                    && trip.Train != null
                    && trip.ArrivalTime != null
                    && trip.DepartureTime != null;

                if (!isCurrentTripValid)
                {
                    result.AppendLine(FailureMessage);
                    continue;
                }

                int? trainId = context.Trains.FirstOrDefault(t => t.TrainNumber == trip.Train)?.Id;
                int? originStationId = context.Stations.FirstOrDefault(s => s.Name == trip.OriginStation)?.Id;
                int? destinationStationId = context.Stations.FirstOrDefault(s => s.Name == trip.DestinationStation)?.Id;
                var status = Enum.Parse<TripStatus>(trip.Status ?? "OnTime");
                var departureTime = DateTime.ParseExact(trip.DepartureTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                var arrivalTime = DateTime.ParseExact(trip.ArrivalTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                TimeSpan timeDifference;
                if (trip.TimeDifference != null)
                {
                    timeDifference = TimeSpan.ParseExact(trip.TimeDifference, @"hh\:mm", CultureInfo.InvariantCulture);
                }

                if (trainId == null || originStationId == null || destinationStationId == null || departureTime > arrivalTime)
                {
                    result.AppendLine(FailureMessage);
                    continue;
                }

                var currentTrip = new Trip()
                {
                    TrainId = trainId.Value,
                    OriginStationId = originStationId.Value,
                    DestinationStationId = destinationStationId.Value,
                    ArrivalTime = arrivalTime,
                    DepartureTime = departureTime,
                    Status = status,
                    TimeDifference = timeDifference
                };

                validTrips.Add(currentTrip);
                result.AppendLine($"Trip from {trip.OriginStation} to {trip.DestinationStation} imported.");
            }

            context.Trips.AddRange(validTrips);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }
        
        public static string ImportCards(StationsDbContext context, string xmlString)
        {
            var xmlDoc = XDocument.Parse(xmlString);
            var elements = xmlDoc.Root.Elements();

            var result = new StringBuilder();

            var validCards = new List<CustomerCard>();

            foreach (var element in elements)
            {
                string name = element.Element("Name").Value;
                string ageAsString = element.Element("Age").Value;
                string cardType = element.Element("CardType")?.Value;

                //if (name == null || ageAsString == null)
                //{
                //    result.AppendLine(FailureMessage);
                //    continue;
                //}

                int age;
                if (!int.TryParse(ageAsString, out age))
                {
                    result.AppendLine(FailureMessage);
                    continue;
                }

                if (age < 0 || age > 120 || name.Length > 128)
                {
                    result.AppendLine(FailureMessage);
                    continue;
                }

                CardType card = Enum.Parse<CardType>(cardType ?? "Normal");

                var currentCard = new CustomerCard()
                {
                    Name = name,
                    Age = age,
                    Type = card
                };

                validCards.Add(currentCard);
                result.AppendLine(string.Format(SuccessMessage, name));
            }

            context.Cards.AddRange(validCards);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportTickets(StationsDbContext context, string xmlString)
        {
            var xmlDoc = XDocument.Parse(xmlString);

            var elements = xmlDoc.Root.Elements();

            var result = new StringBuilder();

            var validTickets = new List<Ticket>();

            foreach (var element in elements)
            {
                decimal price = decimal.Parse(element.Attribute("price").Value);
                string seat = element.Attribute("seat").Value;
                string orgStation = element.Element("Trip")?.Element("OriginStation")?.Value;
                string destStation = element.Element("Trip")?.Element("DestinationStation")?.Value;
                string departureTimeAsString = element.Element("Trip")?.Element("DepartureTime")?.Value;
                string cardName = element.Element("Card")?.Attribute("Name")?.Value;

                int seatNumber;
                if (!int.TryParse(seat.Substring(2), out seatNumber) || price < 0)
                {
                    result.AppendLine(FailureMessage);
                    continue;
                }


                CustomerCard card = context.Cards.SingleOrDefault(c => c.Name == cardName);
                DateTime departureTime = DateTime.ParseExact(departureTimeAsString, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                var trip = context
                    .Trips
                    .Include(t => t.OriginStation)
                    .Include(t => t.DestinationStation)
                    .SingleOrDefault(t => t.OriginStation.Name == orgStation 
                                    && t.DestinationStation.Name == destStation
                                    && t.DepartureTime == departureTime
                                    && t.Train.TrainSeats
                                        .Any(ts => ts.SeatingClass.Abbreviation == seat.Substring(0, 2)
                                            && ts.Quantity > 0
                                            && seatNumber <= ts.Quantity)
                                    );

                if (trip == null || (cardName != null && card == null))
                {
                    result.AppendLine(FailureMessage);
                    continue;
                }

                var currentTicket = new Ticket()
                {
                    Price = price,
                    SeatingPlace = seat,
                    TripId = trip.Id,
                    CustomerCardId = card?.Id ?? null
                };

                validTickets.Add(currentTicket);
                result.AppendLine($"Ticket from {trip.OriginStation.Name} to {trip.DestinationStation.Name} " +
                    $"departing at {trip.DepartureTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)} imported.");
            }

            context.Tickets.AddRange(validTickets);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }
    }
}