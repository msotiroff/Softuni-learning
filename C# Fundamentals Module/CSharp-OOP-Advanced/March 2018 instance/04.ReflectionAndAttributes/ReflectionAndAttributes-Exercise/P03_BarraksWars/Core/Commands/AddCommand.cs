namespace P03_BarraksWars.Core.Commands
{
    using _03BarracksFactory.Contracts;
    using P03_BarraksWars.CustomAttributes;

    public class AddCommand : BaseCommand
    {
        [Inject]
        private IRepository repository;
        [Inject]
        private IUnitFactory unitFactory;

        public AddCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            string unitType = base.Data[0];
            IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
            this.repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
