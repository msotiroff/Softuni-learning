namespace BashSoft.App
{
    using IO;
    using IO.Contracts;
    using Microsoft.Extensions.DependencyInjection;
    using Repositories;
    using Repositories.Contracts;
    using SimpleJudge;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();

            var commandInterpreter = new CommandInterpreter(serviceProvider);

            var inputReader = new InputReader(commandInterpreter);
            inputReader.StartReadingCommands();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IDataFilter, RepositoryFilter>();
            services.AddTransient<IDataSorter, RepositorySorter>();
            services.AddTransient<IContentComparer, Tester>();
            services.AddTransient<IDirectoryManager, IOManager>();

            services.AddSingleton<IDatabase, StudentRepository>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
