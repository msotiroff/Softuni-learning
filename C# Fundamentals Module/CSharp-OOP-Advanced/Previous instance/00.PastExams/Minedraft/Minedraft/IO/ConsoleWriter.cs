public class ConsoleWriter : IWriter
{
    public void WriteLine(string message)
    {
        System.Console.WriteLine(message);
    }
}
