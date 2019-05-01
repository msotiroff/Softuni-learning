namespace InfernoInfinity.Core.Implementations.Commands
{
    using InfernoInfinity.Data.Contracts;
    using InfernoInfinity.Extensions.CustomAttributes;
    using InfernoInfinity.Models.Contracts;
    using System;
    using System.Linq;

    public class RemoveCommand : BaseCommand
    {
        private const string UnexistingWeapon = "Unexisting weapon!";

        [Inject]
        private IRepository<IWeapon> weaponRepository;

        public RemoveCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            var weaponName = this.Data[0];
            var index = int.Parse(this.Data[1]);

            var weapon = weaponRepository
                .Data
                .FirstOrDefault(w => w.Name == weaponName)
                ?? throw new ArgumentException(UnexistingWeapon);

            weapon.RemoveGem(index);

            return string.Empty;
        }
    }
}
