using System.Linq;

public class Engine : IEngine
{
    private bool isRunning;
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
        this.isRunning = true;

        while (this.isRunning)
        {
            var inputArgs = this.reader.ReadLine().Split().Select(s => s.Trim()).ToList();
            
            var result = this.commandInterpreter.ProcessCommand(inputArgs);

            if (!string.IsNullOrEmpty(result))
            {
                this.writer.WriteLine(result);
            }

            if (inputArgs.First() == Constants.EndCommand)
            {
                this.isRunning = false;
            }
        }
    }
}
