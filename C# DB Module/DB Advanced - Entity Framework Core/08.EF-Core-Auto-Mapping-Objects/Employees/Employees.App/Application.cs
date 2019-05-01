namespace Employees.App
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using AutoMapper;

    using Employees.Data;
    using Employees.Services;
    

    public class Application
    {
        public static void Main()
        {
            var serviceProvider = ConfigureServices();

            var engine = new Engine(serviceProvider);
            engine.Run();
        }

        static IServiceProvider ConfigureServices()
        {
            var serviseCollection = new ServiceCollection();

            serviseCollection.AddDbContext<EmployeesDbContext>(options => 
            options.UseSqlServer(Configuration.ConnectionString));

            serviseCollection.AddTransient<EmployeeService>();

            serviseCollection.AddAutoMapper(cnf =>
            cnf.AddProfile<AutomapperProfile>());

            var serviceProvider = serviseCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
