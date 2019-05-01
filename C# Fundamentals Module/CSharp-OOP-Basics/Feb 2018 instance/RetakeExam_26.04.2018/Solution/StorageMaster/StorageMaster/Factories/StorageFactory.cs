using StorageMaster.Models.Storages;
using System;

namespace StorageMaster.Factories
{
    public class StorageFactory
    {
        public Storage CreateStorage(string type, string name)
        {
            Storage storage = null;

            switch (type)
            {
                case nameof(Warehouse):
                    storage = new Warehouse(name);
                    break;
                case nameof(DistributionCenter):
                    storage = new DistributionCenter(name);
                    break;
                case nameof(AutomatedWarehouse):
                    storage = new AutomatedWarehouse(name);
                    break;
                default:
                    throw new InvalidOperationException("Invalid storage type!");
            }

            return storage;
        }
    }
}
