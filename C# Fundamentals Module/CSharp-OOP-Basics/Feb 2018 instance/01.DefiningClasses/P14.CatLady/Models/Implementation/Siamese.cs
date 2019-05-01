namespace P14.CatLady.Models.Implementation
{
    public class Siamese : Cat
    {
        private int earSize;

        public Siamese(string name, int earSize)
        {
            this.Name = name;
            this.EarSize = earSize;
        }

        public int EarSize
        {
            get => this.earSize;

            private set
            {
                this.earSize = value;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} {this.Name} {this.earSize}";
        }
    }
}
