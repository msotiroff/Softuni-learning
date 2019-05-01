namespace InfernoInfinity.Models.Gems
{
    using InfernoInfinity.Models.Contracts;
    using InfernoInfinity.Models.Enums;

    public abstract class BaseGem : IGem
    {
        protected BaseGem(Clarity clarity, int strength, int agility, int vitality)
        {
            this.Strength = strength + (int)clarity;
            this.Agility = agility + (int)clarity;
            this.Vitality = vitality + (int)clarity;
        }

        public int Strength { get; }

        public int Agility { get; }

        public int Vitality { get; }
    }
}
