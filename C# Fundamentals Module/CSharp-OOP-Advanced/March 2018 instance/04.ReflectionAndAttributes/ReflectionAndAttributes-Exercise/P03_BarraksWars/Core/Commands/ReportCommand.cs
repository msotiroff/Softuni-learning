namespace P03_BarraksWars.Core.Commands
{
    using _03BarracksFactory.Contracts;
    using P03_BarraksWars.CustomAttributes;

    public class ReportCommand : BaseCommand
    {
        [Inject]
        private IRepository repository;

        public ReportCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute() => this.repository.Statistics;
    }
}
