using StorageMaster.Models.Vehicles;
using System;

namespace StorageMaster.Factories
{
    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type)
        {
            Vehicle vehicle = null;

            switch (type)
            {
                case nameof(Semi):
                    vehicle = new Semi();
                    break;
                case nameof(Truck):
                    vehicle = new Truck();
                    break;
                case nameof(Van):
                    vehicle = new Van();
                    break;
                default:
                    throw new InvalidOperationException("Invalid vehicle type!");
            }

            return vehicle;
        }
    }
}
