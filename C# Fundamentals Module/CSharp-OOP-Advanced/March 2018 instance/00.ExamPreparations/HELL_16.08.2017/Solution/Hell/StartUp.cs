using Microsoft.Extensions.DependencyInjection;
using System;

public class StartUp
{
    public static void Main()
    {
        IServiceProvider serviceProvider = ConfigureServices();

        ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);

        IInputReader reader = new ConsoleReader();
        IOutputWriter writer = new ConsoleWriter();

        IEngine engine = new Engine(reader, writer, commandInterpreter);
        engine.Run();
    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IHeroManager, HeroManager>();

        services.AddTransient<IHeroFactory, HeroFactory>();
        services.AddTransient<IItemFactory, ItemFactory>();
        services.AddTransient<IRecipeFactory, RecipeFactory>();

        IServiceProvider serviceProvider = services.BuildServiceProvider();

        return serviceProvider;
    }

}