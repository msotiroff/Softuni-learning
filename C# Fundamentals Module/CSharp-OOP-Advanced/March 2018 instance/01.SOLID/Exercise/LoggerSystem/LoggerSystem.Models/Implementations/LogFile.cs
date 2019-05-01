namespace LoggerSystem.Models.Implementations
{
    using Common;
    using Contracts;
    using System.IO;
    using System.Linq;

    public class LogFile : ILogFile
    {
        public LogFile(string fileName)
        {
            this.Path = Constants.OutputDirectory + fileName;
            File.AppendAllText(this.Path, string.Empty);
        }

        public string Path { get; }

        public int Size { get; private set; }

        public void WriteToFile(string errorLog)
        {
            File.AppendAllText(this.Path, errorLog);

            this.Size += errorLog.Sum(c => (int)c);
        }
    }
}
