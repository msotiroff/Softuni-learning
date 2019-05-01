using Emergency_Skeleton.Contracts;
using System.Text;

namespace Emergency_Skeleton.IO
{
    public class ConsoleWriter : IWriter
    {
        private StringBuilder lineBuilder;

        public ConsoleWriter()
        {
            this.lineBuilder = new StringBuilder();
        }

        public void AppendLine(string line)
        {
            this.lineBuilder.AppendLine(line);
        }

        public void WriteAllText()
        {
            var result = this.lineBuilder.ToString().Trim();
            System.Console.WriteLine(result);
            this.lineBuilder.Clear();
        }

        public void WriteLine(string line)
        {
            System.Console.WriteLine(line);
        }
    }
}
