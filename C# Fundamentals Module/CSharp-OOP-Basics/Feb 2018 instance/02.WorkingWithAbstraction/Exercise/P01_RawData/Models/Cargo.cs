namespace P01_RawData.Models
{
    public class Cargo
    {
        public int Weight { get; private set; }

        public string Type { get; private set; }

        public Cargo(int weight, string type)
        {
            this.Weight = weight;
            this.Type = type;
        }
    }
}