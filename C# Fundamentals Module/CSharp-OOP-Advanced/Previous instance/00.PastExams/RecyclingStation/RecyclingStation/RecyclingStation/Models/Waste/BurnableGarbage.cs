using RecyclingStation.Extensions.CustomAttributes;

namespace RecyclingStation.Models.Waste
{
    [Burnable]
    public class BurnableGarbage : Waste
    {
        public BurnableGarbage(string name, double weight, double volumePerKg) 
            : base(name, weight, volumePerKg)
        {
        }

        
    }
}
