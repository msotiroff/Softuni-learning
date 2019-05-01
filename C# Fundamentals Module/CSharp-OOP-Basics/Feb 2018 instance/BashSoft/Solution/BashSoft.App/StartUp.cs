namespace BashSoft.App
{
    using IO;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var commandInterpreter = new CommandInterpreter();

            var inputReader = new InputReader(commandInterpreter);
            inputReader.StartReadingCommands();
        }
    }
}
