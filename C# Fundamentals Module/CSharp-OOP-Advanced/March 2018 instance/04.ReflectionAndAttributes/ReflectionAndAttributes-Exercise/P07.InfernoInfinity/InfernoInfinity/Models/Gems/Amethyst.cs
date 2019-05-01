namespace InfernoInfinity.Models.Gems
{
    using InfernoInfinity.Models.Enums;

    public class Amethyst : BaseGem
    {
        private const int DefaultStrength = 2;
        private const int DefaultAgility = 8;
        private const int DefaultVitality = 4;

        public Amethyst(Clarity clarity) 
            : base(clarity, DefaultStrength, DefaultAgility, DefaultVitality)
        {
        }
    }
}
