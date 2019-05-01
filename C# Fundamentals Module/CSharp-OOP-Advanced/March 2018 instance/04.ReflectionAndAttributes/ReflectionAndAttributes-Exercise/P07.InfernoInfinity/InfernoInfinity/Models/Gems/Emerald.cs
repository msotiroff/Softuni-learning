namespace InfernoInfinity.Models.Gems
{
    using InfernoInfinity.Models.Enums;

    public class Emerald : BaseGem
    {
        private const int DefaultStrength = 1;
        private const int DefaultAgility = 4;
        private const int DefaultVitality = 9;

        public Emerald(Clarity clarity) 
            : base(clarity, DefaultStrength, DefaultAgility, DefaultVitality)
        {
        }
    }
}
