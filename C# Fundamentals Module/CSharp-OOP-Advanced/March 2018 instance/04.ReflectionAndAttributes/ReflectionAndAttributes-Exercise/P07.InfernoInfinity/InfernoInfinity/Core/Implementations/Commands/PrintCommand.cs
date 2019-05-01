namespace InfernoInfinity.Core.Implementations.Commands
{
    using InfernoInfinity.Data.Contracts;
    using InfernoInfinity.Extensions.CustomAttributes;
    using InfernoInfinity.Models.Contracts;
    using System;
    using System.Linq;

    public class PrintCommand : BaseCommand
    {
        private const string UnexistingWeapon = "Unexisting weapon!";

        [Inject]
        private IRepository<IWeapon> weaponRepository;

        public PrintCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            var weaponName = this.Data[0];

            var weapon = this.weaponRepository
                .Data
                .FirstOrDefault(w => w.Name == weaponName)
                ?? throw new ArgumentException(UnexistingWeapon);

            return weapon.ToString();
        }
    }
}
