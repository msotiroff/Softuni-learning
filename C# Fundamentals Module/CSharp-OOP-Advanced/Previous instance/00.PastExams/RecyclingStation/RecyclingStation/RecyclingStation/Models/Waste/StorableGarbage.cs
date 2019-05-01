using RecyclingStation.Extensions.CustomAttributes;

namespace RecyclingStation.Models.Waste
{
    [Storable]
    public class StorableGarbage : Waste
    {
        public StorableGarbage(string name, double weight, double volumePerKg) 
            : base(name, weight, volumePerKg)
        {
        }
    }
}
