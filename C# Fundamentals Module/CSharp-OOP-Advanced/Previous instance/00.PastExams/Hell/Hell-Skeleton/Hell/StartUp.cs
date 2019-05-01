public class StartUp
{
    public static void Main()
    {
        IInputReader reader = new ConsoleReader();
        IOutputWriter writer = new ConsoleWriter();

        //IItemFactory itemFactory = new ItemFactory();
        IHeroManager heroManager = new HeroManager();

        ICommandInterpreter commandInterpreter = new CommandInterpreter(heroManager);

        IEngine engine = new Engine(reader, writer, commandInterpreter);
        engine.Run();
    }
}