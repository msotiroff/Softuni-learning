namespace TeamBuilder.Client.Core
{
    using System;

    public class Engine
    {
        private CommandDispatcher commandDispatcher;

        public Engine(CommandDispatcher commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
        }
        public void Run()
        {
            while (true)
            {
                try
                {
                    var input = Console.ReadLine();
                    string output = commandDispatcher.Dispatch(input);

                    Console.WriteLine(output);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.GetBaseException().Message);
                }
            }
        }
    }
}
