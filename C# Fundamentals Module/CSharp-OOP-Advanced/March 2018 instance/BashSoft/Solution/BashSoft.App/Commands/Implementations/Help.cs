namespace BashSoft.App.Commands.Implementations
{
    using Extensions.CustomAttributes;
    using StaticData;
    using System.IO;

    [Alias("Help", "help")]
    public class Help : BaseCommand
    {
        public Help(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            var helpInfo = File.ReadAllText(Constants.HelpFilePath);

            return helpInfo;
        }
    }
}
