using Emergency_Skeleton.Contracts;
using Emergency_Skeleton.Core;
using Emergency_Skeleton.Factories;
using Emergency_Skeleton.IO;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Emergency_Skeleton
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);

            IEngine engine = new Engine(reader, writer, commandInterpreter);

            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IEmergencyManagementSystem, EmergencyManagementSystem>();
            services.AddSingleton<IWriter, ConsoleWriter>();

            services.AddTransient<IServiceCenterFactory, ServiceCenterFactory>();
            services.AddTransient<IEmergencyFactory, EmergencyFactory>();
            services.AddTransient<IEmergencyRegister<IEmergency>, EmergencyRegister<IEmergency>>();
            services.AddTransient<IEmergencyRegister<IServiceCenter>, EmergencyRegister<IServiceCenter>>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
