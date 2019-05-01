namespace P14.CatLady.Models.Implementation
{
    using Contracts;

    public abstract class Cat : ICat
    {
        private string name;
        private double specificFeature;

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }
    }
}
