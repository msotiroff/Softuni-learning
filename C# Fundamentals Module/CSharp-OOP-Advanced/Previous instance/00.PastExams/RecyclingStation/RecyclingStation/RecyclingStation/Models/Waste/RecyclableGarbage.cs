using RecyclingStation.Extensions.CustomAttributes;

namespace RecyclingStation.Models.Waste
{
    [Recyclable]
    public class RecyclableGarbage : Waste
    {
        public RecyclableGarbage(string name, double weight, double volumePerKg) 
            : base(name, weight, volumePerKg)
        {
        }
    }
}
