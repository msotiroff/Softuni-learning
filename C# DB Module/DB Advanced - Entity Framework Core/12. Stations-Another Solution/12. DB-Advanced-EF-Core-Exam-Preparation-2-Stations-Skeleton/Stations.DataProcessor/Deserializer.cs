namespace Stations.DataProcessor
{
    using System;
    using Stations.Data;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Stations.DataProcessor.Dto.ImportDtos;
    using System.Text;
    using Stations.Models;
    using System.Linq;
    using AutoMapper;
    using Stations.Models.Enums;
    using System.Globalization;
    using System.Xml.Serialization;
    using System.IO;
    using Microsoft.EntityFrameworkCore;

    public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";

		public static string ImportStations(StationsDbContext context, string jsonString)
		{
            var stationsFromJson = JsonConvert.DeserializeObject<StationDto[]>(jsonString);

            var result = new StringBuilder();

            var validStations = new List<Station>();

            foreach (var stationDto in stationsFromJson)
            {
                if (!IsValid(stationDto))
                {
                    result.AppendLine(FailureMessage);
                    continue;
                }

                if (stationDto.Town == null)
                {
                    stationDto.Town = stationDto.Name;
                }

                var stationExist = validStations.Any(s => s.Name == stationDto.Name);
                if (stationExist)
                {
                    result.AppendLine(FailureMessage);
                    continue;
                }

                var currentStation = Mapper.Map<Station>(stationDto);

                validStations.Add(currentStation);
                result.AppendLine(string.Format(SuccessMessage, stationDto.Name));
            }

            context.AddRange(validStations);
            context.SaveChanges();

            return result.ToString().TrimEnd();
		}

		public static string ImportClasses(StationsDbContext context, string jsonString)
		{
            var classesFromJson = JsonConvert.DeserializeObject<SeatingClassDto[]>(jsonString);

            var result = new StringBuilder();

            var validClasses = new List<SeatingClass>();

            foreach (var classDto in classesFromJson)
            {
                if (!IsValid(classDto))
                {
                    result.AppendLine(FailureMessage);
                    continue;
                }

                var classExist = validClasses.Any(c => c.Name == classDto.Name || c.Abbreviation == classDto.Abbreviation);
                if (classExist)
                {
                    result.AppendLine(FailureMessage);
                    continue;
                }

                var currentClass = Mapper.Map<SeatingClass>(classDto);
                validClasses.Add(currentClass);
                result.AppendLine(string.Format(SuccessMessage, classDto.Name));
            }

            context.AddRange(validClasses);
            context.SaveChanges();

            return result.ToString().TrimEnd();
		}

		public static string ImportTrains(StationsDbContext context, string jsonString)
		{
            var trainsFromJson = JsonConvert.DeserializeObject<TrainDto[]>(jsonString);

            var result = new StringBuilder();

            var validTrains = new List<Train>();

            foreach (var trainDto in trainsFromJson)
            {
                if (!IsValid(trainDto))
                {
                    result.AppendLine(FailureMessage);
                    continue;
                }

                var isTrainUnique = validTrains.All(t => t.TrainNumber != trainDto.TrainNumber);
                if (!isTrainUnique)
                {
                    result.AppendLine(FailureMessage);
                    continue;
                }

                var areAllSeatsValid = trainDto.Seats.All(s => IsValid(s))
                    && trainDto.Seats.All(s => context.SeatingClasses.
                                            Any(sc => sc.Name == s.Name && sc.Abbreviation == s.Abbreviation));
                if (!areAllSeatsValid)
                {
                    result.AppendLine(FailureMessage);
                    continue;
                }

                var currentTrainSeats = trainDto
                    .Seats
                    .Select(s => new TrainSeat
                    {
                        SeatingClass = context.SeatingClasses.First(sc => sc.Name == s.Name && sc.Abbreviation == s.Abbreviation),
                        Quantity = s.Quantity.Value
                    })
                    .ToArray();

                var currentTrain = new Train()
                {
                    TrainNumber = trainDto.TrainNumber,
                    Type = Enum.Parse<TrainType>(trainDto.Type ?? "HighSpeed"),
                    TrainSeats = currentTrainSeats
                };

                validTrains.Add(currentTrain);
                result.AppendLine(string.Format(SuccessMessage, trainDto.TrainNumber));
            }

            context.AddRange(validTrains);
            context.SaveChanges();

            return result.ToString().TrimEnd();
		}

		public static string ImportTrips(StationsDbContext context, string jsonString)
		{
            var tripsFromJson = JsonConvert.DeserializeObject<TripDto[]>(jsonString);

            var result = new StringBuilder();

            var validTrips = new List<Trip>();

            foreach (var tripDto in tripsFromJson)
            {
                if (!IsValid(tripDto))
                {
                    result.AppendLine(FailureMessage);
                    continue;
                }

                var orgStation = context.Stations.FirstOrDefault(s => s.Name == tripDto.OriginStation);
                var destStation = context.Stations.FirstOrDefault(s => s.Name == tripDto.DestinationStation);
                var train = context.Trains.FirstOrDefault(t => t.TrainNumber == tripDto.Train);

                if (train == null || orgStation == null || destStation == null)
                {
                    result.AppendLine(FailureMessage);
                    continue;
                }

                var status = Enum.Parse<TripStatus>(tripDto.Status ?? "OnTime");
                var departureTime = DateTime.ParseExact(tripDto.DepartureTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                var arrivalTime = DateTime.ParseExact(tripDto.ArrivalTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                if (departureTime > arrivalTime)
                {
                    result.AppendLine(FailureMessage);
                    continue;
                }

                TimeSpan? timeDifference = null;
                if (tripDto.TimeDifference != null)
                {
                    timeDifference = TimeSpan.ParseExact(tripDto.TimeDifference, @"hh\:mm", CultureInfo.InvariantCulture);
                }

                var currentTrip = new Trip()
                {
                    Train = train,
                    OriginStation = orgStation,
                    DestinationStation = destStation,
                    DepartureTime = departureTime,
                    ArrivalTime = arrivalTime,
                    Status = status,
                    TimeDifference = timeDifference
                };

                validTrips.Add(currentTrip);
                result.AppendLine($"Trip from {tripDto.OriginStation} to {tripDto.DestinationStation} imported.");
            }

            context.AddRange(validTrips);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

		public static string ImportCards(StationsDbContext context, string xmlString)
		{
            var serializer = new XmlSerializer(typeof(CardDto[]), new XmlRootAttribute("Cards"));

            var deserializedCards = (CardDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var result = new StringBuilder();

            var validCards = new List<CustomerCard>();

            foreach (var cardDto in deserializedCards)
            {
                if (!IsValid(cardDto))
                {
                    result.AppendLine(FailureMessage);
                    continue;
                }

                var currentCard = new CustomerCard()
                {
                    Name = cardDto.Name,
                    Age = cardDto.Age.Value,
                    Type = Enum.Parse<CardType>(cardDto.Type)
                };

                validCards.Add(currentCard);
                result.AppendLine(string.Format(SuccessMessage, cardDto.Name));
            }

            context.Cards.AddRange(validCards);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

		public static string ImportTickets(StationsDbContext context, string xmlString)
		{
            var serializer = new XmlSerializer(typeof(TicketDto[]), new XmlRootAttribute("Tickets"));

            var deserializedTickets = (TicketDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var result = new StringBuilder();

            var validTickets = new List<Ticket>();

            foreach (var ticketDto in deserializedTickets)
            {
                if (!IsValid(ticketDto))
                {
                    result.AppendLine(FailureMessage);
                    continue;
                }

                var currentTrip = context
                    .Trips
                    .Include(t => t.Train)
                    .ThenInclude(tr => tr.TrainSeats)
                    .ThenInclude(ts => ts.SeatingClass)
                    .SingleOrDefault(t => t.OriginStation.Name == ticketDto.Trip.OriginStation
                                        && t.DestinationStation.Name == ticketDto.Trip.DestinationStation
                                        && t.DepartureTime == DateTime.ParseExact(ticketDto.Trip.DepartureTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture));

                if (currentTrip == null)
                {
                    result.AppendLine(FailureMessage);
                    continue;
                }

                var train = currentTrip.Train;

                var isSeatingClassExisting = context
                    .SeatingClasses
                    .Any(sc => sc.Abbreviation == ticketDto.SeatingPlace.Substring(0, 2));

                var seatExists = train
                    .TrainSeats
                    .Any(ts => ts.SeatingClass.Abbreviation == ticketDto.SeatingPlace.Substring(0, 2)
                        && int.Parse(ticketDto.SeatingPlace.Substring(2)) <= ts.Quantity);

                if (!isSeatingClassExisting || !seatExists)
                {
                    result.AppendLine(FailureMessage);
                    continue;
                }

                CustomerCard customerCard = null;
                if (ticketDto.CustomerCard != null)
                {
                    customerCard = context.Cards
                        .FirstOrDefault(c => c.Name == ticketDto.CustomerCard.Name);
                }

                if (ticketDto.CustomerCard != null && customerCard == null)
                {
                    result.AppendLine(FailureMessage);
                    continue;
                }

                var currentTicket = new Ticket()
                {
                    Price = ticketDto.Price,
                    Trip = currentTrip,
                    SeatingPlace = ticketDto.SeatingPlace,
                    CustomerCard = customerCard
                };

                validTickets.Add(currentTicket);
                result.AppendLine($"Ticket from {ticketDto.Trip.OriginStation} to {ticketDto.Trip.DestinationStation} departing at {ticketDto.Trip.DepartureTime} imported.");
            }

            context.Tickets.AddRange(validTickets);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
            return isValid;
        }
    }
}