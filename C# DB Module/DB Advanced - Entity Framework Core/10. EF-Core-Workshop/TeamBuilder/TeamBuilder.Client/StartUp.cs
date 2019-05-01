namespace TeamBuilder.Client
{
    using TeamBuilder.Client.Core;

    public class StartUp
    {
        public static void Main()
        {
            var engine = new Engine(new CommandDispatcher());
            engine.Run();
        }
    }
}
