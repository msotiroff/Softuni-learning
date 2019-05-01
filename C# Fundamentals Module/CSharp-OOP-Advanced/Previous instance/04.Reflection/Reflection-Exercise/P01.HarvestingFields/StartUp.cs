public class StartUp
{
    public static void Main()
    {
        var interpreter = new CommandInterpreter();
        var reader = new ConsoleReader(interpreter);

        reader.StartReadingCommands();
    }
}
