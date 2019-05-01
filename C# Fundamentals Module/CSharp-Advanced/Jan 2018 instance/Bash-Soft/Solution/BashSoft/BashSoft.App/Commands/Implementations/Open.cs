namespace BashSoft.App.Commands.Implementations
{
    using Extensions.CustomAttributes;
    using Contracts;
    using Core;
    using System.Diagnostics;

    [Alias("Open", "open")]
    public class Open : IInterpretable
    {
        public string Interpret(params string[] arguments)
        {
            string fileName = SessionData.currentPath + "\\" + arguments[0];

            var process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = fileName;

            process.Start();

            return string.Format(Constants.FileOpened, 
                fileName.Substring(fileName.LastIndexOf(@"\") + 1));
        }
    }
}
