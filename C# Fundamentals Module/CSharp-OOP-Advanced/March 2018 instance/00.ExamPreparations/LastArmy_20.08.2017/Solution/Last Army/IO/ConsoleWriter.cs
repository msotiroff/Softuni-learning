using System;
using System.Text;

public class ConsoleWriter : IWriter
{
    private StringBuilder builder;

    public ConsoleWriter()
    {
        this.builder = new StringBuilder();
    }

    public void AppendLine(string line)
    {
        this.builder.AppendLine(line);
    }

    public void WriteAllText()
    {
        var result = this.builder.ToString().Trim();

        Console.WriteLine(result);
    }

    public void WriteLine(string output)
    {
        Console.WriteLine(output);
    }
}
