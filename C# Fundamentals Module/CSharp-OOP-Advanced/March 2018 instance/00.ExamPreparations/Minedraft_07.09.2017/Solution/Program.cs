using System;

public class Program
{
    public static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();

        IEnergyRepository energyRepository = new EnergyRepository();
        IProviderController providerController = new ProviderController(energyRepository);
        IHarvesterController harvesterController = new HarvesterController(energyRepository);
        ICommandInterpreter commandInterpreter = new CommandInterpreter(harvesterController, providerController);
        
        IEngine engine = new Engine(reader, writer, commandInterpreter);
        engine.Run();
    }
}