namespace InfernoInfinity.Models.Gems
{
    using InfernoInfinity.Models.Enums;

    public class Ruby : BaseGem
    {
        private const int DefaultStrength = 7;
        private const int DefaultAgility = 2;
        private const int DefaultVitality = 5;
        
        public Ruby(Clarity clarity) 
            : base(clarity, DefaultStrength, DefaultAgility, DefaultVitality)
        {
        }
    }
}
