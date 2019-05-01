namespace InfernoInfinity.Core.Implementations.Commands
{
    using InfernoInfinity.Core.Contracts;
    using InfernoInfinity.Data.Contracts;
    using InfernoInfinity.Extensions.CustomAttributes;
    using InfernoInfinity.Models.Contracts;
    using System;
    using System.Linq;

    public class AddCommand : BaseCommand
    {
        private const string UnexistingWeapon = "Unexisting weapon!";

        [Inject]
        private IRepository<IWeapon> weaponRepository;

        [Inject]
        private IFactory<IGem> gemFactory;

        public AddCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            var weaponName = this.Data[0];
            var index = int.Parse(this.Data[1]);
            var gemArgs = this.Data[2];
            var clarity = gemArgs.Split().First();
            var gemType = gemArgs.Split().Last();

            var gem = this.gemFactory.CreateInstance(gemType, clarity);

            var weapon = this.weaponRepository
                .Data
                .FirstOrDefault(w => w.Name == weaponName)
                ?? throw new ArgumentException(UnexistingWeapon);

            weapon.AddGem(gem, index);

            return string.Empty;
        }
    }
}
