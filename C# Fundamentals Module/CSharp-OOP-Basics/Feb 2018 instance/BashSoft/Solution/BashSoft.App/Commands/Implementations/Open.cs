namespace BashSoft.App.Commands.Implementations
{
    using Contracts;
    using Core;
    using Extensions.CustomAttributes;
    using Extensions.CustomExceptions;
    using System.Diagnostics;
    using System.IO;

    [Alias("Open", "open")]
    public class Open : IInterpretable
    {
        public string Interpret(params string[] arguments)
        {
            if (arguments.Length != 1)
            {
                throw new InvalidCommandArgumentsException(this.GetType().Name, 1);
            }

            string fileName = SessionData.currentPath + "\\" + arguments[0];

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
