namespace BashSoft.App.Commands.Implementations
{
    using Extensions.CustomAttributes;
    using SimpleJudge;
    using StaticData;

    [Alias("Cmp", "cmp")]
    public class CompareFiles : BaseCommand
    {
        private IContentComparer contentComparer;

        public CompareFiles(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            if (this.Data.Length == 2)
            {
                var firstPath = this.Data[0];
                var secondPath = this.Data[1];

                contentComparer.CompareContent(firstPath, secondPath);

                return string.Empty;
            }

            return Constants.InvalidArguments;
        }
    }
}
