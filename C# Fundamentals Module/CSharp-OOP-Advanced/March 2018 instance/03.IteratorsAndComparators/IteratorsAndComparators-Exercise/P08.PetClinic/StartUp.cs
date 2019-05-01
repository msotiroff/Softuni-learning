using System.Collections.Generic;

public class StartUp
{
    public static void Main(string[] args)
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();

        ClinicFactory clinicFactory = new ClinicFactory();
        PetFactory petFactory = new PetFactory();

        IList<IClinic> clinics = new List<IClinic>();
        IList<IPet> pets = new List<IPet>();

        IClinicManager clinicManager = new ClinicManager(clinicFactory, petFactory, clinics, pets);
        ICommandParser commandParser = new CommandParser();

        IEngine engine = new Engine(clinicManager, commandParser, reader, writer);
        engine.Run();
    }
}
