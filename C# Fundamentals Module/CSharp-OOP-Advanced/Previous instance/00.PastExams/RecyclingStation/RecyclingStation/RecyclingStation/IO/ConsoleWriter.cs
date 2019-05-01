using RecyclingStation.Interfaces;
using System.Text;

namespace RecyclingStation.IO
{
    public class ConsoleWriter : IWriter
    {
        private StringBuilder builder;

        public ConsoleWriter()
        {
            this.builder = new StringBuilder();
        }

        public void AppendLine(string text)
        {
            this.builder.AppendLine(text);
        }

        public void WriteAllText()
        {
            var finalResult = this.builder.ToString().Trim();

            this.builder.Clear();

            System.Console.WriteLine(finalResult);
        }

        public void WriteLine(string output)
        {
            System.Console.WriteLine(output);
        }

        public void WriteLine(object obj)
        {
            System.Console.WriteLine(obj.ToString());
        }
    }
}
