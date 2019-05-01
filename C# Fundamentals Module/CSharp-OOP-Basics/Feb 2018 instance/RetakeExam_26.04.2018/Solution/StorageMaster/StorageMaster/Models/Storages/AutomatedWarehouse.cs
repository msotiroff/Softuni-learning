using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storages
{
    public class AutomatedWarehouse : Storage
    {
        private const int DefaultCapacity = 1;
        private const int DefaultGarageSlots = 2;

        public AutomatedWarehouse(string name) 
            : base(name, DefaultCapacity, DefaultGarageSlots, new[] { new Truck()})
        {
        }
    }
}
