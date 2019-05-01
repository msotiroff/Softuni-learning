public class Startup
{
    public static void Main(string[] args)
    {
        var harvesterFactory = new HarvesterFactory();
        var providerFactory = new ProviderFactory();

        var draftManager = new DraftManager(harvesterFactory, providerFactory);

        var engine = new Engine(draftManager);
        engine.Run();
    }
}
