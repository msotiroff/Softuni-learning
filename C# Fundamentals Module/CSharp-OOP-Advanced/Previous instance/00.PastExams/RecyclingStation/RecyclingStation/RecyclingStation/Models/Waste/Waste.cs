using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Models.Waste
{
    public abstract class Waste : IWaste
    {
        public Waste(string name, double weight, double volumePerKg)
        {
            this.Name = name;
            this.Weight = weight;
            this.VolumePerKg = volumePerKg;
        }

        public double TotalGarbageVolume => this.VolumePerKg * this.Weight;

        public string Name { get; }

        public double VolumePerKg { get; }

        public double Weight { get; }
    }
}
