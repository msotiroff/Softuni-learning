using _03BarracksFactory.Contracts;
using P03_BarraksWars.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace P03_BarraksWars.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces()
                    .Contains(typeof(IExecutable)))
                .FirstOrDefault(t => t.Name.ToLower() == $"{commandName}command");

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            var command = (IExecutable)Activator.CreateInstance(commandType, new object[] { data });

            var instance = this.InjectDependencies(command);

            return instance;
        }

        private IExecutable InjectDependencies(IExecutable command)
        {
            var neededDependencies = command
                .GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(fi => fi.GetCustomAttributes()
                    .Any(attr => attr.GetType() == typeof(InjectAttribute)))
                .ToArray();

            foreach (var dependency in neededDependencies)
            {
                var dependencyToInject = this
                    .GetType()
                    .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .FirstOrDefault(fi => fi.Name == dependency.Name)?
                    .GetValue(this);

                dependency.SetValue(command, dependencyToInject);
            }

            return command;
        }
    }
}
