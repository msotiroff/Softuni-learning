namespace P14.CatLady.Models.Implementation
{
    public class Cymric : Cat
    {
        private double furLength;

        public Cymric(string name, double furLength)
        {
            this.Name = name;
            this.FurLength = furLength;
        }

        public double FurLength
        {
            get => furLength;

            private set
            {
                this.furLength = value;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} {this.Name} {this.furLength:f2}";
        }
    }
}
