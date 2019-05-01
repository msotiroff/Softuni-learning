namespace InfernoInfinity.Core.Implementations.Commands
{
    using InfernoInfinity.Core.Contracts;
    using InfernoInfinity.Data.Contracts;
    using InfernoInfinity.Extensions.CustomAttributes;
    using InfernoInfinity.Models.Contracts;
    using System.Linq;

    public class CreateCommand : BaseCommand
    {
        [Inject]
        private IFactory<IWeapon> weaponFactory;

        [Inject]
        private IRepository<IWeapon> weaponRepository;

        public CreateCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            var rarityAndType = this.Data[0];

            var rarity = rarityAndType.Split().First();
            var type = rarityAndType.Split().Last();
            var name = this.Data[1];

            IWeapon weapon = this.weaponFactory.CreateInstance(type, name, rarity);
            this.weaponRepository.Add(weapon);

            return string.Empty;
        }
    }
}
