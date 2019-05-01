using System;
using System.Linq;

public class Engine : IEngine
{
    private IWriter writer;
    private IReader reader;
    private IClinicManager clinicManager;
    private ICommandParser commandParser;

    public Engine(IClinicManager clinicManager, ICommandParser commandParser, IReader reader, IWriter writer)
    {
        this.writer = writer;
        this.reader = reader;
        this.clinicManager = clinicManager;
        this.commandParser = commandParser;
    }

    public void Run()
    {
        var numberOfCommands = int.Parse(this.reader.ReadLine());

        for (int i = 0; i < numberOfCommands; i++)
        {
            var commandLine = this.reader.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var commandName = commandLine.First();

            var commandParams = commandLine.Skip(1).ToArray();
            
            try
            {
                var command = this.commandParser.Parse(commandName);

                var result = command.Invoke(this.clinicManager, new object[] { commandParams });

                if (result != null)
                {
                    this.writer.WriteLine(result);
                }
            }
            catch (Exception ex)
            {
                this.writer.WriteLine(ex.GetBaseException().Message);
            }
        }
    }
}
