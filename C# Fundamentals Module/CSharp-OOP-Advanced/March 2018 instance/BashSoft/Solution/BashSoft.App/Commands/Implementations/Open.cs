namespace BashSoft.App.Commands.Implementations
{
    using Extensions.CustomAttributes;
    using Extensions.CustomExceptions;
    using StaticData;
    using System.Diagnostics;
    using System.IO;

    [Alias("Open", "open")]
    public class Open : BaseCommand
    {
        public Open(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            if (this.Data.Length != 1)
            {
                throw new InvalidCommandArgumentsException(this.GetType().Name, 1);
            }

            string fileName = SessionData.currentPath + "\\" + this.Data[0];

            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException();
            }

            var process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = fileName;

            process.Start();

            return string.Format(Constants.FileOpened,
                fileName.Substring(fileName.LastIndexOf(@"\") + 1));
        }
    }
}
