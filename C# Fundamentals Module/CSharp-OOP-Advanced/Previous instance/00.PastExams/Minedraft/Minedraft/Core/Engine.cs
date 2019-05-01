using System.Linq;

public class Engine : IEngine
{
    private const string EndCommand = "Shutdown";
    
    private IReader reader;
    private IWriter writer;
    private ICommandInterpreter commandInterpreter;

    public Engine(IReader reader, IWriter writer, ICommandInterpreter commandInterpreter)
    {
        this.reader = reader;
        this.writer = writer;
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        while (true)
        {
            var inputLine = this.reader.ReadLine();

            var commandArgs = inputLine.Split().ToList();

            var result = this.commandInterpreter.ProcessCommand(commandArgs).Trim();
       
            this.writer.WriteLine(result);

            if (inputLine.Trim() == EndCommand)
            {
                break;
            }
        }
    }
}