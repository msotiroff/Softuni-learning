namespace P14.CatLady.Models.Implementation
{
    public class StreetExtraordinaire : Cat
    {
        private int decibelsOfMeows;

        public StreetExtraordinaire(string name, int decibelsOfMeows)
        {
            this.Name = name;
            this.DecibelsOfMeows = decibelsOfMeows;
        }

        public int DecibelsOfMeows
        {
            get => this.decibelsOfMeows;

            private set
            {
                this.decibelsOfMeows = value;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} {this.Name} {this.decibelsOfMeows}";
        }
    }
}
