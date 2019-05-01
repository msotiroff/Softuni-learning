namespace Airport.Services.Contracts
{
    using Models.Flight;
    using System;
    using System.Collections.Generic;

    public interface IFlightService
    {
        bool Create(string destination, string origin, DateTime date, DateTime time, string image);

        FlightListServiceModel GetById(int id);

        IEnumerable<FlightListServiceModel> All();

        bool Update(int id, string destination, string origin, string image, DateTime date, DateTime time);
    }
}
