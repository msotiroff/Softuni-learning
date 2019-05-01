using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storages
{
    public class Warehouse : Storage
    {
        private const int DefaultCapacity = 10;
        private const int DefaultGarageSlots = 10;

        public Warehouse(string name)
            : base(name, DefaultCapacity, DefaultGarageSlots, new Vehicle[] { new Semi(), new Semi(), new Semi() })
        {
        }
    }
}
