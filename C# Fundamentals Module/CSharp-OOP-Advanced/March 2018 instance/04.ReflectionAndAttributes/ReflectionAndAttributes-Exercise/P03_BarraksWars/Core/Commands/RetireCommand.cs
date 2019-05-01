namespace P03_BarraksWars.Core.Commands
{
    using _03BarracksFactory.Contracts;
    using P03_BarraksWars.CustomAttributes;

    public class RetireCommand : BaseCommand
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            var unitType = this.Data[0];

            this.repository.RemoveUnit(unitType);

            return $"{unitType} retired!";
        }
    }
}
