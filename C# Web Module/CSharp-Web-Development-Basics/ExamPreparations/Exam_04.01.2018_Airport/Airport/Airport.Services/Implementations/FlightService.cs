namespace Airport.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Airport.Data;
    using Airport.Models;
    using Airport.Services.Contracts;
    using Airport.Services.Models.Flight;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;

    public class FlightService : DataAccessService, IFlightService
    {
        public FlightService(AirportDbContext db) 
            : base(db)
        {
        }
        
        public IEnumerable<FlightListServiceModel> All()
        {
            return this.db
                .Flights
                .ProjectTo<FlightListServiceModel>()
                .ToArray();
        }

        public bool Create(string destination, string origin, DateTime date, DateTime time, string image)
        {
            var flight = new Flight
            {
                Destination = destination,
                Origin = origin,
                Date = date,
                Time = time,
                Image = image
            };

            if (!this.ValidateModelState(flight))
            {
                return false;
            }

            this.db.Flights.Add(flight);
            this.db.SaveChanges();

            return true;
        }

        public FlightListServiceModel GetById(int id)
        {
            var flight = this.db.Flights.Include(f => f.Tickets).FirstOrDefault(f => f.Id == id);
            if (flight == null)
            {
                return null;
            }

            return Mapper.Map<FlightListServiceModel>(flight);
        }

        public bool Update(int id, string destination, string origin, string image, DateTime date, DateTime time)
        {
            var flight = this.db.Flights.FirstOrDefault(f => f.Id == id);
            if (flight == null)
            {
                return false;
            }

            try
            {
                flight.Destination = destination;
                flight.Origin = origin;
                flight.Image = image;
                flight.Date = date.Date;
                flight.Time = time.ToUniversalTime();

                if (!this.ValidateModelState(flight))
                {
                    return false;
                }

                this.db.Flights.Update(flight);
                this.db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
